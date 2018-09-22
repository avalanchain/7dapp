// ts2fable 0.6.1
module rec interfaces
open System
open Fable.Core
open Fable.Import.JS

type Action = Demux.Action

type [<AllowNullLiteral>] EosAuthorization =
    abstract actor: string with get, set
    abstract permission: string with get, set

type [<AllowNullLiteral>] EosPayload =
    abstract account: string with get, set
    abstract actionIndex: float with get, set
    abstract authorization: ResizeArray<EosAuthorization> with get, set
    abstract data: obj option with get, set
    abstract name: string with get, set
    abstract transactionId: string with get, set

type [<AllowNullLiteral>] EosAction =
    inherit Action
    abstract payload: EosPayload with get, set
