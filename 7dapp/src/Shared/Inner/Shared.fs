namespace Shared

open System
open Auth
open Result
open Fable

module Crypto = 
    type Kid = uint16
    type PublicKey = PublicKey of obj 
    type PrivateKey = PrivateKey of obj 
    type KeyPair = {
        PublicKey: PublicKey
        PrivateKey: PrivateKey
        Kid: Kid
    }
    type KeyStorage = Kid -> KeyPair

    type [<Interface>] ICryptoContext =
        abstract getString  : byte[] -> string
        abstract getBytes   : string -> byte[]
        abstract toHex      : byte[] -> string
        abstract fromHex    : string -> byte[]
        abstract toJson<'T>     : 'T -> string
        abstract fromJson<'T>   : string -> 'T
        abstract hash       : byte[] -> byte[]
        abstract hashString : string -> byte[]

    type Pos = uint64
    type PageSize = uint32

    type JwtAlgo = Ed25519
    type JwtType = JWT
    type JwtKeyId = Kid
    type JwtTokenHeader = {
        alg: JwtAlgo
        typ: JwtType
        kid: JwtKeyId
        pos: Pos option     // Optional position
        enc: bool           // Encoding
    } with static member Create kid pos = { alg = Ed25519; typ = JWT; kid = kid; pos = pos; enc = false }

    type TokenRef = { Cid: string }

    type KeyRing = KeyRing
        with interface IDisposable with member __.Dispose() = ()

    type KeyVaultEntry = {
        Kid: JwtKeyId
        KeyRing: KeyRing
    }   with interface IDisposable with member __.Dispose() = (__.KeyRing :> IDisposable).Dispose()

    type IKeyVault =
        abstract member Get: JwtKeyId -> KeyVaultEntry option
        abstract member Active: KeyVaultEntry 

    module Simple = 
        type KeyVault (entries: KeyVaultEntry seq) = 
            let entries = entries |> Seq.toArray 
            let keyEntries = entries |> Seq.map(fun kve -> kve.Kid, kve) |> Map.ofSeq
            let active = entries |> Array.head
            interface IKeyVault with 
                member __.Get kid = keyEntries |> Map.tryFind kid 
                member __.Active = active




    type IntegrityError =
        | SigningError of SigningError
        | VerificationError of VerificationError
    and SigningError =
        | KeyIdNotFould of JwtKeyId
        | NoPrivateKeyAvailable of JwtKeyId
        | SigningFailed
    and VerificationError =
        | InvalidTokenFormat
        | InvalidTokenHeaderFormat
        | KeyIdNotFound of JwtKeyId
        | SignatureVerificationFailed    

    let (+.+) (l: string) r = l + "." + r


module ChainDefs =
    open Crypto

    type Hash = { Hash: string } // TODO: Redo this
    type Sig = { Sig: string } // TODO: Redo this

    type Uid = 
        | UUID of Guid
        | Hash of Hash
        | Sig of Sig
        override __.ToString() = match __ with 
                                    | UUID g -> g.ToString().Replace("-", String.Empty)
                                    | Hash h -> h.Hash
                                    | Sig s  -> s.Sig

    type NodeRef = { Nid: string }
    type MasterNodeRef = { MNid: string }

    type NodeProof = { NRef: NodeRef; Sig: Sig }
    type MasterNodeProof = { MRef: MasterNodeRef; Sig: Sig }

    type Asset = { Asset: string }

    // type DVVClock = {
    //     Nodes: Map<NodeRef, Pos>
    // }

    type Json = Json of string
    type JsFunc = string // TODO
    type Func1 = Jsf1 of JsFunc
    type Func2 = Jsf2 of JsFunc

    type Derivation =
        | Fork
        | Map of Func1
        | Filter of Func1
        | Fold of Func2 * init: Json
        | Reduce of Func2
        | FilterFold of filter: Func1 * folder: Func2
        | GroupBy of groupper: Func1 * max: uint32

    type ChainRef = TokenRef
    type ChainId  = ChainId of ChainRef

    [<RequireQualifiedAccess>] 
    type ChainType = 
        | New
        | Derived of cr: ChainRef * pos: Pos * Derivation

    [<RequireQualifiedAccess>] 
    type Encryption = // TODO: expand
        | None

    [<RequireQualifiedAccess>] 
    type Compression = 
        | None
        | Deflate

    type ChainDef = {
        algo: JwtAlgo
        uid: Uid
        chainType: ChainType
        encryption: Encryption
        compression: Compression 
    } with 
        member __.Ref = { Cid = string __.uid }
        member __.ChainId = ChainId (__.Ref)

    type JwtToken<'T> = {
        Token: string
        Json: string
        Ref: TokenRef
        Payload: 'T
        Header: JwtTokenHeader
        Signature: string
    }

    type JwtToHeader = unit -> JwtTokenHeader
    type JwtFromHeader = Map<string, obj> -> JwtTokenHeader

    
    
    type ChainDefToken = JwtToken<ChainDef>
    let internal chainDefToHeader keyPair = JwtTokenHeader.Create keyPair.Kid None
// //    let internal chainDefFromHeader: JwtFromHeader = fun dc -> { kid = Convert.ToUInt16(dc.["kid"]); pos = -1L; alg = JwtAlgoAsym.ES384.ToString(); enc = false }

// //    let toChainToken keyPair = fun pos ->  toJwt (fun () -> { kid = keyPair.Kid; pos = pos; alg = JwtAlgoAsym.ES384.ToString(); enc = false }) keyPair
//     let toChainDefToken keyPair = toJwt keyPair (chainDefToHeader keyPair) 
//     let fromChainDefToken keyVault = fromJwt<ChainDef> keyVault


    type ChainItemToken<'T> = JwtToken<'T>
    let internal chainItemToHeader keyPair pos = JwtTokenHeader.Create keyPair.Kid (Some pos)
// //    let internal chainItemFromHeader: JwtFromHeader = fun dc -> { kid = Convert.ToUInt16(dc.["kid"]); pos = Convert.ToInt64(dc.["pos"]); alg = JwtAlgoAsym.ES384.ToString(); enc = false }

//     let toChainItemToken keyPair pos = toJwt keyPair (chainItemToHeader keyPair pos)
//     let fromChainItemToken<'T> keyVault = fromJwt<'T> keyVault

    let toRef (ctx: ICryptoContext) (str: string) = { Cid = str |> ctx.hashString |> ctx.toHex } 

    type SignedProof<'T> = { 
        Value: 'T
        Proof: string 
    }

    let newChain() = {
        algo        = JwtAlgo.Ed25519
        uid         = Guid.NewGuid() |> UUID
        chainType   = ChainType.New
        encryption  = Encryption.None
        compression = Compression.Deflate 
    }

open ChainDefs

    // let toJwt (ctx: ICryptoContext) (kve: KeyVaultEntry) header (payload: 'T) = result {
    //     let! token, header, json, signature = ctx.sign kve header payload
    //     return {Token = token
    //             Json = json
    //             Ref = signature |> toRef
    //             Payload = payload 
    //             Header = header
    //             Signature = signature }
    // }

    // let fromJwt<'T> (kv: IKeyVault) verify (token: string) = result {
    //     let! token, header, payload, signature = unpack verify kv token
    //     return {Token = token
    //             Json = payload
    //             Ref = signature |> toRef 
    //             Payload = fromJson<'T> payload 
    //             Header = header
    //             Signature = signature }
    // }


module ViewModels = 
    open Crypto 

    type Customer = {
        Id          : Guid
        FirstName   : string
        LastName    : string
        EthAddress  : string
        Avatar      : string
        Email       : string
    }


    module ChainNetwork = 

        module Network =
            type Endpoint = {
                IP: string
                Port: uint16
            }

        open Network

        module TrustCircles = 
            type TrustCircle = {
                TCId: Uid
            } 

        type AccountId      = AccountId of string
        type AccountVClock  = AccountId * Pos

        let nextAClock ((accId, pos): AccountVClock) = accId, pos + 1UL  

        type Tr<'T> = Tr of 'T
        type TransactionInfo<'T> = {
            AClock  : AccountVClock
            ChainId : ChainId
            Tr      : Tr<'T>
        }

        type ACClusterId = Uid

        type ACCluster = {
            CId: ACClusterId
        }

        type ACNodeId = 
            | NR  of NodeRef 
            | MNR of MasterNodeRef  

        type ACNode = {
            NId     : ACNodeId
            Chains  : Set<ChainDef>
            Endpoint: Endpoint
            Clusters: ACClusterId list
            State   : ACNodeState 
        }
        and ACNodeState = Active | Passive | Banned

        type ACClusterMembership = {
            Cluster : ACCluster
            Nodes   : Map<ACNodeId, ACNode> 
        }

        type ACProcess = {
            ProcessId: Uid
            Clusters: Set<ACCluster> 
        }

        module NodeManagement =
            type ChainStatus = 
                | Active 
                | Passive
                | Stopped
                | Blocked of Reason: string 
                | Banned

            type ChainState = {
                Def     : ChainDef
                Status  : ChainStatus
                Pos     : Pos
            }

            type Commands = 
                | AddChain      of Nid: ACNodeId * Chain    : ChainDef
                | RegisterChain of Nid: ACNodeId * ChainRef : ChainRef
                | StopChain     of Nid: ACNodeId * ChainRef : ChainRef
                | ListChains    of Map<ChainRef, ChainState>

            type ACNodeChainStates = {
                NodeId: ACNodeId
                Chains: Map<ChainDef, ChainState>
            }

        module ClusterManagement =
            type Commands = 
                | AddNode       of ClusterId: ACClusterId * Node: ACNode
                | RemoveNode    of ClusterId: ACClusterId * Nid : ACNodeId
                | ListNodes     of ACNode list


open ViewModels.ChainNetwork.NodeManagement


module Route =
    /// Defines how routes are generated on server and mapped from client
    let builder typeName methodName =
        sprintf "/api/%s/%s" typeName methodName

    let wsBridgeEndpoint = "/wsbridge"    

open ViewModels.ChainNetwork

/// A type that specifies the communication protocol for client and server
/// Every record field must have the type : 'a -> Async<'b> where 'a can also be `unit`
/// Add more such fields, implement them on the server and they be directly available on client
type ICabinetProtocol = {
    getCustomer             : SecureVoidRequest                 -> Async<ServerResult<ViewModels.Customer>> 
    getClusters             : SecureVoidRequest                 -> Async<ServerResult<ACCluster list>>
    getClusterById          : SecureRequest<ACClusterId>        -> Async<ServerResult<ACCluster>>
    getClusterMembership    : SecureRequest<ACClusterId>        -> Async<ServerResult<ACClusterMembership>>

    getNodeById             : SecureRequest<ACNodeId>           -> Async<ServerResult<ACNode>>
    getNodeMembership       : SecureRequest<ACNodeId>           -> Async<ServerResult<ACClusterId list>>
    getNodeChainIds         : SecureRequest<ACNodeId>           -> Async<ServerResult<Set<ChainId>>>
    getNodeChainDefs        : SecureRequest<ACNodeId>           -> Async<ServerResult<ChainDef list>>
    getNodeChain            : SecureRequest<ACNodeId * ChainId> -> Async<ServerResult<ChainState>>
    getNodeChains           : SecureRequest<ACNodeId>           -> Async<ServerResult<ChainState list>>

    getChainDefById         : SecureRequest<ChainId>            -> Async<ServerResult<ChainDef>>
}

module WsBridge =
    // Messages processed on the server
    type ServerMsg =
        | Closed 
        | ConnectUser of AuthToken
        | DisconnectUser
    //Messages processed on the client
    type BridgeMsg =
        | BS of BridgeServerMsg
        | BC of BridgeClientMsg
    and BridgeServerMsg =
        | ConnectUserOnServer       of AuthToken
        | DisconnectUserOnServer
    and BridgeClientMsg =
        | ErrorResponse             of ServerError * Request: ServerMsg
        | ConnectionLost
        | ServerConnected

        | UserConnected             of AuthToken
        // | NodeStateChanged          of ACNodeId * ACNodeState
        // | ChainStateChanged         of ChainState
    