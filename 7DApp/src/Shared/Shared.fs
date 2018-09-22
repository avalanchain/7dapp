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

type Color =
    | Red
    | Green
    | Blue
    | Black

type User = {Name : string; Color: Color}
type Message = {Time : System.DateTime; Content: string}

type Msgs =
  | ClientMsg of (string*Message)
  | SysMsg of Message

type RemoteClientMsg =
    | QueryConnected
    | GetUsers of User list
    | NameStatus of bool
    | AddUser of User
    | RemoveUser of string
    | AddMsg of Msgs
    | AddMsgs of Msgs list
    | ColorChange of (string*Color)

type RemoteServerMsg = SetUser of User | ChangeColor of Color | SendMsg of string | UsersConnected


module Remote =
    let socketPath = "/socket"