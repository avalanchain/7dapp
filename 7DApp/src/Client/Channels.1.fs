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


let channelsBox (friends: Friend list) = 
    div [ Class "row" ]
        [ div [ Class "col-lg-4" ]
              [ ibox friends ]
        ]
        //       div [ Class "ibox" ]
        //         [ div [ Class "ibox-title" ]
        //             [ h5 [ ]
        //                 [ str "IT-04 - Marketing Team" ] ]
        //           div [ Class "ibox-content" ]
        //             [ div [ Class "team-members" ]
        //                 [ a [ Href "#" ]
        //                     [ img [ Alt "member"
        //                             Class "img-circle"
        //                             Src "img/a4.jpg" ] ]
        //                   a [ Href "#" ]
        //                     [ img [ Alt "member"
        //                             Class "img-circle"
        //                             Src "img/a5.jpg" ] ]
        //                   a [ Href "#" ]
        //                     [ img [ Alt "member"
        //                             Class "img-circle"
        //                             Src "img/a6.jpg" ] ]
        //                   a [ Href "#" ]
        //                     [ img [ Alt "member"
        //                             Class "img-circle"
        //                             Src "img/a8.jpg" ] ]
        //                   a [ Href "#" ]
        //                     [ img [ Alt "member"
        //                             Class "img-circle"
        //                             Src "img/a7.jpg" ] ] ]
        //               h4 [ ]
        //                 [ str "Info about Design Team" ]
        //               p [ ]
        //                 [ str "It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker." ]
        //               div [ ]
        //                 [ span [ ]
        //                     [ str "Status of current project:" ]
        //                   div [ Class "stat-percent" ]
        //                     [ str "32%" ]
        //                   div [ Class "progress progress-mini" ]
        //                     [ div [ Style [ Width "32%" ]
        //                             Class "progress-bar" ]
        //                         [ ] ] ]
        //               div [ Class "row  m-t-sm" ]
        //                 [ div [ Class "col-sm-4" ]
        //                     [ div [ Class "font-bold" ]
        //                         [ str "PROJECTS" ]
        //                       str "24" ]
        //                   div [ Class "col-sm-4" ]
        //                     [ div [ Class "font-bold" ]
        //                         [ str "RANKING" ]
        //                       str "3th" ]
        //                   div [ Class "col-sm-4 text-right" ]
        //                     [ div [ Class "font-bold" ]
        //                         [ str "BUDGET" ]
        //                       str "$190,325"
        //                       i [ Class "fa fa-level-up text-navy" ]
        //                         [ ] ] ] ] ]
        //       div [ Class "ibox" ]
        //         [ div [ Class "ibox-title" ]
        //             [ h5 [ ]
        //                 [ str "IT-07 - Finance Team" ] ]
        //           div [ Class "ibox-content" ]
        //             [ div [ Class "team-members" ]
        //                 [ a [ Href "#" ]
        //                     [ img [ Alt "member"
        //                             Class "img-circle"
        //                             Src "img/a4.jpg" ] ]
        //                   a [ Href "#" ]
        //                     [ img [ Alt "member"
        //                             Class "img-circle"
        //                             Src "img/a8.jpg" ] ]
        //                   a [ Href "#" ]
        //                     [ img [ Alt "member"
        //                             Class "img-circle"
        //                             Src "img/a7.jpg" ] ] ]
        //               h4 [ ]
        //                 [ str "Info about Design Team" ]
        //               p [ ]
        //                 [ str "Uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)." ]
        //               div [ ]
        //                 [ span [ ]
        //                     [ str "Status of current project:" ]
        //                   div [ Class "stat-percent" ]
        //                     [ str "73%" ]
        //                   div [ Class "progress progress-mini" ]
        //                     [ div [ Style [ Width "73%" ]
        //                             Class "progress-bar" ]
        //                         [ ] ] ]
        //               div [ Class "row  m-t-sm" ]
        //                 [ div [ Class "col-sm-4" ]
        //                     [ div [ Class "font-bold" ]
        //                         [ str "PROJECTS" ]
        //                       str "11" ]
        //                   div [ Class "col-sm-4" ]
        //                     [ div [ Class "font-bold" ]
        //                         [ str "RANKING" ]
        //                       str "6th" ]
        //                   div [ Class "col-sm-4 text-right" ]
        //                     [ div [ Class "font-bold" ]
        //                         [ str "BUDGET" ]
        //                       str "$560,105"
        //                       i [ Class "fa fa-level-up text-navy" ]
        //                         [ ] ] ] ] ] ]
        //   div [ Class "col-lg-4" ]
        //     [ div [ Class "ibox" ]
        //         [ div [ Class "ibox-title" ]
        //             [ h5 [ ]
        //                 [ str "IT-02 - Developers Team" ] ]
        //           div [ Class "ibox-content" ]
        //             [ div [ Class "team-members" ]
        //                 [ a [ Href "#" ]
        //                     [ img [ Alt "member"
        //                             Class "img-circle"
        //                             Src "img/a8.jpg" ] ]
        //                   a [ Href "#" ]
        //                     [ img [ Alt "member"
        //                             Class "img-circle"
        //                             Src "img/a4.jpg" ] ]
        //                   a [ Href "#" ]
        //                     [ img [ Alt "member"
        //                             Class "img-circle"
        //                             Src "img/a1.jpg" ] ] ]
        //               h4 [ ]
        //                 [ str "Info about Design Team" ]
        //               p [ ]
        //                 [ str "Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc." ]
        //               div [ ]
        //                 [ span [ ]
        //                     [ str "Status of current project:" ]
        //                   div [ Class "stat-percent" ]
        //                     [ str "61%" ]
        //                   div [ Class "progress progress-mini" ]
        //                     [ div [ Style [ Width "61%" ]
        //                             Class "progress-bar" ]
        //                         [ ] ] ]
        //               div [ Class "row  m-t-sm" ]
        //                 [ div [ Class "col-sm-4" ]
        //                     [ div [ Class "font-bold" ]
        //                         [ str "PROJECTS" ]
        //                       str "43" ]
        //                   div [ Class "col-sm-4" ]
        //                     [ div [ Class "font-bold" ]
        //                         [ str "RANKING" ]
        //                       str "1th" ]
        //                   div [ Class "col-sm-4 text-right" ]
        //                     [ div [ Class "font-bold" ]
        //                         [ str "BUDGET" ]
        //                       str "$705,913"
        //                       i [ Class "fa fa-level-up text-navy" ]
        //                         [ ] ] ] ] ]
        //       div [ Class "ibox" ]
        //         [ div [ Class "ibox-title" ]
        //             [ span [ Class "label label-warning pull-right" ]
        //                 [ str "DEADLINE" ]
        //               h5 [ ]
        //                 [ str "IT-05 - Administration Team" ] ]
        //           div [ Class "ibox-content" ]
        //             [ div [ Class "team-members" ]
        //                 [ a [ Href "#" ]
        //                     [ img [ Alt "member"
        //                             Class "img-circle"
        //                             Src "img/a1.jpg" ] ]
        //                   a [ Href "#" ]
        //                     [ img [ Alt "member"
        //                             Class "img-circle"
        //                             Src "img/a2.jpg" ] ]
        //                   a [ Href "#" ]
        //                     [ img [ Alt "member"
        //                             Class "img-circle"
        //                             Src "img/a6.jpg" ] ]
        //                   a [ Href "#" ]
        //                     [ img [ Alt "member"
        //                             Class "img-circle"
        //                             Src "img/a3.jpg" ] ]
        //                   a [ Href "#" ]
        //                     [ img [ Alt "member"
        //                             Class "img-circle"
        //                             Src "img/a4.jpg" ] ]
        //                   a [ Href "#" ]
        //                     [ img [ Alt "member"
        //                             Class "img-circle"
        //                             Src "img/a7.jpg" ] ] ]
        //               h4 [ ]
        //                 [ str "Info about Design Team" ]
        //               p [ ]
        //                 [ str "Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin." ]
        //               div [ ]
        //                 [ span [ ]
        //                     [ str "Status of current project:" ]
        //                   div [ Class "stat-percent" ]
        //                     [ str "14%" ]
        //                   div [ Class "progress progress-mini" ]
        //                     [ div [ Style [ Width "14%" ]
        //                             Class "progress-bar" ]
        //                         [ ] ] ]
        //               div [ Class "row  m-t-sm" ]
        //                 [ div [ Class "col-sm-4" ]
        //                     [ div [ Class "font-bold" ]
        //                         [ str "PROJECTS" ]
        //                       str "8" ]
        //                   div [ Class "col-sm-4" ]
        //                     [ div [ Class "font-bold" ]
        //                         [ str "RANKING" ]
        //                       str "7th" ]
        //                   div [ Class "col-sm-4 text-right" ]
        //                     [ div [ Class "font-bold" ]
        //                         [ str "BUDGET" ]
        //                       str "$40,200"
        //                       i [ Class "fa fa-level-up text-navy" ]
        //                         [ ] ] ] ] ]
        //       div [ Class "ibox" ]
        //         [ div [ Class "ibox-title" ]
        //             [ h5 [ ]
        //                 [ str "IT-08 - Lorem ipsum Team" ] ]
        //           div [ Class "ibox-content" ]
        //             [ div [ Class "team-members" ]
        //                 [ a [ Href "#" ]
        //                     [ img [ Alt "member"
        //                             Class "img-circle"
        //                             Src "img/a1.jpg" ] ]
        //                   a [ Href "#" ]
        //                     [ img [ Alt "member"
        //                             Class "img-circle"
        //                             Src "img/a8.jpg" ] ]
        //                   a [ Href "#" ]
        //                     [ img [ Alt "member"
        //                             Class "img-circle"
        //                             Src "img/a3.jpg" ] ]
        //                   a [ Href "#" ]
        //                     [ img [ Alt "member"
        //                             Class "img-circle"
        //                             Src "img/a7.jpg" ] ] ]
        //               h4 [ ]
        //                 [ str "Info about Design Team" ]
        //               p [ ]
        //                 [ str "Many desktop publishing packages and web page editors now use Lorem Ipsum as their. ometimes by accident, sometimes on purpose (injected humour and the like)." ]
        //               div [ ]
        //                 [ span [ ]
        //                     [ str "Status of current project:" ]
        //                   div [ Class "stat-percent" ]
        //                     [ str "25%" ]
        //                   div [ Class "progress progress-mini" ]
        //                     [ div [ Style [ Width "25%" ]
        //                             Class "progress-bar" ]
        //                         [ ] ] ]
        //               div [ Class "row  m-t-sm" ]
        //                 [ div [ Class "col-sm-4" ]
        //                     [ div [ Class "font-bold" ]
        //                         [ str "PROJECTS" ]
        //                       str "25" ]
        //                   div [ Class "col-sm-4" ]
        //                     [ div [ Class "font-bold" ]
        //                         [ str "RANKING" ]
        //                       str "4th" ]
        //                   div [ Class "col-sm-4 text-right" ]
        //                     [ div [ Class "font-bold" ]
        //                         [ str "BUDGET" ]
        //                       str "$140,105"
        //                       i [ Class "fa fa-level-up text-navy" ]
        //                         [ ] ] ] ] ] ]
        //   div [ Class "col-lg-4" ]
        //     [ div [ Class "ibox" ]
        //         [ div [ Class "ibox-title" ]
        //             [ h5 [ ]
        //                 [ str "IT-02 - Graphic Team" ] ]
        //           div [ Class "ibox-content" ]
        //             [ div [ Class "team-members" ]
        //                 [ a [ Href "#" ]
        //                     [ img [ Alt "member"
        //                             Class "img-circle"
        //                             Src "img/a3.jpg" ] ]
        //                   a [ Href "#" ]
        //                     [ img [ Alt "member"
        //                             Class "img-circle"
        //                             Src "img/a4.jpg" ] ]
        //                   a [ Href "#" ]
        //                     [ img [ Alt "member"
        //                             Class "img-circle"
        //                             Src "img/a7.jpg" ] ]
        //                   a [ Href "#" ]
        //                     [ img [ Alt "member"
        //                             Class "img-circle"
        //                             Src "img/a2.jpg" ] ] ]
        //         ] ] ]
                // ] 