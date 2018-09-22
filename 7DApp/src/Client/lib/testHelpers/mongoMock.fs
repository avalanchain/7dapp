// ts2fable 0.6.1
module rec mongoMock
open System
open Fable.Core
open Fable.Import.JS

let [<Import("*","mongoMock")>] MongoClient: obj = jsNative
