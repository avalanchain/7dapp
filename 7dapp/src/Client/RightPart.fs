module RightPart

open Fable.Helpers.React
open Fable.Helpers.React.Props

open Chart

type DAppItem = {
    Avatar      : string
    Name        : string
    Type        : string
    Id          : string
    Users       : int
} 
let chanelData =
    [|
        {   Avatar      = "../dapps/EOSbet.png"
            Type        = "Collectibles"
            Id          = "12wbshgh-sadi-sdands"
            Name        = "EOSBET"
            Users       = 2123      }        
        {   Avatar      = "../dapps/Wizards.one.png"
            Type        = "Gambling"
            Id          = "12ebshgh-sadi-sdands"
            Name        = "WIZARDS"
            Users       = 9023      }     
        {   Avatar      = "../dapps/Karma.png"
            Type        = "Collectibles"
            Id          = "12wbshgh-sadi-sdands"
            Name        = "KARMA"
            Users       = 823      }        
        {   Avatar      = "../dapps/Wizz.png"
            Type        = "Gambling"
            Id          = "12ebshgh-sadi-sdands"
            Name        = "WIZZ"
            Users       = 1123      } 
     
    |]

let item (dapp:DAppItem) = div [ Class "feed-element" ]
                                    [ a [ 
                                          Class "pull-left" ]
                                        [ img [ Alt "image"
                                                Class "w100 m-r-lg"
                                                Src dapp.Avatar ] ]
                                      div [ Class "media-body " ]
                                        [ 
                                          strong [ Class "m-r" ]
                                                 [ str dapp.Name ]
                                          //str (string dapp.Users)
                                          br [ ]
                                          small [ Class "text-muted" ]
                                            [ str (string dapp.Users + " users") ] ]
                                            // small [ Class "pull-right" ]
                                            //     [ str dapp.Type ]
                                            
                                             ]

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
                                  i [ Class "fa fa-fire text-danger" ]
                                          [ ]
                             ]  
                        div [ Class "ibox-tools" ]
                          [  ] ]
                  div [ Class "ibox-content" ]
                      [ div [ ]
                          trendDapps
                           ] ]

            referralInfo false

                     ]