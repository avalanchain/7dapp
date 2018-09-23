module StateManagement

open FSharp.Data

open Shared
open Shared.Fake

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
            Friends     = set []
            Channels    = EncryptionKeys Map.empty 
        } ]

let dataFeed: FeedItem[] =
    [|
        {   Avatar      = "../img/avatar.jpg"
            Name        = "Monica Smith"
            Time        = "Today 5:60 pm - 12.06.2014"
            ShortTime   = "5m ago"
            Action      = "posted a new blog." }
        {   Avatar      = "../img/avatar.jpg"
            Name        = "Mark Johnson"
            Time        = "Today 5:60 pm - 12.06.2014"
            ShortTime   = "5m ago"
            Action      = "posted a new blog." }
        {   Avatar      = "../img/avatar.jpg"
            Name        = "Janet Rosowski"
            Time        = "Today 5:60 pm - 12.06.2014"
            ShortTime   = "5m ago"
            Action      = "posted a new blog." }
        {   Avatar      = "../img/avatar.jpg"
            Name        = "Kim Smith"
            Time        = "Today 5:60 pm - 12.06.2014"
            ShortTime   = "5m ago"
            Action      = "posted a new blog." }
    |]
