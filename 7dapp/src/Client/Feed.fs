module Feed

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.PowerPack.Date.Local


type FeedItem = {
    Avatar      : string
    Name        : string
    Time        : string
    ShortTime   : string
    Action      : string
    // BackgroundColor: string
    // ForegroundColor: string
} 
let dataFeed =
    [|
        {   Avatar      = "../img/avatar.jpg"
            Name        = "Monica Smith"
            Time        = "Today 5:60 pm - 12.06.2014"
            ShortTime   = "5m ago"
            Action      = "posted a new blog." }
        {   Avatar      = "../img/avatar.jpg"
            Name        = "Mark Johnson"
            Time        = "Today 5:60 pm - 12.06.2014"
            ShortTime   = "5m ago"
            Action      = "posted a new blog." }
        {   Avatar      = "../img/avatar.jpg"
            Name        = "Janet Rosowski"
            Time        = "Today 5:60 pm - 12.06.2014"
            ShortTime   = "5m ago"
            Action      = "posted a new blog." }
        {   Avatar      = "../img/avatar.jpg"
            Name        = "Kim Smith"
            Time        = "Today 5:60 pm - 12.06.2014"
            ShortTime   = "5m ago"
            Action      = "posted a new blog." }
    |]

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
                                                 [ str "Monica Smith" ]
                                          str feedItem.Action
                                          br [ ]
                                          small [ Class "text-muted" ]
                                            [ str feedItem.Time ] ] ]
let feeds = dataFeed |> Array.map (fun f -> f |> item ) |> Array.toList
let feed  =
    div [ ]
        [ 
            div [ Class "ibox float-e-margins" ]
                [ 
                  div [ Class "ibox-title" ]
                      [ h5 [  ]
                          [ str "Your daily feed" ]
                        div [ Class "ibox-tools" ]
                          [ span [ Class "label label-warning-light pull-right" ]
                              [ str (string dataFeed.Length + " new messages") ] ] ]
                  div [ Class "ibox-content" ]
                      [ div [ ]
                          [ div [ Class "feed-activity-list" ]
                                feeds
                            button [ Class "btn btn-primary btn-block m-t" ]
                                   [ i [ Class "fa fa-arrow-down" ]
                                          [ ]
                                     str " Show More" ] ] ] ]
                     ]



