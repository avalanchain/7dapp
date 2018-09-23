module Eos

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Import

printfn "eos: aaaa" 

[<Emit("window.eos")>]
let eos : obj = jsNative

printfn "eos: %A" eos