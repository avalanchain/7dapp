module Chart

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Helpers.React
open Fable.Helpers.React.Props

open System
open Fable.Import.React
open Fable.Core.JsInterop
open Shared
open System.Numerics
open Fable.Core
open ReactChartJs2

let chartPoint v = jsOptions<ChartJs.Chart.ChartPoint>(fun cp -> 
                            cp.x <- v |> U3.Case1 |> Some
                            cp.y <- v |> U3.Case1 |> Some
                            )
type Info = {
    Name        : string
    BackgroundColor: string}
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

let referralInfo =
    let chartTrValues = [| 41.;124.;76.;14.;9.|] 
    let datab =
        [|
            {   
                Name         = "EOSBET"
                BackgroundColor = "#1ab394" }
            {   
                Name         = "WIZZ" 
                BackgroundColor = "#ed5565" }
            {   
                Name         = "IDEX"
                BackgroundColor = "#FFCE56" }
            {   
                Name         = "Wizards"
                BackgroundColor = "#23c6c8" }
            {   
                Name         = "Karma"
                BackgroundColor = "#1c84c6" }
        |]

    let chartBGColors = datab |> Array.map (fun ci -> ci.BackgroundColor )
    
    let chartLabels = datab |> Array.map (fun ci -> ci.Name )


    ///     Chart
    let datasets = jsOptions<ChartJs.Chart.ChartDataSets>(fun o -> 
        o.data <- chartTrValues |> U2.Case1 |> Some
        o.backgroundColor <- chartBGColors |> Array.map U4.Case1 |> U2.Case2 |> Some
        // o.hoverBackgroundColor <- chartHoverColors |> U2.Case2 |> Some
        )

    let chartJsData: ChartJs.Chart.ChartData = {
        labels = chartLabels |> Array.map U2.Case1  
        datasets = [| datasets |] 
    }

    let chartProps = 
        let clo =  jsOptions<ChartJs.Chart.ChartLegendOptions>(fun clo -> 
                            clo.position <- ChartJs.Chart.PositionType.Bottom |> Some
                            // clo.display  <-  true |> Some
                            )

        jsOptions<ChartComponentProps>(fun o -> 
                o.data   <- chartJsData |> ChartData.ofT
                o.legend <-  None ); 
    div [ Class "ibox float-e-margins" ]
                [ 
                  div [ Class "ibox-title" ]
                      [ h5 [  ]
                          [ 
                              div [ Class "m-l-xs" ]
                                  [
                                      str "Referral Revenue"
                                  ]  
                           ]
                        div [ Class "ibox-tools" ]
                          [  ] ]
                  div [ Class "ibox-content" ]
                      [ 
                          ofImport "Doughnut" "react-chartjs-2" chartProps []

                          br[]
                        //   h4[ Class "text-center" ]
                        //     [
                        //         str ( "Total revenue from dApps: " + string (chartTrValues |> Array.sum) + " EOS" ) 
                        //     ]  
                          div [ Class "row" ]
                              [
                                div [ Class "col-md-6"]
                                    [
                                        b [ ]
                                            [ str "DApps: "]  
                                        // br[]
                                        str ( (string chartTrValues.Length))
                                         
                                    ]
                                div [ Class "col-md-6"]
                                        [
                                          b [ ]
                                            [ str "Total: "]  
                                          str ( (string (chartTrValues |> Array.sum)) + " EOS")
                                     
                                    ] 
                                ]
                             
                             
                       ]

                  
                        ]
    

let chart  =
    div [ Class "footer" ]
        [ div [ Class "pull-right" ]
            [ strong [ ]
                [ str "Powered " ]
              str "by "
              a [ Href "http://7dapp.net" ]
                [ str "7DApp Team " ]
              str "© 2018" ]
          div [ ]
            [ ] ]