// ts2fable 0.6.1
module rec NodeosActionReader
open System
open Fable.Core
open Fable.Import.JS

type AbstractActionReader = Demux.AbstractActionReader
type NodeosBlock = __NodeosBlock.NodeosBlock

type [<AllowNullLiteral>] IExports =
    abstract NodeosActionReader: NodeosActionReaderStatic

/// Reads from an EOSIO nodeos node to get blocks of actions.
/// It is important to note that deferred transactions will not be included,
/// as these are currently not accessible without the use of plugins.
type [<AllowNullLiteral>] NodeosActionReader =
    inherit AbstractActionReader
    abstract startAtBlock: float with get, set
    abstract onlyIrreversible: bool with get, set
    abstract maxHistoryLength: float with get, set
    abstract requestInstance: obj option with get, set
    abstract nodeosEndpoint: string with get, set
    /// Returns a promise for the head block number.
    abstract getHeadBlockNumber: ?numRetries: float * ?waitTimeMs: float -> Promise<float>
    /// Returns a promise for a `NodeosBlock`.
    abstract getBlock: blockNumber: float * ?numRetries: float * ?waitTimeMs: float -> Promise<NodeosBlock>
    abstract httpRequest: ``method``: string * requestParams: obj option -> Promise<obj option>

/// Reads from an EOSIO nodeos node to get blocks of actions.
/// It is important to note that deferred transactions will not be included,
/// as these are currently not accessible without the use of plugins.
type [<AllowNullLiteral>] NodeosActionReaderStatic =
    [<Emit "new $0($1...)">] abstract Create: ?nodeosEndpoint: string * ?startAtBlock: float * ?onlyIrreversible: bool * ?maxHistoryLength: float * ?requestInstance: obj option -> NodeosActionReader
