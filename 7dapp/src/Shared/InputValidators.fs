namespace Shared

module InputValidators =
    open System   
    open System.Text.RegularExpressions  
    
    let emailRules email = 
        [   String.IsNullOrWhiteSpace(email), "Please enter a valid email"
            email.Length > 25, "Expected <20 characters"
            // userName.Trim().Length < 5, "'Email' must at least have 5 characters"
            Regex("""^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$""").IsMatch(email) |> not, "Incorrect email address"
             ]
    let passwordRules (password: string) = 
        [   //String.IsNullOrWhiteSpace(password), "Password cannot be empty"
            password.Trim().Length < 8, "Expected 8+ characters"
            password.Length > 20, "Expected <20 characters"
            Regex("""(?=.*[a-z])""").IsMatch(password) |> not, "Expected at least 1 lowercase character"
            Regex("""(?=.*[A-Z])""").IsMatch(password) |> not, "Expected at least 1 uppercase character"
            Regex("""(?=.*[\d])""").IsMatch(password) |> not, "Expected at least 1 digit character"
            Regex("""(?=.*[\W])""").IsMatch(password) |> not, "Expected at least 1 special character"
            ]

    let passwordConfRules confPassword password = 
        [ password <> confPassword, "Passwords don't match" ]
        @ passwordRules password

    let private processRules = List.filter fst >> List.map snd

    let emailValidation = emailRules >> processRules
    let passwordValidation = passwordRules >> processRules
    let passwordConfValidation confPassword = passwordConfRules confPassword >> processRules
