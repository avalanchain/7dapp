namespace Shared

type Counter = int

module Route =
    /// Defines how routes are generated on server and mapped from client
    let builder typeName methodName =
        sprintf "/api/%s/%s" typeName methodName

/// A type that specifies the communication protocol between client and server
/// to learn more, read the docs at https://zaid-ajaj.github.io/Fable.Remoting/src/basics.html
type ICounterApi =
    { initialCounter : unit -> Async<Counter> }

/// Websockets

type User = { Name : string }
type Message = { Time : System.DateTime; Content: string }

type Msgs =
    | ClientMsg of (string * Message)
    | SysMsg of Message

type RemoteClientMsg =
    | QueryConnected
    | GetUsers      of User list
    | AddUser       of User
    | RemoveUser    of string
    | AddMsg        of Msgs
    | AddMsgs       of Msgs list

type RemoteServerMsg = 
    | SetUser of User 
    | SendMsg of string 
    | UserConnected


module Remote =
    let socketPath = "/socket"