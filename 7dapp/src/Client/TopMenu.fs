
module TopMenu

open Fable.Helpers.React
open Fable.Helpers.React.Props

open Shared
open ClientMsgModel
open Fable.Import.RemoteDev

type TopMenuItem = {
    Caption : string
    Tab     : Tab
}

let topMenu = [
    {   Caption = "Our Motto"
        Tab     = Tab.MainTab }
    {   Caption = "Friends"
        Tab     = Tab.FriendsTab }
    {   Caption = "Settings"
        Tab     = Tab.SettingsTab }
]

let topmenu (model: Model) dispatch = 
    div [ ]
        [
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
                    [   for t in topMenu ->
                            li (if model.ActiveTab = t.Tab then [ Class "active" ] else [])
                                [ a [ OnClick (fun _ -> t.Tab |> SwitchTab |> dispatch ) ]
                                    [ str t.Caption ] ] ]
                  ul [ Class "nav navbar-top-links navbar-right" ]
                    [ li [ ]
                        [ 
                            a [ Class "dropdown-toggle count-info"
                                DataToggle "dropdown"
                                Href "#" ]
                                [ i [ Class "fa fa-envelope text-muted" ]
                                    [ ]
                                  span [ Class "label label-warning" ]
                                    [ str "16" ] ]
                         ] ] ] ] ]
        ]
