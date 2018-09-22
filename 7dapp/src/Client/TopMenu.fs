
module Client.TopMenu

open Fable.Helpers.React
open Fable.Helpers.React.Props

let topmenu = 
div [ Class "row border-bottom white-bg" ]
    [ nav [ Class "navbar navbar-static-top"
            Role "navigation" ]
        [ div [ Class "navbar-header" ]
            [ button [ Class "navbar-toggle collapsed"
                       Type "button" ]
                [ i [ Class "fa fa-reorder" ]
                    [ ] ]
              a [ Href "#"
                  Class "navbar-brand" ]
                [    span[ Class "seven" ][ str "7"]
                     span[ Class "dapp" ][ str "DApp"]
                      ] ]
          div [ Class "navbar-collapse collapse"
                Id "navbar" ]
            [ ul [ Class "nav navbar-nav" ]
                [ li [ Class "active" ]
                    [ a [ Href "" ]
                        [ str "Our Motto" ] ]
                  li [ ]
                    [ a [ Href "" ]
                        [ str "Friends"
                          span [ Class "caret" ]
                            [ ] ]
                    //   ul [ Role "menu" ]
                    //     [ li [ ]
                    //         [ a [ Href "#" ]
                    //             [ str "Menu item" ] ]
                    //       li [ ]
                    //         [ a [ Href "#" ]
                    //             [ str "Menu item" ] ]
                    //       li [ ]
                    //         [ a [ Href "#" ]
                    //             [ str "Menu item" ] ]
                    //       li [ ]
                    //         [ a [ Href "#" ]
                    //             [ str "Menu item" ] ] ]
                                 ] ]
              ul [ Class "nav navbar-top-links navbar-right" ]
                [ li [ ]
                    [ a [ Href "login.html" ]
                        [  i [ Class "fa fa-sign-out" ]
                             [ ]
                           str "Log out" ] ] ] ] ] ]