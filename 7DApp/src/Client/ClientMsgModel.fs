module ClientMsgModel

open Shared

open Elmish
open Elmish.React

open Elmish.Bridge


module Server =

    open Shared
    open Fable.Remoting.Client

    /// A proxy you can use to talk to server directly
    let api : ICounterApi =
      Remoting.createApi()
      |> Remoting.withRouteBuilder Route.builder
      |> Remoting.buildProxy<ICounterApi>


type ClientMsg =
    | RC of RemoteClientMsg
    | SendUser
    | ConnectionLost

type Connection =
    | Disconnected
    | Waiting
    | Connected of User


type Model = {
    Connection      : Connection
    UserState       : UserState option
}

let init () =
    {
        Connection  = Disconnected
        UserState   = None
    }, Cmd.none
let update (msg : ClientMsg) (model : Model)  =
    match msg with
    | SendUser -> model, Cmd.none
    | ConnectionLost -> {model with Connection = Disconnected}, Cmd.none
    | RC msg ->
        match msg with
        | QueryConnected ->
            printfn "QueryConnected!!!!"
            // match model.Connection with
            // | Connected u //-> Bridge.Send(SetUser u)
            // | Waiting 
            // | Disconnected -> ()
            // Bridge.Send UserConnected
            // { model with ConnectedUsers = [] }, Cmd.none
            model, Cmd.none
        | SetState userState -> { model with UserState = Some userState }, Cmd.none

