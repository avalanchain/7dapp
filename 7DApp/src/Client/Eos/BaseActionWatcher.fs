// ts2fable 0.6.1
module rec BaseActionWatcher
open System
open Fable.Core
open Fable.Import.JS

open AbstractActionHandler
open AbstractActionReader

type [<AllowNullLiteral>] IExports =
    abstract BaseActionWatcher: BaseActionWatcherStatic

/// Coordinates implementations of `AbstractActionReader`s and `AbstractActionHandler`s in
/// a polling loop.
type [<AllowNullLiteral>] BaseActionWatcher =
    abstract actionReader: AbstractActionReader with get, set
    abstract actionHandler: AbstractActionHandler with get, set
    abstract pollInterval: float with get, set
    /// Starts a polling loop running in replay mode.
    abstract replay: unit -> Promise<unit>
    /// Start a polling loop
    abstract watch: ?isReplay: bool -> Promise<unit>
    /// Use the actionReader and actionHandler to process new blocks.
    abstract checkForBlocks: ?isReplay: bool -> Promise<unit>

/// Coordinates implementations of `AbstractActionReader`s and `AbstractActionHandler`s in
/// a polling loop.
type [<AllowNullLiteral>] BaseActionWatcherStatic =
    [<Emit "new $0($1...)">] abstract Create: actionReader: AbstractActionReader * actionHandler: AbstractActionHandler * pollInterval: float -> BaseActionWatcher
