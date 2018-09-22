// ts2fable 0.6.1
module rec MongoBlock
open System
open Fable.Core
open Fable.Import.JS

type Block = Demux.Block
type BlockInfo = Demux.BlockInfo
type EosAction = __interfaces.EosAction

type [<AllowNullLiteral>] IExports =
    abstract MongoBlock: MongoBlockStatic

type [<AllowNullLiteral>] MongoBlock =
    inherit Block
    abstract actions: ResizeArray<EosAction> with get, set
    abstract blockInfo: BlockInfo with get, set
    abstract collectActionsFromBlock: ?rawBlock: obj option -> ResizeArray<EosAction>
    abstract flattenArray: obj with get, set

type [<AllowNullLiteral>] MongoBlockStatic =
    [<Emit "new $0($1...)">] abstract Create: rawBlock: obj option -> MongoBlock
