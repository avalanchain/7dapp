// ts2fable 0.6.1
module rec ReactChartJs2
open System
open Fable.Core
open Fable.Import.JS
open Fable.Import.Browser
open Fable.Import
open ChartJs

type [<AllowNullLiteral>] IExports =
    abstract ChartComponent: ChartComponentStatic
    abstract Doughnut: DoughnutStatic
    abstract Pie: PieStatic
    abstract Line: LineStatic
    abstract Scatter: ScatterStatic
    abstract Bar: BarStatic
    abstract HorizontalBar: HorizontalBarStatic
    abstract Radar: RadarStatic
    abstract Polar: PolarStatic
    abstract Bubble: BubbleStatic
    abstract defaults: obj

type [<AllowNullLiteral>] ChartDataFunction<'T> =
    [<Emit "$0($1...)">] abstract Invoke: element: HTMLElement -> 'T

type ChartData<'T> =
    U2<ChartDataFunction<'T>, 'T>

[<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module ChartData =
    let ofChartDataFunction v: ChartData<'T> = v |> U2.Case1
    let isChartDataFunction (v: ChartData<'T>) = match v with U2.Case1 _ -> true | _ -> false
    let asChartDataFunction (v: ChartData<'T>) = match v with U2.Case1 o -> Some o | _ -> None
    let ofT v: ChartData<'T> = v |> U2.Case2
    // let isT (v: ChartData<'T>) = match v with U2.Case2 _ -> true | _ -> false
    // let asT (v: ChartData<'T>) = match v with U2.Case2 o -> Some o | _ -> None

type [<AllowNullLiteral>] ChartComponentProps =
    abstract data: ChartData<Chart.ChartData> with get, set
    abstract ``type``: Chart.ChartType option with get, set
    abstract getDatasetAtEvent: e: obj option -> unit
    abstract getElementAtEvent: e: obj option -> unit
    abstract getElementsAtEvent: e: obj option -> unit
    abstract height: float option with get, set
    abstract legend: Chart.ChartLegendOptions option with get, set
    abstract onElementsClick: e: obj option -> unit
    abstract options: Chart.ChartOptions option with get, set
    abstract redraw: bool option with get, set
    abstract width: float option with get, set

type [<AllowNullLiteral>] LinearComponentProps =
    inherit ChartComponentProps
    abstract data: ChartData<Chart.ChartData> with get, set

type [<AbstractClass>] ChartComponent<'P when 'P :> ChartComponentProps> = 
    inherit React.Component<'P, obj>
    abstract chartInstance: Chart with get, set

type [<AllowNullLiteral>] ChartComponentStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> ChartComponent<'P>

type [<AbstractClass>] Doughnut =
    inherit ChartComponent<ChartComponentProps>

type [<AllowNullLiteral>] DoughnutStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> Doughnut

type [<AbstractClass>] Pie =
    inherit ChartComponent<ChartComponentProps>

type [<AllowNullLiteral>] PieStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> Pie

type [<AbstractClass>] Line =
    inherit ChartComponent<LinearComponentProps>

type [<AllowNullLiteral>] LineStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> Line

type [<AbstractClass>] Scatter =
    inherit ChartComponent<ChartComponentProps>

type [<AllowNullLiteral>] ScatterStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> Scatter

type [<AbstractClass>] Bar =
    inherit ChartComponent<LinearComponentProps>

type [<AllowNullLiteral>] BarStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> Bar

type [<AbstractClass>] HorizontalBar =
    inherit ChartComponent<ChartComponentProps>

type [<AllowNullLiteral>] HorizontalBarStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> HorizontalBar

type [<AbstractClass>] Radar =
    inherit ChartComponent<ChartComponentProps>

type [<AllowNullLiteral>] RadarStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> Radar

type [<AbstractClass>] Polar =
    inherit ChartComponent<ChartComponentProps>

type [<AllowNullLiteral>] PolarStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> Polar

type [<AbstractClass>] Bubble =
    inherit ChartComponent<ChartComponentProps>

type [<AllowNullLiteral>] BubbleStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> Bubble
