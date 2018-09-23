namespace Shared

type Counter = int

module Route =
    /// Defines how routes are generated on server and mapped from client
    let builder typeName methodName =
        sprintf "/api/%s/%s" typeName methodName

type ICounterApi =
    { initialCounter : unit -> Async<Counter> }

/// Websockets

type UserId     = UserId    of string
type ChannelId  = ChannelId of string

type EncryptionKey  = EncryptionKey //of string
type EncryptionKeys = EncryptionKeys of Map<ChannelId, EncryptionKey> 


type UserIdentity = {
    FirstName   : string
    LastName    : string
    Email       : string
    DOB         : string
    Location    : string
    Address     : string
    PostCode    : string
    PhoneNumber : string
}

type User = {
    Id          : UserId 
    AccountName : string
    Identity    : UserIdentity
    Avatar      : Avatar
    Bio         : Bio
    Friends     : Set<Friend>
    Channels    : EncryptionKeys
}
and Avatar  = Avatar    of string
and Bio     = Bio       of string
and Friend  = Friend    of User


type Message = {    
    Time    : System.DateTime
    Content : MessageContent }
and MessageContent = 
    | Text  of string
    | Image of string
    | File  of string
    | Payment of Payment
and Payment = {
    Asset   : Asset
    Amount  : decimal
}
and Asset = Asset of string
and Dapp  = Dapp


type Channel = {
    Id      : ChannelId
    Messages: Message[]
}

type UserState = {
    User            : User
    Channels        : Channel list
    SuggestedFriends: Friend list
    SuggestedDapp   : Dapp list
}

// type Msgs =
//     | ClientMsg of (string * Message)
//     | SysMsg of Message

type RemoteClientMsg =
    | QueryConnected
    | SetState          of UserState
    // | GetUsers      of User list
    // | AddUser       of User
    // | RemoveUser    of string
    // | AddMsg        of Msgs
    // | AddMsgs       of Msgs list

type RemoteServerMsg = 
    // | SetUser       of User 
    // | SendMsg       of string 
    | UserConnected of Id: UserId


module Remote =
    let socketPath = "/socket"