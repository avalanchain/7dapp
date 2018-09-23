module Client

// open Fable
open Fable.Core
// open Fable.Import.RemoteDev
// open Fable.Import.Browser
// open Fable.Import
open JsInterop

open Elmish
open Elmish.React

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.PowerPack.Fetch

open Shared
open ClientMsgModel

open Elmish.Bridge

open TopMenu
open Footer
open RightPart
open LeftPart
open Feed
open Settings

// open Fulma


importAll "../../node_modules/bootstrap/dist/css/bootstrap.min.css"
importAll "../Client/lib/css/theme/style.css"

importAll "../Client/lib/css/theme/animate.css"
importAll "../Client/lib/css/theme/main.css"

// importAll "../Client/lib/js/theme/main.js.js"//ex ac
// // importAll "../../node_modules/jquery/dist/jquery.min.js"
// // importAll "../Client/lib//js/core/jquery.min.js"
// importAll "../Client/lib/js/theme/plugins/metisMenu/jquery.metisMenu.js"
// The model holds data that you want to keep track of while the application is running
// in this case, we are keeping track of a counter
// we mark it as optional, because initially it will not be available from the client
// the initial value will be requested from server

// type Model = { Counter: Counter option }

// The Msg type defines what events/actions can occur while the application is running
// the state of the application changes *only* in reaction to these events
// type Msg =
//     | Increment
//     | Decrement
//     | InitialCountLoaded of Result<Counter, exn>


let view (model : Model) (dispatch : ClientMsg -> unit) =
    match model.Connection with
    | Disconnected -> div [] [ ] // Loading
    | Connected con -> 
        div [] [    
                
                div [ Class "top-navigation"
                      Id "wrapper" ]
                    [
                        topmenu dispatch
                        div [ Class " gray-bg"
                              Id "wrapper"]
                            [
                                div [ ]
                                    [
                                        div [ Class "wrapper wrapper-content p-xl ng-scope" ]
                                            [
                                                div [ Class "container" ]
                                                    [
                                                        yield match model.ActiveTab with
                                                                | MainTab ->
                                                                    div [ Class "row"]
                                                                        [
                                                                            div [ Class "col-md-3" ]
                                                                                [
                                                                                    leftpart con.UserState.User
                                                                                ]
                                                                            div [ Class "col-md-6" ]
                                                                                [
                                                                                    feed con.Feed
                                                                                ]
                                                                            div [ Class "col-md-3" ]
                                                                                [
                                                                                    rightpart
                                                                                ]

                                                                        ]
                                                                | SettingsTab ->
                                                                    div [ Class "row"]
                                                                        [
                                                                settings userState.User
                                                                        ]

                                                    ]
                                                ]
                                                
                                                            
                                    ]
                            ]
                        footerw
                                        
                                
                                ]
                        ]


#if DEBUG
open Elmish.Debug
open Elmish.HMR
#endif


Program.mkProgram init update view
|> Program.withBridgeConfig
  (Bridge.endpoint Remote.socketPath
  |> Bridge.withMapping RC
  |> Bridge.withWhenDown ConnectionLost)
#if DEBUG
|> Program.withConsoleTrace
|> Program.withDebugger
#endif
|> Program.withReactUnoptimized "elmish-app"
#if DEBUG
|> Program.withHMR
#endif
|> Program.run