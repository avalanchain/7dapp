// ts2fable 0.6.1
module rec NodeosBlock
open System
open Fable.Core
open Fable.Import.JS

open interfacesDemux
open interfacesDemuxEos

type [<AllowNullLiteral>] IExports =
    abstract NodeosBlock: NodeosBlockStatic

type [<AllowNullLiteral>] NodeosBlock =
    inherit Block
    abstract actions: ResizeArray<EosAction> with get, set
    abstract blockInfo: BlockInfo with get, set
    abstract collectActionsFromBlock: rawBlock: obj option -> ResizeArray<EosAction>
    abstract flattenArray: obj with get, set

type [<AllowNullLiteral>] NodeosBlockStatic =
    [<Emit "new $0($1...)">] abstract Create: rawBlock: obj option -> NodeosBlock
