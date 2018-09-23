// ts2fable 0.6.1
module rec nodeosRawBlock
open System
open Fable.Core
open Fable.Import.JS

let [<Import("*","nodeosRawBlock")>] nodeosRawBlock: obj = jsNative
