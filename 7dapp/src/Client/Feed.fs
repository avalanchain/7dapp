module Feed

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.PowerPack.Date.Local

open Shared

open ClientMsgModel


let item (feedItem:FeedItem) = div [ Class "feed-element" ]
                                    [ a [ 
                                          Class "pull-left" ]
                                        [ img [ Alt "image"
                                                Class "img-circle"
                                                Src feedItem.Avatar ] ]
                                      div [ Class "media-body " ]
                                        [ small [ Class "pull-right" ]
                                                [ str feedItem.ShortTime ]
                                          strong [ Class "m-r" ]
                                                 [ str feedItem.Name ]
                                          str feedItem.Action
                                          br [ ]
                                          small [ Class "text-muted" ]
                                            [ str feedItem.Time ] ] ]
let feeds (feedItems: FeedItem list) = 
    feedItems |> List.map (fun f -> f |> item )

let feed (feedItems: FeedItem list)  =
    div [ ]
        [ 
            div [ Class "ibox float-e-margins" ]
                [ 
                  div [ Class "ibox-title" ]
                      [ h5 [  ]
                          [ str "Your daily feed" ]
                        div [ Class "ibox-tools" ]
                          [ span [ Class "label label-warning-light pull-right" ]
                              [ str (sprintf "%d new messages" (feedItems |> List.length)) ] ] ]
                  div [ Class "ibox-content" ]
                      [ div [ ]
                          [ div [ Class "feed-activity-list" ]
                                (feeds feedItems)
                            button [ Class "btn btn-primary btn-block m-t" ]
                                   [ i [ Class "fa fa-arrow-down" ]
                                          [ ]
                                     str " Show More" ] ] ] ]
                     ]



