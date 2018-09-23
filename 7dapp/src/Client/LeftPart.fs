module LeftPart

open Fable.Helpers.React
open Fable.Helpers.React.Props

open Shared
open Friends

type DAppItem = {
    Avatar      : string
    Name        : string
    Id          : string
} 
let chanelData =
    [|
        {   Avatar      = "../img/avatar.jpg"
            Name        = "Collectibles"
            Id          = "12wbshgh-sadi-sdands"   }        
        {   Avatar      = "../img/avatar.jpg"
            Name        = "Gambling"
            Id          = "12ebshgh-sadi-sdands"   }        
        {   Avatar      = "../img/avatar.jpg"
            Name        = "Marketplaces"
            Id          = "12bfshgh-sadi-sdands"   }        
        {   Avatar      = "../img/avatar.jpg"
            Name        = "Games"
            Id          = "12bshhgh-sadi-sdands"   }    
        {   Avatar      = "../img/avatar.jpg"
            Name        = "Games"
            Id          = "12kshhgh-sadi-sdands"   }       
    |]

let item (dapp:DAppItem) = li [ Class "list-group-item" ]
                                    [ p [ Class "dappsMenuItem" ]
                                        [ a [ Class "text-info"
                                              Href dapp.Id ]
                                            [ str ( "#" + dapp.Name) ]
                                           ]
                                    //   small [ Class "block text-muted" ]
                                    //     [ i [ Class "fa fa-clock-o" ]
                                    //         [ ]
                                    //       str "1 minuts ago" 
                                    //       ] 
                                          
                                          ]  

let dapps = chanelData |> Array.map (fun c -> c |> item ) |> Array.toList

let leftpart (user: User) =
    div [ ]
        [ 
            div [ Class "" ]
                [ 
                  
                  div [ Class "" ]
                      [ div [ ]
                          [ 
                            //   div [ Class "profile-image" ]
                            //     [ img [ Src "img/a4.jpg"
                            //             Class "img-circle circle-border m-b-md"
                            //             Alt "profile" ] ]
                            //   div [ Class "profile-info" ]
                            //     [ div [ Class "" ]
                            //         [ div [ ]
                            //             [ h2 [ Class "no-margins" ]
                            //                 [ str "Alex Smith" ]
                            //               ] ] ]
                           div [ Class "row"]
                                [
                                    div [ Class "col-md-5" ]
                                        [
                                            img [ Src "img/a4.jpg"
                                                  Class "img-circle circle-border m-b-md"
                                                  Alt "profile" ]
                                        ]
                                    div [ Class "col-md-7" ]
                                        [
                                            h2 [ Class "no-margins text-center p-xxs" ]
                                                [ str "Alex Smith" ]
                                            table [ Class "table small transp m-b-xs" ]
                                                    [ tbody [ ]
                                                        [ 
                                                           tr [ ]
                                                            [ td [ ColSpan 2. ]
                                                                [   h3 [ Class "m-r-xxs text-center" ]
                                                                           [ str "1545 EOS" ]
                                                                     ]
                                                            //   td [ ]
                                                            //     [   strong [ Class "m-r-xxs" ]
                                                            //                 [ str "32" ]
                                                            //         str "Messages" ] 
                                                                    ]
                                                           tr [ ]
                                                                [ td [ ]
                                                                    [   strong [ Class "m-r-xxs" ]
                                                                               [ str "142" ]
                                                                        str "DApps" ]
                                                                  td [ ]
                                                                    [   strong [ Class "m-r-xxs" ]
                                                                                [ str "122" ]
                                                                        str "Friends" ] ]
                                                               ] ]

                                            
                                        ]    
                                ]

                             ] ] ]
            div [ Class "ibox float-e-margins" ]
                [ 
                  div [ Class "ibox-title" ]
                      [ h5 [  ]
                          [ 
                              div [ Class "m-l-xs" ]
                                  [
                                      str "Dapps Categories"
                                  ]  
                           ]
                        div [ Class "ibox-tools" ]
                          [  ] ]
                  div [ Class "ibox-content" ]
                      [ div [ ]
                          [ 
                            ul [ Class "list-group" ]
                               dapps

                             ] ] ]
                     ]