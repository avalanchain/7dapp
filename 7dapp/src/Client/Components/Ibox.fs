module Client.Ibox

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Client.Helpers

let iboxEmpty body = div [ Class "ibox float-e-margins" ]
                            body
let iboxContentOnly body subClass = div [ Class ("ibox ibox-content " + subClass) ]
                                        body 

let iboxContentOnly2 body subClass = div [ Class ("ibox-content " + subClass) ]
                                        body                                        
let iboxContent isLoading body = div [ Class ("ibox-content " + ( if isLoading then "sk-loading" else "")) ]
                                       ( body 
                                        @ [iboxSpinner])
let iboxTitle title = div [ Class "ibox-title" ]
                        [ h5 [ ]
                            [ str title ] ]
let inner title isLoading body  =
    div [ Class "ibox float-e-margins animated fadeInUp" ]
                    [ iboxTitle title
                      iboxContent isLoading body]
let btRow title isLoading body =
    div [ Class "row" ]
            [ div [ Class "col-md-12" ]
                [ inner title isLoading body ] ]

let btCol title col isLoading body =
    div [ Class ("col-md-"+ col) ]
                [ inner title isLoading body ]
let btColLg title col isLoading body =
    div [ Class ("col-lg-"+ col) ]
                [ inner title isLoading body ]
let btColEmpty col body =
    div [ Class ("col-md-"+ col) ]
                 body 
let btColEmptyLg col body =
    div [ Class ("col-lg-"+ col) ]
                 body
let btColContentOnlyLg col body =
    div [ Class ("col-lg-"+ col) ]
                [ iboxContentOnly body "" ]                 
let btColContentOnly col body =
    div [ Class ("col-md-"+ col) ]
                [ iboxContentOnly body "" ]
let emptyRow body =
    div [ Class "row" ]
            body
            
// let btRow7 title body =
//     div [ Class "row seven-cols" ]
//             [ inner title body ]

// let viewCol title body col=
//     div [ Class "ibox float-e-margins" ]
//                     [ div [ Class "ibox-title" ]
//                         [ h5 [ ]
//                             [ str title ] ]
//                       div [ Class "ibox-content" ]
//                         [ body] ]