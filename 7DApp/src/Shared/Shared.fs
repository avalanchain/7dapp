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
    Country     : string
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
    Content : MessageContent
    Action  : string 
    User       : User
    Time       : string
    ShortTime  : string
    }
and MessageContent = 
    | Text  of string
    | Image of string
    | File  of string
    | Payment of Payment

and Invest = {
    Text       : string
    Money      : decimal
    Dapp       : Dapp
    Action     : string 
    User       : User
    Time       : string
    ShortTime  : string

}
and Image = {
    Asset   : Asset
    Amount  : decimal
}
and Payment = {
    Action     : string 
    Asset      : Asset
    Amount     : decimal
    Money      : decimal
    Dapp       : Dapp
    User       : User
    Time       : string
    ShortTime  : string
}
and Edit = {
    Action     : string 
    Amount     : decimal
    Dapp       : Dapp
    User       : User
    Text       : string
    Time       : string
    ShortTime  : string
    }
and Game = {
    Action     : string 
    Amount     : decimal
    Money      : decimal
    Dapp       : Dapp
    User       : User
    Text       : string
    Time       : string
    ShortTime  : string
    }
and Trade = {
    Action     : string 
    Money      : decimal
    Dapp       : Dapp
    User       : User
    ToMoney      : decimal
    Time       : string
    ShortTime  : string
    }

and Asset = Asset of string
and Dapp  = Dapp of string


type Channel = {
    Id          : ChannelId
    Participants: Friend 
    Messages    : Message[]
}

type UserState = {
    User            : User
    Channels        : Channel list
    SuggestedFriends: Friend list
    SuggestedDapp   : Dapp list
    Users           : User list
}

// type Msgs =
//     | ClientMsg of (string * Message)
//     | SysMsg of Message

type FeedItem = {
    Avatar      : string
    Name        : string
    Time        : string
    ShortTime   : string
    Action      : string
} 

type RemoteClientMsg =
    | QueryConnected
    | SetState          of UserState
    | AddFeedItem       of FeedItem
    | ChannelUpdated    of Channel

type RemoteServerMsg = 
    | UserConnected of Id: UserId


module Remote =
    let socketPath = "/socket"


module Fake = 

    let userIdentity = {
        FirstName   = "Vasily"
        LastName    = "Kuznetsov"
        Email       = "darkvasyak@gmail.com"
        DOB         = "26/11/1992"
        Country     = "RU"
        Address     = "B. Marienskaya, 3"
        PostCode    = "129085"
        PhoneNumber = "+79163549100"
    }

    let user = {
        Id          = UserId "#darkvasyak25" 
        AccountName = "@darkvasyak25"
        Identity    = userIdentity
        Avatar      = Avatar "Avatar.jpg"
        Bio         = Bio "Vasily is a professional blockchain entrepreneur who loves EOS and wants to make the World a better place"
        Friends     = set []
        Channels    = EncryptionKeys Map.empty 
    }

    let userState = {
        User            = user
        Channels        = []
        SuggestedFriends= []
        SuggestedDapp   = []
        Users           = []
    }

