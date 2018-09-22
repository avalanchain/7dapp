module Client.Footer

open Fable.Helpers.React
open Fable.Helpers.React.Props

let footerw  =
    div [ Class "footer" ]
        [ div [ Class "pull-right" ]
            [ strong [ ]
                [ str "Powered " ]
              str "by "
              a [ Href "http://7dapp.net" ]
                [ str "7DApp " ]
              str "© 2018" ]
          div [ ]
            [ ] ]