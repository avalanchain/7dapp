module Client.Footer

open Fable.Helpers.React
open Fable.Helpers.React.Props

let footer  =
    div [ Class "footer" ]
        [ div [ Class "pull-right" ]
            [ strong [ ]
                [ str "Powered " ]
              str "by "
              a [ Href "http://avalanchain.com" ]
                [ str "Avalanchain " ]
              str "© 2018" ]
          div [ ]
            [ ] ]