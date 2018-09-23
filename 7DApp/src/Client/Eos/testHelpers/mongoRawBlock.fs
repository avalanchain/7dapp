// ts2fable 0.6.1
module rec mongoRawBlock
open System
open Fable.Core
open Fable.Import.JS

let [<Import("*","mongoRawBlock")>] mongoRawBlock: obj = jsNative
