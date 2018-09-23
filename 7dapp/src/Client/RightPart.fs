module RightPart

open Fable.Helpers.React
open Fable.Helpers.React.Props


type DAppItem = {
    Avatar      : string
    Name        : string
    Type        : string
    Id          : string
    Users       : int
} 
let chanelData =
    [|
        {   Avatar      = "../img/avatar.jpg"
            Type        = "Collectibles"
            Id          = "12wbshgh-sadi-sdands"
            Name        = "EOSBET"
            Users       = 123      }        
        {   Avatar      = "../img/avatar.jpg"
            Type        = "Gambling"
            Id          = "12ebshgh-sadi-sdands"
            Name        = "WIZARDS"
            Users       = 123      }        
     
    |]

let item (dapp:DAppItem) = div [ Class "feed-element" ]
                                    [ a [ 
                                          Class "pull-left" ]
                                        [ img [ Alt "image"
                                                Class "img-circle"
                                                Src dapp.Avatar ] ]
                                      div [ Class "media-body " ]
                                        [ small [ Class "pull-right" ]
                                                [ str dapp.Type ]
                                          strong [ Class "m-r" ]
                                                 [ str dapp.Name ]
                                          //str (string dapp.Users)
                                          br [ ]
                                          small [ Class "text-muted" ]
                                            [ str (string dapp.Users + " users") ] ] ]

let trendDapps = chanelData |> Array.map (fun c -> c |> item ) |> Array.toList
let rightpart  =
    div [ ]
        [ 
            div [ Class "ibox float-e-margins" ]
                [ 
                  div [ Class "ibox-title" ]
                      [ h5 [  ]
                          [ str "Trending DApps"
                            ]
                        span [ Class "pull-right"]
                             [
                                  i [ Class "fa fa-fire " ]
                                          [ ]
                             ]  
                        div [ Class "ibox-tools" ]
                          [  ] ]
                  div [ Class "ibox-content" ]
                      [ div [ ]
                          trendDapps
                           ] ]
                     ]