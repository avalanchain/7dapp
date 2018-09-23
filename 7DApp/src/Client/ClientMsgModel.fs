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
    ConnectedUsers  : User list
    Messages        : Msgs list
}

let init () =
    {
        Connection = Disconnected
        ConnectedUsers = []
        Messages = []
    }, Cmd.none
let update (msg : ClientMsg) (model : Model)  =
    match msg with
    | SendUser -> model, Cmd.none
    | ConnectionLost -> {model with Connection = Disconnected}, Cmd.none
    | RC msg ->
        match msg with
        | GetUsers l -> {model with ConnectedUsers = l}, Cmd.none
        | QueryConnected ->
            printfn "QueryConnected!!!!"
            match model.Connection with
            | Connected u -> Bridge.Send(SetUser u)
            | Waiting | Disconnected -> ()
            Bridge.Send UserConnected
            { model with ConnectedUsers = [] }, Cmd.none

        | AddUser u ->
            { model with ConnectedUsers = u::model.ConnectedUsers }, Cmd.none
        | RemoveUser u ->
            { model with ConnectedUsers = model.ConnectedUsers
                                            |> List.filter (fun {Name=n} -> n<>u)}, Cmd.none
        | AddMsg m ->
            {model with Messages = m::model.Messages}, Cmd.none
        | AddMsgs m -> {model with Messages = m}, Cmd.none
