module Client.FormHelpers

open Fable.Helpers.React
open Fable.Helpers.React.Props

open Fable
open Fable.Core
open Shared.ViewModels
open Fable.DateFunctions
open System
open Fable.Import.React
open Fable.Core.JsInterop
open ReactBootstrap
open Client.Helpers
open ReactBootstrap.Radio
open ReactBootstrap.Checkbox
open System.Collections.Generic

type FormElement =
    | Input of InputType
    | Select of (string * string) list 
    | Radio
    | Checkbox
    | Textarea
    | Static
and InputType =
    | Email 
    | Text
    | Date
    | Submit
    | Number
    | File


let inputType inType =
    (match inType with 
                    | Email     -> "email"
                    | Text      -> "text"
                    | Date      -> "date"
                    | Submit    -> "submit"
                    | Number    -> "number"
                    | File      -> "file")

let formHorizontal body = comF form (fun o -> 
                          //  o.className <- Some "panel-body" 
                           o.horizontal <- Some true )
                           body 

let inputControl inType (v: _ option) = 
    comF formControl (fun o ->  o.``type`` <- Some (inputType inType)
                                o.value <- !!v |> Option.map U2.Case1)[]

let selectControl optionList = comF formControl (fun o ->  o.componentClass <- Some "select")
                                [ for name, value in optionList ->
                                    option [ Value name ][ str value ]
                                    // comF option (fun o ->  o.componentClass <- Some )
                                ]


let labelG labelText = comF controlLabel  (fun o -> o.className <- Some "col-sm-2" )
                            [ str labelText ]

let inputG (element:FormElement) v helpText = 
    [
        (
        match element with 
        | Input inputType       -> inputControl inputType v
        | Select optionList     -> selectControl optionList 
        | Radio                 -> inputControl InputType.Text v
        | Checkbox              -> inputControl InputType.Text v
        | Textarea              -> inputControl InputType.Text v
        | Static                -> inputControl InputType.Text v
        )
        span [ Class "help-block m-b-none text-muted" ]
             [ str helpText ]
   ]

let fGroupI (element:FormElement) v labelText helpText = 
    
         [
           labelG labelText
           div [ Class "col-sm-10"]
               (inputG element v helpText) ]
           
let fGroupO (element:FormElement) v labelText helpText = 
    comE formGroup (fGroupI element v labelText helpText)


let fGroupEmpty body = 
    comE formGroup body