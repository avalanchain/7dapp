
module Settings

open Fable.Helpers.React
open Fable.Helpers.React.Props

open Shared
open Friends

open Chart
let inner (userState: UserState) = 
    let user = userState.User
    div [ ]
        [
            form [ Class "form-horizontal" ]
        [ 
          div [ Class "hr-line-dashed" ]
            [ ]
          
          div [ Class "form-group" ]
            [ label [ Class "col-lg-4 control-label" ]
                [ str "Account Name" ]
              div [ Class "col-lg-8" ]
                [ p [ Class "form-control-static" ]
                    [ str ( string user.AccountName) ] ] ]
          
            
       
          
          div [ Class "form-group" ]
            [ label [ Class "col-lg-4 control-label" ]
                [ str "First Name" ]
              div [ Class "col-lg-8" ]
                [ p [ Class "form-control-static" ]
                    [ str ( string user.Identity.FirstName) ] ] ]
          
                     
          div [ Class "form-group" ]
            [ label [ Class "col-lg-4 control-label" ]
                [ str "Last Name" ]
              div [ Class "col-lg-8" ]
                [ p [ Class "form-control-static" ]
                    [ str ( string user.Identity.LastName) ] ] ]
          div [ Class "hr-line-dashed" ]
            [ ]   
          div [ Class "form-group" ]
            [ label [ Class "col-lg-4 control-label" ]
                [ str "Email" ]
              div [ Class "col-lg-8" ]
                [ p [ Class "form-control-static" ]
                    [ str ( string user.Identity.Email) ] ] ]
          div [ Class "form-group" ]
            [ label [ Class "col-lg-4 control-label" ]
                [ str "Phone Number" ]
              div [ Class "col-lg-8" ]
                [ p [ Class "form-control-static" ]
                    [ str ( string user.Identity.PhoneNumber) ] ] ]

          div [ Class "hr-line-dashed" ]
            [ ]   

          div [ Class "form-group" ]
            [ label [ Class "col-lg-4 control-label" ]
                [ str "Country" ]
              div [ Class "col-lg-8" ]
                [ p [ Class "form-control-static" ]
                    [ str ( string user.Identity.Country) ] ] ]
        
 
          div [ Class "form-group" ]
            [ label [ Class "col-lg-4 control-label" ]
                [ str "Post Code" ]
              div [ Class "col-lg-8" ]
                [ p [ Class "form-control-static" ]
                    [ str ( string user.Identity.PostCode) ] ] ]

          div [ Class "hr-line-dashed" ]
            [ ] 
          
          div [ Class "form-group" ]
            [ label [ Class "col-lg-4 control-label" ]
                [ str "Date of Birth" ]
              div [ Class "col-lg-8" ]
                [ p [ Class "form-control-static" ]
                    [ str ( string user.Identity.DOB) ] ] ]
        
         
        
        
        
          // div [ Class "form-group" ]
          //   [ label [ Class "col-lg-2 control-label" ]
          //       [ str "Static control" ]
          //     div [ Class "col-lg-10" ]
          //       [ p [ Class "form-control-static" ]
          //           [ str ( string user) ] ] ]
          
            ]]

let settings (userState: UserState) = 
  div[ Class "row" ]
     [
        div [ Class "col-lg-6" ]
            [ div [ Class "ibox float-e-margins" ]
                [ div [ Class "ibox-title" ]
                    [ h5 [ ]
                        [ str "Settings"
                           ]
                      inner userState ] ] ]
        div[ Class "col-md-6" ]
                      [
                        referralInfo true
                        friendsBox (userState.Friends |> Seq.toList)
                      ]    
     ]
 