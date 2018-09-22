module Client.Helpers

open Fable.Helpers.React
open Fable.Helpers.React.Props
// open ClientMsgs
open Fable
open Fable.Core
open Shared.ViewModels
open Fable.DateFunctions
open System
open Fable.Import.React
open Fable.Core.JsInterop
open Shared
open System.Numerics
open ReactChartJs2

module Option = 
    let map2 f a b = match a, b with    | Some a, Some b -> f a b |> Some 
                                        | _ -> None

// let symbolLogo = function
//                     | ETH  -> "../lib/img/coins/eth_logo.png"
//                     | ETC  -> "../lib/img/coins/etc_logo.png"
//                     | BTC  -> "../lib/img/coins/btc_logo.png"
//                     | LTC  -> "../lib/img/coins/ltc_logo.png"
//                     | BCH  -> "../lib/img/coins/bch_logo.png"
//                     | BTG  -> "../lib/img/coins/btg_logo.png"
//                     | DASH -> "../lib/img/coins/dash_logo.png"                


module React =
    type Component<'P> = Fable.Import.React.Component<'P, obj>

let inline com<'P> (com: React.Component<'P>) (props: 'P ) (children: ReactElement seq): ReactElement =
    createElement(com, props, children)
let inline comF<'P> (com: React.Component<'P>) (propsFunc: 'P -> unit) (children: ReactElement seq): ReactElement =
    createElement(com, jsOptions<'P> propsFunc, children)
let inline comE<'P> (com: React.Component<'P>) (children: ReactElement seq): ReactElement =
    createElement(com, createEmpty<'P>, children)

let chartPoint v = jsOptions<ChartJs.Chart.ChartPoint>(fun cp -> 
                            cp.x <- v |> U3.Case1 |> Some
                            cp.y <- v |> U3.Case1 |> Some
                            )

let chartProps chartData (isLegend:bool) height = 
        let cLegOpt =  jsOptions<ChartJs.Chart.ChartLegendOptions>(fun clo -> 
                            clo.position <- ChartJs.Chart.PositionType.Bottom |> Some
                            )
        let cTicks = jsOptions<ChartJs.Chart.TickOptions>(fun ct -> 
                                    ct.beginAtZero <- true |> Some
                                    )                    
        let chartYAxe = jsOptions<ChartJs.Chart.ChartYAxe>(fun cya -> 
                                    cya.ticks <- cTicks |> Some
                                    )
                     
        let ra =  ResizeArray<ChartJs.Chart.ChartYAxe>()     
        ra.Add(chartYAxe)  

        let sc =  jsOptions<ChartJs.Chart.ChartScales>(fun sc -> 
                                    sc.yAxes <- ra |> Some
                                    )
        let co =  jsOptions<ChartJs.Chart.ChartOptions>(fun co -> 
                                    co.scales <- sc |> Some
                                    )
        jsOptions<ChartComponentProps>(fun o -> 
                o.data   <- chartData |> ChartData.ofT
                o.options <- co |> Some
                o.height <- if height = 0. then None else (height |> Some)
                o.legend <- if isLegend then (cLegOpt |> Some) else None
                ); 

let iboxSpinner = 
    div [ Class "sk-spinner sk-spinner-double-bounce" ]
        [ div [ Class "sk-double-bounce1" ]
            [ ]
          div [ Class "sk-double-bounce2" ]
            [ ] ]

let divider = 1000000000000000000m
let normalizeBigInt (v : decimal) = (v / divider)

//                                                                      CSS Classes

// Contextual colors

let txtN = "text-navy"
let txtM = "text-muted"
let txtP = "text-primary"
let txtS = "text-success"
let txtI = "text-info"
let txtW = "text-warning"
let txtD = "text-danger"
let txtWT = "text-white"

//Basic font width

let fb = "font-bold"
let fn = "font-normal"
let fi = "font-italic"
let fu = "font-uppercase"
let fl = "font-lowercase"
let fc = "font-capitalize"

//Common


let txtCenter = "text-center"

type Paginate = {
    Page    : int
    Total   : int
    MaxSize : int
}