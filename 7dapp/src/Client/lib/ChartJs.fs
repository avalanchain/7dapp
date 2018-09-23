// ts2fable 0.6.1
module rec ChartJs
open System
open System.Diagnostics.CodeAnalysis
open Fable.Core
open Fable.Import.JS
open Fable.Import.Browser

type [<AllowNullLiteral>] IExports =
    abstract Chart: ChartStatic
    abstract PluginService: PluginServiceStaticStatic

let [<Import("*","ChartJs")>] chart: IExports = jsNative

[<SuppressMessage("NameConventions", "InterfaceNamesMustBeginWithI")>]
type [<AllowNullLiteral>] Chart =
    abstract Chart: obj
    abstract config: Chart.ChartConfiguration with get, set
    abstract data: Chart.ChartData with get, set
    abstract destroy: (unit -> obj) with get, set
    abstract update: (obj option -> obj option -> obj) with get, set
    abstract render: (obj option -> obj option -> obj) with get, set
    abstract stop: (unit -> obj) with get, set
    abstract resize: (unit -> obj) with get, set
    abstract clear: (unit -> obj) with get, set
    abstract toBase64: (unit -> string) with get, set
    abstract generateLegend: (unit -> obj) with get, set
    abstract getElementAtEvent: (obj option -> obj) with get, set
    abstract getElementsAtEvent: (obj option -> Array<obj>) with get, set
    abstract getDatasetAtEvent: (obj option -> Array<obj>) with get, set
    abstract ctx: CanvasRenderingContext2D option with get, set
    abstract canvas: HTMLCanvasElement option with get, set
    abstract chartArea: Chart.ChartArea with get, set
    abstract pluginService: PluginServiceStatic with get, set
    abstract plugins: PluginServiceStatic with get, set
    abstract defaults: obj with get, set
    abstract controllers: obj with get, set
    abstract Tooltip: Chart.ChartTooltipsStaticConfiguration with get, set

type [<AllowNullLiteral>] ChartStatic =
    [<Emit "new $0($1...)">] abstract Create: context: U4<string, CanvasRenderingContext2D, HTMLCanvasElement, ArrayLike<U2<CanvasRenderingContext2D, HTMLCanvasElement>>> * options: Chart.ChartConfiguration -> Chart

type [<AllowNullLiteral>] PluginServiceStatic =
    abstract register: plugin: PluginServiceRegistrationOptions -> unit
    abstract unregister: plugin: PluginServiceRegistrationOptions -> unit

type [<AllowNullLiteral>] PluginServiceStaticStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> PluginServiceStatic

type [<AllowNullLiteral>] PluginServiceRegistrationOptions =
    abstract beforeInit: chartInstance: Chart * ?options: obj option -> unit
    abstract afterInit: chartInstance: Chart * ?options: obj option -> unit
    abstract resize: chartInstance: Chart * newChartSize: Size * ?options: obj option -> unit
    abstract beforeUpdate: chartInstance: Chart * ?options: obj option -> unit
    abstract afterScaleUpdate: chartInstance: Chart * ?options: obj option -> unit
    abstract beforeDatasetsUpdate: chartInstance: Chart * ?options: obj option -> unit
    abstract afterDatasetsUpdate: chartInstance: Chart * ?options: obj option -> unit
    abstract afterUpdate: chartInstance: Chart * ?options: obj option -> unit
    abstract beforeRender: chartInstance: Chart * ?options: obj option -> unit
    abstract beforeDraw: chartInstance: Chart * easing: string * ?options: obj option -> unit
    abstract afterDraw: chartInstance: Chart * easing: string * ?options: obj option -> unit
    abstract beforeDatasetsDraw: chartInstance: Chart * easing: string * ?options: obj option -> unit
    abstract afterDatasetsDraw: chartInstance: Chart * easing: string * ?options: obj option -> unit
    abstract beforeTooltipDraw: chartInstance: Chart * ?tooltipData: obj option * ?options: obj option -> unit
    abstract afterTooltipDraw: chartInstance: Chart * ?tooltipData: obj option * ?options: obj option -> unit
    abstract destroy: chartInstance: Chart -> unit
    abstract beforeEvent: chartInstance: Chart * ``event``: Event * ?options: obj option -> unit
    abstract afterEvent: chartInstance: Chart * ``event``: Event * ?options: obj option -> unit

type [<AllowNullLiteral>] Size =
    abstract height: float with get, set
    abstract width: float with get, set

module Chart =

    type [<StringEnum>] [<RequireQualifiedAccess>] ChartType =
        | Line
        | Bar
        | HorizontalBar
        | Radar
        | Doughnut
        | PolarArea
        | Bubble
        | Pie

    type [<StringEnum>] [<RequireQualifiedAccess>] TimeUnit =
        | Millisecond
        | Second
        | Minute
        | Hour
        | Day
        | Week
        | Month
        | Quarter
        | Year

    type [<StringEnum>] [<RequireQualifiedAccess>] ScaleType =
        | Category
        | Linear
        | Logarithmic
        | Time
        | RadialLinear

    type [<StringEnum>] [<RequireQualifiedAccess>] PointStyle =
        | Circle
        | Cross
        | CrossRot
        | Dash
        | Line
        | Rect
        | RectRounded
        | RectRot
        | Star
        | Triangle

    type [<StringEnum>] [<RequireQualifiedAccess>] PositionType =
        | Left
        | Right
        | Top
        | Bottom

    type [<AllowNullLiteral>] ChartArea =
        abstract top: float with get, set
        abstract right: float with get, set
        abstract bottom: float with get, set
        abstract left: float with get, set

    type [<AllowNullLiteral>] ChartLegendItem =
        abstract text: string option with get, set
        abstract fillStyle: string option with get, set
        abstract hidden: bool option with get, set
        abstract lineCap: string option with get, set
        abstract lineDash: ResizeArray<float> option with get, set
        abstract lineDashOffset: float option with get, set
        abstract lineJoin: string option with get, set
        abstract lineWidth: float option with get, set
        abstract strokeStyle: string option with get, set
        abstract pointStyle: PointStyle option with get, set

    type [<AllowNullLiteral>] ChartLegendLabelItem =
        inherit ChartLegendItem
        abstract datasetIndex: float with get, set

    type [<AllowNullLiteral>] ChartTooltipItem =
        abstract xLabel: string option with get, set
        abstract yLabel: string option with get, set
        abstract datasetIndex: float option with get, set
        abstract index: float option with get, set

    type [<AllowNullLiteral>] ChartTooltipLabelColor =
        abstract borderColor: ChartColor with get, set
        abstract backgroundColor: ChartColor with get, set

    type [<AllowNullLiteral>] ChartTooltipCallback =
        abstract beforeTitle: item: ResizeArray<ChartTooltipItem> * data: ChartData -> U2<string, ResizeArray<string>>
        abstract title: item: ResizeArray<ChartTooltipItem> * data: ChartData -> U2<string, ResizeArray<string>>
        abstract afterTitle: item: ResizeArray<ChartTooltipItem> * data: ChartData -> U2<string, ResizeArray<string>>
        abstract beforeBody: item: ResizeArray<ChartTooltipItem> * data: ChartData -> U2<string, ResizeArray<string>>
        abstract beforeLabel: tooltipItem: ChartTooltipItem * data: ChartData -> U2<string, ResizeArray<string>>
        abstract label: tooltipItem: ChartTooltipItem * data: ChartData -> U2<string, ResizeArray<string>>
        abstract labelColor: tooltipItem: ChartTooltipItem * chart: Chart -> ChartTooltipLabelColor
        abstract labelTextColor: tooltipItem: ChartTooltipItem * chart: Chart -> string
        abstract afterLabel: tooltipItem: ChartTooltipItem * data: ChartData -> U2<string, ResizeArray<string>>
        abstract afterBody: item: ResizeArray<ChartTooltipItem> * data: ChartData -> U2<string, ResizeArray<string>>
        abstract beforeFooter: item: ResizeArray<ChartTooltipItem> * data: ChartData -> U2<string, ResizeArray<string>>
        abstract footer: item: ResizeArray<ChartTooltipItem> * data: ChartData -> U2<string, ResizeArray<string>>
        abstract afterFooter: item: ResizeArray<ChartTooltipItem> * data: ChartData -> U2<string, ResizeArray<string>>

    type [<AllowNullLiteral>] ChartAnimationParameter =
        abstract chartInstance: obj option with get, set
        abstract animationObject: obj option with get, set

    type [<AllowNullLiteral>] ChartPoint =
        abstract x: U3<float, string, DateTime> option with get, set
        abstract y: U3<float, string, DateTime> option with get, set
        abstract r: float option with get, set
        abstract t: U3<float, string, DateTime> option with get, set

    type [<AllowNullLiteral>] ChartConfiguration =
        abstract ``type``: U2<ChartType, string> option with get, set
        abstract data: ChartData option with get, set
        abstract options: ChartOptions option with get, set
        abstract plugins: obj option with get, set

    type [<Pojo>] ChartData = {
        labels: U2<string, string[]>[]
        datasets: ChartDataSets[]
    }

    type [<AllowNullLiteral>] ChartOptions =
        abstract responsive: bool option with get, set
        abstract responsiveAnimationDuration: float option with get, set
        abstract aspectRatio: float option with get, set
        abstract maintainAspectRatio: bool option with get, set
        abstract events: ResizeArray<string> option with get, set
        abstract onHover: this: Chart * ``event``: MouseEvent * activeElements: Array<obj> -> obj option
        abstract onClick: ?``event``: MouseEvent * ?activeElements: Array<obj> -> obj option
        abstract title: ChartTitleOptions option with get, set
        abstract legend: ChartLegendOptions option with get, set
        abstract tooltips: ChartTooltipOptions option with get, set
        abstract hover: ChartHoverOptions option with get, set
        abstract animation: ChartAnimationOptions option with get, set
        abstract elements: ChartElementsOptions option with get, set
        abstract layout: ChartLayoutOptions option with get, set
        abstract scales: ChartScales option with get, set
        abstract showLines: bool option with get, set
        abstract spanGaps: bool option with get, set
        abstract cutoutPercentage: float option with get, set
        abstract circumference: float option with get, set
        abstract rotation: float option with get, set
        abstract devicePixelRatio: float option with get, set
        abstract plugins: obj option with get, set

    type [<AllowNullLiteral>] ChartFontOptions =
        abstract defaultFontColor: ChartColor option with get, set
        abstract defaultFontFamily: string option with get, set
        abstract defaultFontSize: float option with get, set
        abstract defaultFontStyle: string option with get, set

    type [<AllowNullLiteral>] ChartTitleOptions =
        abstract display: bool option with get, set
        abstract position: PositionType option with get, set
        abstract fullWidth: bool option with get, set
        abstract fontSize: float option with get, set
        abstract fontFamily: string option with get, set
        abstract fontColor: ChartColor option with get, set
        abstract fontStyle: string option with get, set
        abstract padding: float option with get, set
        abstract text: U2<string, ResizeArray<string>> option with get, set

    type [<AllowNullLiteral>] ChartLegendOptions =
        abstract display: bool option with get, set
        abstract position: PositionType option with get, set
        abstract fullWidth: bool option with get, set
        abstract onClick: ``event``: MouseEvent * legendItem: ChartLegendLabelItem -> unit
        abstract onHover: ``event``: MouseEvent * legendItem: ChartLegendLabelItem -> unit
        abstract labels: ChartLegendLabelOptions option with get, set
        abstract reverse: bool option with get, set

    type [<AllowNullLiteral>] ChartLegendLabelOptions =
        abstract boxWidth: float option with get, set
        abstract fontSize: float option with get, set
        abstract fontStyle: string option with get, set
        abstract fontColor: ChartColor option with get, set
        abstract fontFamily: string option with get, set
        abstract padding: float option with get, set
        abstract generateLabels: chart: obj option -> obj option
        abstract filter: legendItem: ChartLegendLabelItem * data: ChartData -> obj option
        abstract usePointStyle: bool option with get, set

    type [<AllowNullLiteral>] ChartTooltipOptions =
        abstract enabled: bool option with get, set
        abstract custom: a: obj option -> unit
        abstract mode: string option with get, set
        abstract intersect: bool option with get, set
        abstract backgroundColor: ChartColor option with get, set
        abstract titleFontFamily: string option with get, set
        abstract titleFontSize: float option with get, set
        abstract titleFontStyle: string option with get, set
        abstract titleFontColor: ChartColor option with get, set
        abstract titleSpacing: float option with get, set
        abstract titleMarginBottom: float option with get, set
        abstract bodyFontFamily: string option with get, set
        abstract bodyFontSize: float option with get, set
        abstract bodyFontStyle: string option with get, set
        abstract bodyFontColor: ChartColor option with get, set
        abstract bodySpacing: float option with get, set
        abstract footerFontFamily: string option with get, set
        abstract footerFontSize: float option with get, set
        abstract footerFontStyle: string option with get, set
        abstract footerFontColor: ChartColor option with get, set
        abstract footerSpacing: float option with get, set
        abstract footerMarginTop: float option with get, set
        abstract xPadding: float option with get, set
        abstract yPadding: float option with get, set
        abstract caretSize: float option with get, set
        abstract cornerRadius: float option with get, set
        abstract multiKeyBackground: string option with get, set
        abstract callbacks: ChartTooltipCallback option with get, set
        abstract filter: item: ChartTooltipItem -> bool
        abstract itemSort: itemA: ChartTooltipItem * itemB: ChartTooltipItem -> float
        abstract position: string option with get, set
        abstract caretPadding: float option with get, set
        abstract displayColors: bool option with get, set
        abstract borderColor: ChartColor option with get, set
        abstract borderWidth: float option with get, set

    type [<AllowNullLiteral>] ChartTooltipsStaticConfiguration =
        abstract positioners: obj with get, set

    type [<AllowNullLiteral>] ChartTooltipPositioner =
        [<Emit "$0($1...)">] abstract Invoke: elements: ResizeArray<obj option> * eventPosition: Point -> Point

    type [<AllowNullLiteral>] ChartHoverOptions =
        abstract mode: string option with get, set
        abstract animationDuration: float option with get, set
        abstract intersect: bool option with get, set
        abstract onHover: this: Chart * ``event``: MouseEvent * activeElements: Array<obj> -> obj option

    type [<AllowNullLiteral>] ChartAnimationObject =
        abstract currentStep: float option with get, set
        abstract numSteps: float option with get, set
        abstract easing: string option with get, set
        abstract render: arg: obj option -> unit
        abstract onAnimationProgress: arg: obj option -> unit
        abstract onAnimationComplete: arg: obj option -> unit

    type [<AllowNullLiteral>] ChartAnimationOptions =
        abstract duration: float option with get, set
        abstract easing: string option with get, set
        abstract onProgress: chart: obj option -> unit
        abstract onComplete: chart: obj option -> unit

    type [<AllowNullLiteral>] ChartElementsOptions =
        abstract point: ChartPointOptions option with get, set
        abstract line: ChartLineOptions option with get, set
        abstract arc: ChartArcOptions option with get, set
        abstract rectangle: ChartRectangleOptions option with get, set

    type [<AllowNullLiteral>] ChartArcOptions =
        abstract backgroundColor: ChartColor option with get, set
        abstract borderColor: ChartColor option with get, set
        abstract borderWidth: float option with get, set

    type [<AllowNullLiteral>] ChartLineOptions =
        abstract tension: float option with get, set
        abstract backgroundColor: ChartColor option with get, set
        abstract borderWidth: float option with get, set
        abstract borderColor: ChartColor option with get, set
        abstract borderCapStyle: string option with get, set
        abstract borderDash: ResizeArray<obj option> option with get, set
        abstract borderDashOffset: float option with get, set
        abstract borderJoinStyle: string option with get, set
        abstract capBezierPoints: bool option with get, set
        abstract fill: U4<string, string, string, bool> option with get, set
        abstract stepped: bool option with get, set

    type [<AllowNullLiteral>] ChartPointOptions =
        abstract radius: float option with get, set
        abstract pointStyle: PointStyle option with get, set
        abstract backgroundColor: ChartColor option with get, set
        abstract borderWidth: float option with get, set
        abstract borderColor: ChartColor option with get, set
        abstract hitRadius: float option with get, set
        abstract hoverRadius: float option with get, set
        abstract hoverBorderWidth: float option with get, set

    type [<AllowNullLiteral>] ChartRectangleOptions =
        abstract backgroundColor: ChartColor option with get, set
        abstract borderWidth: float option with get, set
        abstract borderColor: ChartColor option with get, set
        abstract borderSkipped: string option with get, set

    type [<AllowNullLiteral>] ChartLayoutOptions =
        abstract padding: U2<ChartLayoutPaddingObject, float> option with get, set

    type [<AllowNullLiteral>] ChartLayoutPaddingObject =
        abstract top: float option with get, set
        abstract right: float option with get, set
        abstract bottom: float option with get, set
        abstract left: float option with get, set

    type [<AllowNullLiteral>] GridLineOptions =
        abstract display: bool option with get, set
        abstract color: ChartColor option with get, set
        abstract borderDash: ResizeArray<float> option with get, set
        abstract borderDashOffset: float option with get, set
        abstract lineWidth: float option with get, set
        abstract drawBorder: bool option with get, set
        abstract drawOnChartArea: bool option with get, set
        abstract drawTicks: bool option with get, set
        abstract tickMarkLength: float option with get, set
        abstract zeroLineWidth: float option with get, set
        abstract zeroLineColor: ChartColor option with get, set
        abstract zeroLineBorderDash: ResizeArray<float> option with get, set
        abstract zeroLineBorderDashOffset: float option with get, set
        abstract offsetGridLines: bool option with get, set

    type [<AllowNullLiteral>] ScaleTitleOptions =
        abstract display: bool option with get, set
        abstract labelString: string option with get, set
        abstract fontColor: ChartColor option with get, set
        abstract fontFamily: string option with get, set
        abstract fontSize: float option with get, set
        abstract fontStyle: string option with get, set

    type [<AllowNullLiteral>] TickOptions =
        abstract autoSkip: bool option with get, set
        abstract autoSkipPadding: float option with get, set
        abstract backdropColor: ChartColor option with get, set
        abstract backdropPaddingX: float option with get, set
        abstract backdropPaddingY: float option with get, set
        abstract beginAtZero: bool option with get, set
        abstract callback: value: obj option * index: obj option * values: obj option -> U2<string, float>
        abstract display: bool option with get, set
        abstract fontColor: ChartColor option with get, set
        abstract fontFamily: string option with get, set
        abstract fontSize: float option with get, set
        abstract fontStyle: string option with get, set
        abstract labelOffset: float option with get, set
        abstract max: obj option with get, set
        abstract maxRotation: float option with get, set
        abstract maxTicksLimit: float option with get, set
        abstract min: obj option with get, set
        abstract minRotation: float option with get, set
        abstract mirror: bool option with get, set
        abstract padding: float option with get, set
        abstract reverse: bool option with get, set
        abstract showLabelBackdrop: bool option with get, set
        abstract source: U3<string, string, string> option with get, set

    type [<AllowNullLiteral>] AngleLineOptions =
        abstract display: bool option with get, set
        abstract color: ChartColor option with get, set
        abstract lineWidth: float option with get, set

    type [<AllowNullLiteral>] PointLabelOptions =
        abstract callback: arg: obj option -> obj option
        abstract fontColor: ChartColor option with get, set
        abstract fontFamily: string option with get, set
        abstract fontSize: float option with get, set
        abstract fontStyle: string option with get, set

    type [<AllowNullLiteral>] LinearTickOptions =
        inherit TickOptions
        abstract maxTicksLimit: float option with get, set
        abstract stepSize: float option with get, set
        abstract suggestedMin: float option with get, set
        abstract suggestedMax: float option with get, set

    type [<AllowNullLiteral>] LogarithmicTickOptions =
        inherit TickOptions

    type ChartColor =
        U4<string, CanvasGradient, CanvasPattern, ResizeArray<string>>

    [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module ChartColor =
        let ofString v: ChartColor = v |> U4.Case1
        let isString (v: ChartColor) = match v with U4.Case1 _ -> true | _ -> false
        let asString (v: ChartColor) = match v with U4.Case1 o -> Some o | _ -> None
        let ofCanvasGradient v: ChartColor = v |> U4.Case2
        let isCanvasGradient (v: ChartColor) = match v with U4.Case2 _ -> true | _ -> false
        let asCanvasGradient (v: ChartColor) = match v with U4.Case2 o -> Some o | _ -> None
        let ofCanvasPattern v: ChartColor = v |> U4.Case3
        let isCanvasPattern (v: ChartColor) = match v with U4.Case3 _ -> true | _ -> false
        let asCanvasPattern (v: ChartColor) = match v with U4.Case3 o -> Some o | _ -> None
        let ofStringArray v: ChartColor = v |> U4.Case4
        let isStringArray (v: ChartColor) = match v with U4.Case4 _ -> true | _ -> false
        let asStringArray (v: ChartColor) = match v with U4.Case4 o -> Some o | _ -> None

    type [<AllowNullLiteral>] ChartDataSets =
        abstract cubicInterpolationMode: U2<string, string> option with get, set
        abstract backgroundColor: U2<ChartColor, ChartColor[]> option with get, set
        abstract borderWidth: U2<float, float[]> option with get, set
        abstract borderColor: U2<ChartColor, ChartColor[]> option with get, set
        abstract borderCapStyle: string option with get, set
        abstract borderDash: float[] option with get, set
        abstract borderDashOffset: float option with get, set
        abstract borderJoinStyle: string option with get, set
        abstract borderSkipped: PositionType option with get, set
        abstract data: U2<float[], ChartPoint[]> option with get, set
        abstract fill: U3<bool, float, string> option with get, set
        abstract hoverBackgroundColor: U2<string, string[]> option with get, set
        abstract hoverBorderColor: U2<string, string[]> option with get, set
        abstract hoverBorderWidth: U2<float, float[]> option with get, set
        abstract label: string option with get, set
        abstract lineTension: float option with get, set
        abstract steppedLine: U3<string, string, bool> option with get, set
        abstract pointBorderColor: U2<ChartColor, ChartColor[]> option with get, set
        abstract pointBackgroundColor: U2<ChartColor, ChartColor[]> option with get, set
        abstract pointBorderWidth: U2<float, float[]> option with get, set
        abstract pointRadius: U2<float, float[]> option with get, set
        abstract pointHoverRadius: U2<float, float[]> option with get, set
        abstract pointHitRadius: U2<float, float[]> option with get, set
        abstract pointHoverBackgroundColor: U2<ChartColor, ChartColor[]> option with get, set
        abstract pointHoverBorderColor: U2<ChartColor, ChartColor[]> option with get, set
        abstract pointHoverBorderWidth: U2<float, float[]> option with get, set
        abstract pointStyle: U3<PointStyle, HTMLImageElement, U2<PointStyle, HTMLImageElement>>[] option with get, set
        abstract xAxisID: string option with get, set
        abstract yAxisID: string option with get, set
        abstract ``type``: string option with get, set
        abstract hidden: bool option with get, set
        abstract hideInLegendAndTooltip: bool option with get, set
        abstract showLine: bool option with get, set
        abstract stack: string option with get, set
        abstract spanGaps: bool option with get, set

    type [<AllowNullLiteral>] ChartScales =
        abstract ``type``: U2<ScaleType, string> option with get, set
        abstract display: bool option with get, set
        abstract position: U2<PositionType, string> option with get, set
        abstract gridLines: GridLineOptions option with get, set
        abstract scaleLabel: ScaleTitleOptions option with get, set
        abstract ticks: TickOptions option with get, set
        abstract xAxes: ResizeArray<ChartXAxe> option with get, set
        abstract yAxes: ResizeArray<ChartYAxe> option with get, set

    type [<AllowNullLiteral>] CommonAxe =
        abstract bounds: string option with get, set
        abstract ``type``: U2<ScaleType, string> option with get, set
        abstract display: bool option with get, set
        abstract id: string option with get, set
        abstract stacked: bool option with get, set
        abstract position: string option with get, set
        abstract ticks: TickOptions option with get, set
        abstract gridLines: GridLineOptions option with get, set
        abstract barThickness: float option with get, set
        abstract maxBarThickness: float option with get, set
        abstract scaleLabel: ScaleTitleOptions option with get, set
        abstract offset: bool option with get, set
        abstract beforeUpdate: ?scale: obj option -> unit
        abstract beforeSetDimension: ?scale: obj option -> unit
        abstract beforeDataLimits: ?scale: obj option -> unit
        abstract beforeBuildTicks: ?scale: obj option -> unit
        abstract beforeTickToLabelConversion: ?scale: obj option -> unit
        abstract beforeCalculateTickRotation: ?scale: obj option -> unit
        abstract beforeFit: ?scale: obj option -> unit
        abstract afterUpdate: ?scale: obj option -> unit
        abstract afterSetDimension: ?scale: obj option -> unit
        abstract afterDataLimits: ?scale: obj option -> unit
        abstract afterBuildTicks: ?scale: obj option -> unit
        abstract afterTickToLabelConversion: ?scale: obj option -> unit
        abstract afterCalculateTickRotation: ?scale: obj option -> unit
        abstract afterFit: ?scale: obj option -> unit

    type [<AllowNullLiteral>] ChartXAxe =
        inherit CommonAxe
        abstract categoryPercentage: float option with get, set
        abstract barPercentage: float option with get, set
        abstract distribution: U2<string, string> option with get, set
        abstract time: TimeScale option with get, set

    type [<AllowNullLiteral>] ChartYAxe =
        inherit CommonAxe

    type [<AllowNullLiteral>] LinearScale =
        inherit ChartScales
        abstract ticks: LinearTickOptions option with get, set

    type [<AllowNullLiteral>] LogarithmicScale =
        inherit ChartScales
        abstract ticks: LogarithmicTickOptions option with get, set

    type [<AllowNullLiteral>] TimeDisplayFormat =
        abstract millisecond: string option with get, set
        abstract second: string option with get, set
        abstract minute: string option with get, set
        abstract hour: string option with get, set
        abstract day: string option with get, set
        abstract week: string option with get, set
        abstract month: string option with get, set
        abstract quarter: string option with get, set
        abstract year: string option with get, set

    type [<AllowNullLiteral>] TimeScale =
        inherit ChartScales
        abstract displayFormats: TimeDisplayFormat option with get, set
        abstract isoWeekday: bool option with get, set
        abstract max: string option with get, set
        abstract min: string option with get, set
        abstract parser: U2<string, (obj option -> obj option)> option with get, set
        abstract round: TimeUnit option with get, set
        abstract tooltipFormat: string option with get, set
        abstract unit: TimeUnit option with get, set
        abstract unitStepSize: float option with get, set
        abstract stepSize: float option with get, set
        abstract minUnit: TimeUnit option with get, set

    type [<AllowNullLiteral>] RadialLinearScale =
        abstract lineArc: bool option with get, set
        abstract angleLines: AngleLineOptions option with get, set
        abstract pointLabels: PointLabelOptions option with get, set
        abstract ticks: TickOptions option with get, set

    type [<AllowNullLiteral>] Point =
        abstract x: float with get, set
        abstract y: float with get, set
