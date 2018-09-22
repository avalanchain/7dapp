// ts2fable 0.6.1
module rec interfacesDemux
open System
open Fable.Core
open Fable.Import.JS


type [<AllowNullLiteral>] Block =
    abstract actions: ResizeArray<Action> with get, set
    abstract blockInfo: BlockInfo with get, set

type [<AllowNullLiteral>] IndexState =
    abstract blockNumber: float with get, set
    abstract blockHash: string with get, set

type [<AllowNullLiteral>] BlockInfo =
    abstract blockHash: string with get, set
    abstract blockNumber: float with get, set
    abstract previousBlockHash: string with get, set
    abstract timestamp: DateTime with get, set

type [<AllowNullLiteral>] Action =
    abstract ``type``: string with get, set
    abstract payload: obj option with get, set

type [<AllowNullLiteral>] Updater =
    abstract actionType: string with get, set
    abstract updater: (obj option -> obj option -> BlockInfo -> obj option -> unit) with get, set

type [<AllowNullLiteral>] Effect =
    abstract actionType: string with get, set
    abstract effect: (obj option -> obj option -> BlockInfo -> obj option -> unit) with get, set
