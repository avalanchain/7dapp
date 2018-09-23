module LeftPart

open Fable.Helpers.React
open Fable.Helpers.React.Props

let leftpart  =
    div [ ]
        [ 
            div [ Class "ibox float-e-margins" ]
                [ 
                  div [ Class "ibox-title" ]
                      [ h5 [  ]
                          [ str "DApps" ]
                        div [ Class "ibox-tools" ]
                          [  ] ]
                  div [ Class "ibox-content" ]
                      [ div [ ]
                          [ 
                              str "left part"
                             ] ] ]
                     ]