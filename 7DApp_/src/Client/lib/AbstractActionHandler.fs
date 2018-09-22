// ts2fable 0.6.1
module rec AbstractActionHandler
open System
open Fable.Core
open Fable.Import.JS

type Block = __interfaces.Block
type Effect = __interfaces.Effect
type IndexState = __interfaces.IndexState
type Updater = __interfaces.Updater

type [<AllowNullLiteral>] IExports =
    abstract AbstractActionHandler: AbstractActionHandlerStatic

/// Takes `block`s output from implementations of `AbstractActionReader` and processes their actions through
/// `Updater`s and `Effect`s. Pass an object exposing a persistence API as `state` in the `handleWithState`
/// method. Persist and retrieve information about the last block processed with `updateIndexState` and
/// `loadIndexState`.
type [<AllowNullLiteral>] AbstractActionHandler =
    abstract updaters: ResizeArray<Updater> with get, set
    abstract effects: ResizeArray<Effect> with get, set
    abstract lastProcessedBlockNumber: float with get, set
    abstract lastProcessedBlockHash: string with get, set
    /// Receive block, validate, and handle actions with updaters and effects
    abstract handleBlock: block: Block * isRollback: bool * isFirstBlock: bool * ?isReplay: bool -> Promise<bool * float>
    /// Updates the `lastProcessedBlockNumber` and `lastProcessedBlockHash` meta state, coinciding with the block
    /// that has just been processed. These are the same values read by `updateIndexState()`.
    abstract updateIndexState: state: obj option * block: Block * isReplay: bool * ?context: obj option -> Promise<unit>
    /// Returns a promise for the `lastProcessedBlockNumber` and `lastProcessedBlockHash` meta state,
    /// coinciding with the block that has just been processed.
    /// These are the same values written by `updateIndexState()`.
    abstract loadIndexState: unit -> Promise<IndexState>
    /// Calls handleActions with the appropriate state passed by calling the `handle` parameter function.
    /// Optionally, pass in a `context` object as a second parameter.
    abstract handleWithState: handle: (obj option -> obj option -> unit) -> Promise<unit>
    /// Process actions against deterministically accumulating updater functions.
    abstract runUpdaters: state: obj option * block: Block * context: obj option -> Promise<unit>
    /// Process actions against asynchronous side effects.
    abstract runEffects: state: obj option * block: Block * context: obj option -> unit
    /// Will run when a rollback block number is passed to handleActions. Implement this method to
    /// handle reversing actions full blocks at a time, until the last applied block is the block
    /// number passed to this method.
    abstract rollbackTo: blockNumber: float -> Promise<unit>
    /// Calls `runUpdaters` and `runEffects` on the given actions
    abstract handleActions: state: obj option * block: Block * context: obj option * isReplay: bool -> Promise<unit>
    abstract refreshIndexState: obj with get, set

/// Takes `block`s output from implementations of `AbstractActionReader` and processes their actions through
/// `Updater`s and `Effect`s. Pass an object exposing a persistence API as `state` in the `handleWithState`
/// method. Persist and retrieve information about the last block processed with `updateIndexState` and
/// `loadIndexState`.
type [<AllowNullLiteral>] AbstractActionHandlerStatic =
    [<Emit "new $0($1...)">] abstract Create: updaters: ResizeArray<Updater> * effects: ResizeArray<Effect> -> AbstractActionHandler
