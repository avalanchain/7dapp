// ts2fable 0.6.1
module rec MongoActionReader
open System
open Fable.Core
open Fable.Import.JS

type AbstractActionReader = Demux.AbstractActionReader
type MongoBlock = __MongoBlock.MongoBlock

type [<AllowNullLiteral>] IExports =
    abstract MongoActionReader: MongoActionReaderStatic

/// Implementation of an ActionReader that reads blocks from a mongodb instance.
type [<AllowNullLiteral>] MongoActionReader =
    inherit AbstractActionReader
    abstract mongoEndpoint: string with get, set
    abstract startAtBlock: float with get, set
    abstract onlyIrreversible: bool with get, set
    abstract maxHistoryLength: float with get, set
    abstract dbName: string with get, set
    abstract mongodb: obj with get, set
    abstract initialize: unit -> Promise<unit>
    abstract getHeadBlockNumber: unit -> Promise<float>
    abstract getBlock: blockNumber: float -> Promise<MongoBlock>
    abstract throwIfNotInitialized: obj with get, set

/// Implementation of an ActionReader that reads blocks from a mongodb instance.
type [<AllowNullLiteral>] MongoActionReaderStatic =
    [<Emit "new $0($1...)">] abstract Create: ?mongoEndpoint: string * ?startAtBlock: float * ?onlyIrreversible: bool * ?maxHistoryLength: float * ?dbName: string -> MongoActionReader
