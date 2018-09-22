module Client.TopNavbar

open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props

open ClientMsgs
open Shared.ViewModels

module O = Option

let navBar (customer: Customer option) (dispatch: UIMsg -> unit)  = 
        div [ Class "row border-bottom" ]
            [ nav [ Class "navbar navbar-static-top white-bg no-margins"
                    Role "navigation"
                    // HTMLAttr.Custom ("style", "margin-bottom: 0") 
                    ]
                [ div [ Class "navbar-header logo-bg" ]
                    [ div [ Class "navbar-minimalize minimalize-styl-2 btn btn-primary "
                        //   Href "#" 
                          ]
                        [ i [ Class "fa fa-bars" ]
                            [ ] ]
                    //   form [ Role "search"
                    //          Class "navbar-form-custom"
                    //          Method "post"
                    //          Action "#" ]
                    //     [ div [ Class "form-group" ]
                    //         [ input [ Type "text"
                    //                   Placeholder "Search for something..."
                    //                   Class "form-control"
                    //                   Name "top-search"
                    //                   Id "top-search" ] ] ] 
                                      
                                      ]
                  ul [ Class "nav navbar-top-links navbar-right" ]
                    [ li [ ]
                         [ a [ Href "#" 
                               OnClick(fun _ -> dispatch Logout)  ]
                            [ i [ Class "fa fa-envelope" ]
                                [ ]
                              str (customer |> O.map (fun c -> c.Email) |> O.defaultValue "") ] ]

                      li [ ]
                         [ a [ Href "#" 
                               OnClick(fun _ -> dispatch Logout)  ]
                            [ i [ Class "fa fa-sign-out" ]
                                [ ]
                              str "Log out" ] ] ] ] ]