module Client.Pagination

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

open ReactBootstrap
open Client.Helpers



let view (p:Paginate) onclickFun = // page total maxSize = //

    let pagBtn name cl pos = 
        comF button (fun b -> b.bsClass <- "btn btn-default btn-sm " + cl|> Some 
                            //   b.onClick <- if pos = p.Page then None else ( React.MouseEventHandler(onclickFun pos)  |> Some ) 
                              b.onClick <- React.MouseEventHandler(onclickFun pos)  |> Some 
                          )[ str name ]

    let pageStart = p.Page - 2
    let pageEnd = p.Page + 2

    comE buttonGroup [
        yield pagBtn "First" "" 1
        yield pagBtn "Prev" "" (if p.Page > 1 then (p.Page - 1) else p.Page)

        if pageEnd - 0 > p.Total && p.Total > 4 then yield pagBtn ((p.Total - 4) |> string) "" (p.Total - 4)
        if pageEnd - 1 > p.Total && p.Total > 3 then yield pagBtn ((p.Total - 3) |> string) "" (p.Total - 3)

        if pageStart > 0 then yield pagBtn ((p.Page - 2) |> string) "" (p.Page - 2)
        if pageStart + 1 > 0 then yield pagBtn ((p.Page - 1) |> string) "" (p.Page - 1)
        yield pagBtn ((p.Page |> string)) "active" p.Page
        if pageEnd - 2 < p.Total then yield pagBtn ((p.Page + 1) |> string) "" (p.Page + 1)
        if pageEnd - 1 < p.Total then yield pagBtn ((p.Page + 2) |> string) "" (p.Page + 2)

        if pageStart < 0 && p.Total > 3 then yield pagBtn ((4) |> string) "" (4)
        if pageStart < 1 && p.Total > 4 then yield pagBtn ((5) |> string) "" (5) 
        
        yield pagBtn "Next" "" (if p.Total > p.Page then (p.Page + 1) else p.Page)
        yield pagBtn "Last" "" p.Total
    ]