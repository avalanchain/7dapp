module RightPart

open Fable.Helpers.React
open Fable.Helpers.React.Props

let rightpart  =
    div [ ]
        [ 
            div [ Class "ibox float-e-margins" ]
                [ 
                  div [ Class "ibox-title" ]
                      [ h5 [  ]
                          [ str "Suggestions" ]
                        div [ Class "ibox-tools" ]
                          [  ] ]
                  div [ Class "ibox-content" ]
                      [ div [ ]
                          [ 
                              str "right part"
                             ] ] ]
                     ]