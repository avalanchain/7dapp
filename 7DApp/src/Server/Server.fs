open System
open System.IO
open System.Threading.Tasks

open Microsoft.AspNetCore
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection

open FSharp.Control.Tasks.V2
open Giraffe
open Shared

open Fable.Remoting.Server
open Fable.Remoting.Giraffe

open Elmish.Bridge
open Elmish

let publicPath = Path.GetFullPath "../Client/public"
let port = 8085us

type ServerMsg =
  | RS of RemoteServerMsg
  | Closed

let getInitCounter () : Task<Counter> = task { return 42 }

let counterApi = {
    initialCounter = getInitCounter >> Async.AwaitTask
}

type State =
    | Connected of User
    | Disconnected

let connections =
    ServerHub<State,ServerMsg,RemoteClientMsg>()
        .RegisterServer(RS)

type History<'a> = {
    Get: unit -> 'a list
    Put: 'a -> unit
}

let history =
  let mb =
    MailboxProcessor.Start
     (fun (mb:MailboxProcessor<Choice<AsyncReplyChannel<Msgs list>,Msgs>>) ->
       let rec loop l =
        async {
          let! msg = mb.Receive()
          match msg with
          |Choice1Of2 r ->
            r.Reply l
            return! loop l
          |Choice2Of2 m ->
            return! loop (m::l |> List.truncate 50)}
       loop [])
  {Get = fun () -> mb.PostAndReply (fun e -> Choice1Of2 e)
   Put = fun m -> mb.Post(Choice2Of2 m)}

let update clientDispatch msg state =
    printfn "MESSAGE!!!!!!!!!!!!!!!!!!!"
    match msg with
     | Closed ->
          match state with
          |Disconnected -> ()
          |Connected u ->
            connections.BroadcastClient(RemoveUser u.Name)
            let msg = SysMsg {Time=System.DateTime.Now; Content = u.Name+" left the room"}
            history.Put msg
            connections.BroadcastClient(AddMsg msg)
          Disconnected, Cmd.none
     |RS msg ->
      match state, msg with
      | _, UsersConnected ->
          let users =
            connections.GetModels()
            |> Seq.choose (function Disconnected -> None | Connected u -> Some u)
            |> Seq.toList
          clientDispatch (GetUsers users)
          clientDispatch (AddMsgs (history.Get()))
          state, Cmd.none
      | Disconnected, SetUser u ->
          if connections.GetModels() |> Seq.exists (function Disconnected -> false | Connected {Name=n} -> n=u.Name) then
            clientDispatch (AddMsg (SysMsg {Time=System.DateTime.Now; Content = "Name is in use"}))
            clientDispatch (NameStatus false)
            state, Cmd.none
          else
            let state = Connected u
            connections.BroadcastClient(AddUser u)
            let msg = SysMsg {Time=System.DateTime.Now; Content = u.Name+" joined the room"}
            history.Put msg
            connections.BroadcastClient(AddMsg msg)
            clientDispatch(NameStatus true)
            state, Cmd.none
      | Disconnected, _  | _, SetUser _ -> state, Cmd.none
      | (Connected u),SendMsg m ->
          if String.IsNullOrWhiteSpace m then
              ()
          else
              let msg = ClientMsg (u.Name,{Content=m;Time = DateTime.Now})
              history.Put msg
              connections.BroadcastClient(AddMsg msg)
          state, Cmd.none
      | (Connected u),ChangeColor c ->
          printfn "Connected!!!!!!!"
          connections.BroadcastClient(ColorChange(u.Name,c))
          Connected {u with Color = c}, Cmd.none

let init (clientDispatch:Dispatch<RemoteClientMsg>) () =
    printfn "Init!!!!!!!"
    clientDispatch QueryConnected
    Disconnected, Cmd.none

let server =
    Bridge.mkServer Remote.socketPath init update
    |> Bridge.withConsoleTrace
    |> Bridge.register RS
    |> Bridge.whenDown Closed
    |> Bridge.withServerHub connections
    |> Bridge.run Giraffe.server





let webApp =
    choose [ 
        server
        Remoting.createApi()
        |> Remoting.withRouteBuilder Route.builder
        |> Remoting.fromValue counterApi
        |> Remoting.buildHttpHandler ]


let configureApp (app : IApplicationBuilder) =
    app.UseDefaultFiles()
       .UseStaticFiles()
       .UseWebSockets()
       .UseGiraffe webApp

let configureServices (services : IServiceCollection) =
    services.AddGiraffe() |> ignore

WebHost
    .CreateDefaultBuilder()
    .UseWebRoot(publicPath)
    .UseContentRoot(publicPath)
    .Configure(Action<IApplicationBuilder> configureApp)
    .ConfigureServices(configureServices)
    .UseUrls("http://0.0.0.0:" + port.ToString() + "/")
    .Build()
    .Run()