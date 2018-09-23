
module Settings

open Fable.Helpers.React
open Fable.Helpers.React.Props

let inner = 
    div [ ]
        [
            form [ Class "form-horizontal" ]
        [ 
          div [ Class "hr-line-dashed" ]
            [ ]
          div [ Class "form-group" ]
            [ label [ Class "col-sm-2 control-label" ]
                [ str "Help text" ]
              div [ Class "col-sm-10" ]
                [ input [ Type "text"
                          Class "form-control" ]
                  span [ Class "help-block m-b-none" ]
                    [ str "A block of help text that breaks onto a new line and may extend beyond one line." ] ] ]
          div [ Class "hr-line-dashed" ]
            [ ]
          div [ Class "form-group" ]
            [ label [ Class "col-sm-2 control-label" ]
                [ str "Password" ]
              div [ Class "col-sm-10" ]
                [ input [ Type "password"
                          Class "form-control"
                          Name "password" ] ] ]
          div [ Class "hr-line-dashed" ]
            [ ]
          div [ Class "form-group" ]
            [ label [ Class "col-sm-2 control-label" ]
                [ str "Placeholder" ]
              div [ Class "col-sm-10" ]
                [ input [ Type "text"
                          Placeholder "placeholder"
                          Class "form-control" ] ] ]
          div [ Class "hr-line-dashed" ]
            [ ]
          div [ Class "form-group" ]
            [ label [ Class "col-lg-2 control-label" ]
                [ str "Disabled" ]
              div [ Class "col-lg-10" ]
                [ input [ Type "text"
                          Placeholder "Disabled input here..."
                          Class "form-control" ] ] ]
          div [ Class "hr-line-dashed" ]
            [ ]
          div [ Class "form-group" ]
            [ label [ Class "col-lg-2 control-label" ]
                [ str "Static control" ]
              div [ Class "col-lg-10" ]
                [ p [ Class "form-control-static" ]
                    [ str "email@example.com" ] ] ]
          
            ]]

let settings = div [ Class "col-lg-12" ]
                [ div [ Class "ibox float-e-margins" ]
                    [ div [ Class "ibox-title" ]
                        [ h5 [ ]
                            [ str "Settings"
                               ]
                          div [ ]
                            [ 
                              inner

                            ] ] ] ]