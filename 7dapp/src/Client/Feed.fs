module Feed

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.PowerPack.Date.Local

open Shared

open ClientMsgModel




let investItem (investitem:Invest) = div [ Class "feed-element" ]
                                        [ a [ 
                                              Class "pull-left" ]
                                            [ img [ Alt "image"
                                                    Class "img-circle"
                                                    Src (string investitem.User.Avatar) ] ]
                                          div [ Class "media-body " ]
                                            [ small [ Class "pull-right" ]
                                                    [ str investitem.ShortTime ]
                                              strong [ Class "m-r" ]
                                                     [ str (string investitem.User.AccountName) ]
                                              str investitem.Action
                                              str (string investitem.Money)
                                              br [ ]
                                              str (string investitem.Text)
                                              br [ ]
                                              small [ Class "text-muted" ]
                                                [ str investitem.Time ] ] ]

let purchasedItem (investitem:Payment) = div [ Class "feed-element" ]
                                                [ a [ 
                                                      Class "pull-left" ]
                                                    [ img [ Alt "image"
                                                            Class "img-circle"
                                                            Src (string investitem.User.Avatar) ] ]
                                                  div [ Class "media-body " ]
                                                    [ small [ Class "pull-right" ]
                                                            [ str investitem.ShortTime ]
                                                      strong [ Class "m-r" ]
                                                             [ str (string investitem.User.AccountName) ]
                                                      str investitem.Action
                                                      str (string investitem.Asset)
                                                      br [ ]
                                                      str (string investitem.Money)
                                                      br [ ]
                                                      small [ Class "text-muted" ]
                                                        [ str investitem.Time ] ] ]

let editItem (investitem:Edit) = div [ Class "feed-element" ]
                                                [ a [ 
                                                      Class "pull-left" ]
                                                    [ img [ Alt "image"
                                                            Class "img-circle"
                                                            Src (string investitem.User.Avatar) ] ]
                                                  div [ Class "media-body " ]
                                                    [ small [ Class "pull-right" ]
                                                            [ str investitem.ShortTime ]
                                                      strong [ Class "m-r" ]
                                                             [ str (string investitem.User.AccountName) ]
                                                      str investitem.Action
                                                      str (string investitem.Text)
                                                      br [ ]
                                                      str (string investitem.Dapp)
                                                      br [ ]
                                                      small [ Class "text-muted" ]
                                                        [ str investitem.Time ] ] ]

let gameItem (investitem:Game) = div [ Class "feed-element" ]
                                                [ a [ 
                                                      Class "pull-left" ]
                                                    [ img [ Alt "image"
                                                            Class "img-circle"
                                                            Src (string investitem.User.Avatar) ] ]
                                                  div [ Class "media-body " ]
                                                    [ small [ Class "pull-right" ]
                                                            [ str investitem.ShortTime ]
                                                      strong [ Class "m-r" ]
                                                             [ str (string investitem.User.AccountName) ]
                                                      str investitem.Action
                                                      str (string investitem.Money)
                                                      str (string investitem.Text)
                                                      str (string investitem.Dapp)
                                                      br [ ]
                                                      small [ Class "text-muted" ]
                                                        [ str investitem.Time ] ] ]

let tradeItem (investitem:Trade) = div [ Class "feed-element" ]
                                                [ a [ 
                                                      Class "pull-left" ]
                                                    [ img [ Alt "image"
                                                            Class "img-circle"
                                                            Src (string investitem.User.Avatar) ] ]
                                                  div [ Class "media-body " ]
                                                    [ small [ Class "pull-right" ]
                                                            [ str investitem.ShortTime ]
                                                      strong [ Class "m-r" ]
                                                             [ str (string investitem.User.AccountName) ]
                                                      str investitem.Action
                                                      str (string investitem.Money)
                                                      str (string investitem.ToMoney)
                                                      str (string investitem.Dapp)
                                                      br [ ]
                                                      small [ Class "text-muted" ]
                                                        [ str investitem.Time ] ] ]
let messageItem (investitem:Message) = div [ Class "feed-element" ]
                                                [ a [ 
                                                      Class "pull-left" ]
                                                    [ img [ Alt "image"
                                                            Class "img-circle"
                                                            Src (string investitem.User.Avatar) ] ]
                                                  div [ Class "media-body " ]
                                                    [ small [ Class "pull-right" ]
                                                            [ str investitem.ShortTime ]
                                                      strong [ Class "m-r" ]
                                                             [ str (string investitem.User.AccountName) ]
                                                      str investitem.Action
                                                      str (string investitem.Content)
                                                      br [ ]
                                                      small [ Class "text-muted" ]
                                                        [ str investitem.Time ] ] ]                                                        
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
    let datetime = System.DateTime.Now.ToLongTimeString()
    div [ ]
        [ 
            div [ Class "ibox float-e-margins" ]
                [ 
                  div [ Class "ibox-title" ]
                      [ h5 [  ]
                          [ str "Feed" ]
                        div [ Class "ibox-tools" ]
                          [ span [ Class "label label-success pull-right" ]
                              [ str datetime ] ] ]
                  div [ Class "ibox-content" ]
                      [ div [ ]
                          [ div [ Class "feed-activity-list" ]
                                (feeds feedItems)
                          
                                     
                                     
                                      ] ] ]
                     ]



