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

// let history =
//   let mb =
//     MailboxProcessor.Start
//      (fun (mb:MailboxProcessor<Choice<AsyncReplyChannel<Msgs list>,Msgs>>) ->
//        let rec loop l =
//         async {
//           let! msg = mb.Receive()
//           match msg with
//           |Choice1Of2 r ->
//             r.Reply l
//             return! loop l
//           |Choice2Of2 m ->
//             return! loop (m::l |> List.truncate 50)}
//        loop [])
//   {Get = fun () -> mb.PostAndReply (fun e -> Choice1Of2 e)
//    Put = fun m -> mb.Post(Choice2Of2 m)}

let update clientDispatch msg state =
    printfn "MESSAGE!!!!!!!!!!!!!!!!!!!"
    match msg with
    | Closed ->
        match state with
        | Disconnected -> ()
        | Connected u ->
            // connections.BroadcastClient(RemoveUser u.Name)
            // let msg = SysMsg {Time=System.DateTime.Now; Content = u.Name+" left the room"}
            // history.Put msg
            // connections.BroadcastClient(AddMsg msg)
            ()
        Disconnected, Cmd.none
    | RS msg -> 
        match msg with 
        | UserConnected userId -> 
            { Fake.userState with 
                Users = StateManagement.users
                User = Fake.user 
                Friends = StateManagement.friends
                Channels = StateManagement.channels
                } |> SetState |> clientDispatch 
        Connected Fake.user, Cmd.none



let asyncFeed (clientDispatch:Dispatch<RemoteClientMsg>) = async {
    do! Async.Sleep 100
    for i in 0 .. 10 do 
        do StateManagement.dataFeed.[i % StateManagement.dataFeed.Length ] |> AddFeedItem |> clientDispatch
    do! Async.Sleep 1000
    for i in 0 .. 1000000 do 
        do StateManagement.dataFeed.[i % StateManagement.dataFeed.Length ] |> AddFeedItem |> clientDispatch
        do! Async.Sleep 1000 
}

let init (clientDispatch:Dispatch<RemoteClientMsg>) () =
    clientDispatch QueryConnected
    asyncFeed clientDispatch |> Async.Start
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
       .UseDirectoryBrowser()
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