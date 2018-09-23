module Channels

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.PowerPack.Date.Local

open Shared

open ClientMsgModel

let private ibox (friends: Friend list) =
    div [ Class "ibox" ]
        [ div [ Class "ibox-title" ]
            [ span [ Class "label label-primary pull-right" ]
                [ str "NEW" ]
              h5 [ ]
                [ str "IT-01 - Design Team" ] ]
          div [ Class "ibox-content" ]
            [ div [ Class "team-members" ]
                [ for (Friend friend) in friends ->
                  let (Avatar avatar) = friend.Avatar
                  a [ Href "" ]
                    [ img [ Alt friend.AccountName
                            Class "img-circle"
                            Src avatar ] ] ]
              h4 [ ]
                [ str "Info about Design Team" ]
              p [ ]
                [ str "It is a long established fact that a reader will be distracted by the readable content
                            of a page when looking at its layout. The point of using Lorem Ipsum is that it has." ]
              div [ ]
                [ span [ ]
                    [ str "Status of current project:" ]
                  div [ Class "stat-percent" ]
                    [ str "48%" ]
                  div [ Class "progress progress-mini" ]
                    [ div [ Style [ Width "48%" ]
                            Class "progress-bar" ]
                        [ ] ] ]
              div [ Class "row  m-t-sm" ]
                [ div [ Class "col-sm-4" ]
                    [ div [ Class "font-bold" ]
                        [ str "PROJECTS" ]
                      str "12" ]
                  div [ Class "col-sm-4" ]
                    [ div [ Class "font-bold" ]
                        [ str "RANKING" ]
                      str "4th" ]
                  div [ Class "col-sm-4 text-right" ]
                    [ div [ Class "font-bold" ]
                        [ str "BUDGET" ]
                      str "$200,913"
                      i [ Class "fa fa-level-up text-navy" ]
                        [ ] ] ] ] ] 


let ibox2 (friends: Friend list) =
  div [ Class "social-feed-box" ]
      [ 
        div [ Class "ibox-title" ]
            [ span [ Class "label label-primary pull-right" ]
                [ str "NEW" ]
              h5 [ ]
                [ str "IT-01 - Design Team" ] ]
        div [ Class "ibox-content" ]
          [ div [ Class "team-members" ]
              [ for (Friend friend) in friends ->
                let (Avatar avatar) = friend.Avatar
                a [ Href "" ]
                  [ img [ Alt friend.AccountName
                          Class "img-circle"
                          Src avatar ] ] ] 

            div [ Class "social-footer" ]
          [ div [ Class "social-comment" ]
              [ a [ Href ""
                    Class "pull-left" ]
                  [ img [ Alt "image"
                          Src "img/a1.jpg" ] ]
                div [ Class "media-body" ]
                  [ a [ Href "#" ]
                      [ str "Andrew Williams" ]
                    str "Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words."
                    br [ ]
                    a [ Href "#"
                        Class "small" ]
                      [ i [ Class "fa fa-thumbs-up" ]
                          [ ]
                        str "26 Like this!" ]
                    str "-"
                    small [ Class "text-muted" ]
                      [ str "12.06.2014" ] ] ]
            div [ Class "social-comment" ]
              [ a [ Href ""
                    Class "pull-left" ]
                  [ img [ Alt "image"
                          Src "img/a2.jpg" ] ]
                div [ Class "media-body" ]
                  [ a [ Href "#" ]
                      [ str "Andrew Williams" ]
                    str "Making this the first true generator on the Internet. It uses a dictionary of."
                    br [ ]
                    a [ Href "#"
                        Class "small" ]
                      [ i [ Class "fa fa-thumbs-up" ]
                          [ ]
                        str "11 Like this!" ]
                    str "-"
                    small [ Class "text-muted" ]
                      [ str "10.07.2014" ] ] ]
            div [ Class "social-comment" ]
              [ a [ Href ""
                    Class "pull-left" ]
                  [ img [ Alt "image"
                          Src "img/a3.jpg" ] ]
                div [ Class "media-body" ]
                  [ textarea [ Class "form-control"
                               Placeholder "Write comment..." ]
                      [ ] ] ] ]

                          ] 
              ]


let channelsBox (friends: Friend list) = 
    div [ Class "row" ]
        [ div [ Class "col-lg-12" ]
            [ for i in 1 .. 12 -> ibox2 friends ]
        ]
