module Client.Breadcrumb

open Fable.Helpers.React
open Fable.Helpers.React.Props


let bc =
    div [ ClassName "app-body" ] [
                    //sidebar model dispatch
                    Menu.view model (AppMsg.MenuMsg >> dispatch)
                    main [ ClassName "main" ] [
                        ol [ ClassName "breadcrumb" ] (
                            match model.Page with 
                            | MenuPage.Home -> [ li [ ClassName "breadcrumb-item active" ] [ text "Home" ] ]
                            | MenuPage.Admin -> [ li [ ClassName "breadcrumb-item active" ] [ text "Admin" ] ]
                            | MenuPage.Login -> [ li [ ClassName "breadcrumb-item active" ] [ text "Login" ] ]
                            | MenuPage.Static p -> [li [ ClassName "breadcrumb-item" ] [ text "Static Data" ]
                                                    li [ ClassName "breadcrumb-item active" ] [ text (p |> getUnionCaseNameSplit) ] ]
                            | MenuPage.Trading p -> [   li [ ClassName "breadcrumb-item" ] [ text "Trading" ]
                                                        li [ ClassName "breadcrumb-item active" ] [ text (p |> getUnionCaseNameSplit) ] ]
                        )
                        div [ ClassName "container-fluid" ] [
                            div [ ClassName "animated fadeIn" ] [
                                div [  ] (innerPageView model dispatch)
                            ]
                        ]
                    ]
                    //aside model dispatch
                ]