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

type Tab =
    | MainTab
    | ChannelsTab
    | SettingsTab

type ClientMsg =
    | RC of RemoteClientMsg
    | SendUser
    | ConnectionLost
    | SwitchTab of Tab

type Connection =
    | Disconnected
    | Connected of Connected
and Connected = {
    UserState   : UserState
    Feed        : FeedItem list
}

type Model = {
    Connection : Connection
    ActiveTab  : Tab 
}

let init () =
    {
        Connection  = Disconnected
        ActiveTab = Tab.MainTab
    }, Cmd.none
let update (msg : ClientMsg) (model : Model)  =
    match msg with
    | SendUser -> model, Cmd.none
    | ConnectionLost -> { model with Connection = Disconnected }, Cmd.none
    | SwitchTab tab -> { model with ActiveTab = tab }, Cmd.none
    | RC msg ->
        match msg with
        | QueryConnected ->
            Bridge.Send(UserConnected (UserId "u"))
            model, Cmd.none
        | SetState userState ->
            { model with Connection = Connected {   UserState = userState
                                                    Feed        = [] } }, Cmd.none
        | AddFeedItem fi ->
            match model.Connection with  
            | Connected con -> { model with Connection = Connected { con with Feed = fi :: con.Feed |> List.truncate 10 } }, Cmd.none
            | Disconnected -> model, Cmd.none

