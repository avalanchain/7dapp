module Friends

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.PowerPack.Date.Local

open Shared

open ClientMsgModel


let friendsBox (friends: Friend list) = 
    div [ Class "ibox-content" ]
        [ h3 [ ]
            [ str "Followers and friends" ]
          p [ Class "small" ]
            //[ str "If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing" ]
            [ str " " ]
          div [ Class "user-friends" ]
            [ for (Friend friend) in friends ->
              let (Avatar avatar) = friend.Avatar
              a [ Href "" ]
                [ img [ Alt friend.AccountName
                        Class "img-circle"
                        Src avatar ] ] ] ]