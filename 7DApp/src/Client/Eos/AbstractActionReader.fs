// ts2fable 0.6.1
module rec AbstractActionReader
open System
open Fable.Core
open Fable.Import.JS

open interfacesDemux

type [<AllowNullLiteral>] IExports =
    abstract AbstractActionReader: AbstractActionReaderStatic

/// Reads blocks from a blockchain, outputting normalized `Block` objects.
type [<AllowNullLiteral>] AbstractActionReader =
    abstract startAtBlock: float with get, set
    abstract onlyIrreversible: bool with get, set
    abstract maxHistoryLength: float with get, set
    abstract headBlockNumber: float with get, set
    abstract currentBlockNumber: float with get, set
    abstract isFirstBlock: bool with get, set
    abstract currentBlockData: Block option with get, set
    abstract blockHistory: ResizeArray<Block> with get, set
    /// Loads the head block number, returning an int.
    /// If onlyIrreversible is true, return the most recent irreversible block number
    abstract getHeadBlockNumber: unit -> Promise<float>
    /// <summary>Loads a block with the given block number</summary>
    /// <param name="blockNumber">- Number of the block to retrieve</param>
    abstract getBlock: blockNumber: float -> Promise<Block>
    /// Loads the next block with chainInterface after validating, updating all relevant state.
    /// If block fails validation, resolveFork will be called, and will update state to last block unseen.
    abstract nextBlock: unit -> Promise<Block * bool * bool>
    /// Move to the specified block.
    abstract seekToBlock: blockNumber: float -> Promise<unit>
    /// Incrementally rolls back reader state one block at a time, comparing the blockHistory with
    /// newly fetched blocks. Fork resolution is finished when either the current block's previous hash
    /// matches the previous block's hash, or when history is exhausted.
    abstract resolveFork: unit -> Promise<unit>
    /// When history is exhausted in resolveFork(), this is run to handle the situation. If left unimplemented,
    /// then only instantiate with `onlyIrreversible` set to true.
    abstract historyExhausted: unit -> unit

/// Reads blocks from a blockchain, outputting normalized `Block` objects.
type [<AllowNullLiteral>] AbstractActionReaderStatic =
    [<Emit "new $0($1...)">] abstract Create: ?startAtBlock: float * ?onlyIrreversible: bool * ?maxHistoryLength: float -> AbstractActionReader
