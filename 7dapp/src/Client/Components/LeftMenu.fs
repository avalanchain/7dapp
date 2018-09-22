module Client.LeftMenu

open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Recharts

open ClientMsgs
open ClientModels

open JsInterop

// importAll "../lib/css/dashboard.css"
// let LeftMenu  (model : Model) (dispatch : UIMsg -> unit)=
//     let navItem icon menuMediator =  li [ Class ("side-icon " + if model.MenuMediator = menuMediator then "is-active" else "")
//                                           OnClick (fun _ ->  menuMediator |> MenuSelected |> dispatch)  
//                                            ]
//                                         [ i [ Class icon ]
//                                             [ ] ]

//     nav [ Class "main-menu" ]
//         [ div [ Class "main-menu-inner" ]
//             [ ul [ ]
//                 [ li [ Class "main-logo" ]
//                     [ a [ Href "#" ]
//                         [ img [ Src "../lib/images/logos/square-violet.svg"
//                                 Alt "" ] ] ]
                  
//                   navItem "sl sl-icon-basket" PurchaseToken
//                   navItem "sl sl-icon-note" Verification
//                   navItem "sl sl-icon-briefcase" MyInvestments
//                   navItem "sl sl-icon-graph" ReferralProgram
//                   navItem "sl sl-icon-info" Contacts
//                   navItem "sl sl-icon-speedometer" Dashboard
                       
//                  ] ] ]
let LeftMenu  (model : Model) (dispatch : UIMsg -> unit)=
    nav [ Class "navbar-default navbar-static-side"
          Role "navigation" ]
        [ div [ Class "sidebar-collapse" ]
            [ ul [ Class "nav metismenu"
                   Id "side-menu" ]
                [ li [ Class "nav-header" ]
                    [ div [ Class "dropdown profile-element" ]
                        [ a [ DataToggle "dropdown"
                              Class "dropdown-toggle"
                              Href "#" ]
                            [ span [ Class "clear" ]
                                   [ img [ Class "logo"
                                           Src "../lib/img/avalanchain.png" ] ] ]
                          ul [ Class "dropdown-menu animated fadeInRight m-t-xs" ]
                            [ li [ ]
                                [ a [ Href "#" ]
                                    [ str "Logout" ] ] ] ]
                      div [ Class "logo-element" ]
                        [ str "TC" ] ]
                  li [ Class "active" ]
                    [ a [ Href "index.html" ]
                        [ i [ Class "fa fa-th-large" ]
                            [ ]
                          span [ Class "nav-label" ]
                            [ str "Main view" ] ] ]
                  li [ ]
                    [ a [ Href "minor.html" ]
                        [ i [ Class "fa fa-th-large" ]
                            [ ]
                          span [ Class "nav-label" ]
                            [ str "Minor view" ] ] ] ] ] ]