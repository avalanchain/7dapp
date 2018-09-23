module StateManagement

open FSharp.Data

open Shared
open Shared.Fake
open System

type PeopleData = CsvProvider<"People.csv">

let rows = PeopleData.GetSample().Rows

let users = 
    [ for r in rows -> 
        {
            Id          = UserId ("#" + r.AccountName) 
            AccountName = "@" + r.AccountName
            Identity    = {
                            FirstName   = r.FirstName
                            LastName    = r.LastName
                            Email       = r.Email
                            DOB         = (string r.DOB)
                            Country     = r.Location
                            Address     = r.Address
                            PostCode    = string r.PostCode
                            PhoneNumber = string r.PhoneNumber
                        }
            Avatar      = Avatar (r.Avatar)
            Bio         = Bio (r.Bio)
            // Friends     = set []
            // Channels    = EncryptionKeys Map.empty 
        } ]
let friends = users |> List.map Friend |> set 

let friends1 = friends |> Set.toArray |> Array.filter(fun (Friend f) -> f.AccountName.Length % 2 = 0 )

let friends2 = friends |> Set.toArray |> Array.filter(fun (Friend f) -> f.AccountName.Length % 2 <> 0 )
let friends3 = friends |> Set.toArray |> Array.filter(fun (Friend f) -> f.AccountName.Length % 3 = 0 )

let friends4 = friends |> Set.toArray |> Array.filter(fun (Friend f) -> f.AccountName.Length % 3 <> 0 )

let channel1  = {
    Id              = "12d4sdsd" |> ChannelId
    Name            = "Secret EOS Channel"
    Participants    = friends1 |> Array.toList
    Messages        = [| |]
    EncryptionKey   = "hsurwyru-1dw-dwdw-dw112132d2d4g4t4eg" |> EncryptionKey
}

let channel2  = {
    Id              = "3434d4sdsd" |> ChannelId
    Name            = "Popular DApss in EOS"
    Participants    = friends2 |> Array.toList
    Messages        = [| |]
    EncryptionKey   = "hsurwyru-1dw-dwdw-dw112132d2d4g4tjh0" |> EncryptionKey
}

let channel3  = {
    Id              = "676765d4sdsd" |> ChannelId
    Name            = "Happy Birthday!!!"
    Participants    = friends3 |> Array.toList
    Messages        = [| |]
    EncryptionKey   = "hsurwyru-1dw-dwdw-dw112132d2d4g4tvf0" |> EncryptionKey
}
let channel4  = {
    Id              = "676765d4sdsd" |> ChannelId
    Name            = "Very Important Things"
    Participants    = friends4 |> Array.toList
    Messages        = [| |]
    EncryptionKey   = "hsurwyru-1dw-dwdw-dw11efwef344324t330" |> EncryptionKey
}

let channels = [|channel1.Id, channel1; channel2.Id, channel2;channel3.Id, channel3;channel4.Id, channel4;|] |> Map.ofArray
let dataFeed: FeedItem[] =
    [|
        {   Avatar      = "../img/a8.jpg"
            Name        = "Monica Smith"
            Time        = "Today 5:61 pm - 12.06.2018"
            ShortTime   = "1m ago"
            Action      = "purchased Wizard#20382 for 20 eos." }
        {   Avatar      = "../img/a1.jpg"
            Name        = "Mark Johnson"
            Time        = "Today 5:62 pm - 12.06.2018"
            ShortTime   = "1m ago"
            Action      = "edited an article on the Best Hackathons 2018." }
        {   Avatar      = "../img/a3.jpg"
            Name        = "Janet Rosowski"
            Time        = "Today 5:63 pm - 12.06.2018"
            ShortTime   = "1m ago"
            Action      = "won 6000 EOS in EOSbet." }
        {   Avatar      = "../img/a6.jpg"
            Name        = "Kim Smith"
            Time        = "Today 5:65 pm - 12.06.2018"
            ShortTime   = "2m ago"
            Action      = "posted a new blog." }
    |]
