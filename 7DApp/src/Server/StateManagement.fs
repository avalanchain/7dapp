module StateManagement

open FSharp.Data

open Shared

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