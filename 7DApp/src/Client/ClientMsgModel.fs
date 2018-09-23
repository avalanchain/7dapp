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
    | Connected of UserState


type Model = {
    Connection      : Connection
}

let init () =
    {
        Connection  = Disconnected
    }, Cmd.none
let update (msg : ClientMsg) (model : Model)  =
    match msg with
    | SendUser -> model, Cmd.none
    | ConnectionLost -> {model with Connection = Disconnected}, Cmd.none
    | RC msg ->
        match msg with
        | QueryConnected ->
            Bridge.Send(UserConnected (UserId "u"))
            model, Cmd.none
        | SetState userState ->
            { model with Connection = Connected userState }, Cmd.none

