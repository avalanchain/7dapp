namespace Shared
open System.Threading.Tasks

module Utils =

    open System.Text.RegularExpressions
    open FSharp.Reflection
    open Fable.Core

    let join (p: Map<'a,'b>) (q: Map<'a,'b>) = Map(Seq.concat [ (Map.toSeq p) ; (Map.toSeq q) ])

    let splitOnCapital caption = Regex.Replace(caption, "([a-z])([A-Z])", "$1 $2")

    let [<PassGenerics>] getUnionCaseInfo (x:'a) = FSharpValue.GetUnionFields(x, typeof<'a>) |> fst

    let [<PassGenerics>] getUnionCase<'T> (case: UnionCaseInfo) = FSharpValue.MakeUnion(case, [||]) :?> 'T

    let [<PassGenerics>] getUnionCases<'t> = 
        FSharpType.GetUnionCases typeof<'t>
        |> List.ofSeq

    let [<PassGenerics>] allUnionCases<'T> =
        FSharpType.GetUnionCases(typeof<'T>)
        |> Array.map (fun case -> FSharpValue.MakeUnion(case, [||]) :?> 'T)
        |> Array.toList

    let [<PassGenerics>] getUnionCaseName (x:'a) = 
        match FSharpValue.GetUnionFields(x, typeof<'a>) with
        | case, _ -> case.Name  

    let [<PassGenerics>] getUnionCaseNameSplit x = x |> getUnionCaseName |> splitOnCapital

    ///Returns the case names of union type 'ty.
    let [<PassGenerics>] getUnionCaseNames<'ty> = 
        FSharpType.GetUnionCases(typeof<'ty>) |> Array.map (fun info -> info.Name) |> Array.toList

    let [<PassGenerics>] getUnionCaseNamesSplit<'ty> = getUnionCaseNames<'ty> |> (List.map splitOnCapital)

    let [<PassGenerics>] getUnionCaseFromString<'a> (s:string) =
        match FSharpType.GetUnionCases typeof<'a> |> Array.filter (fun case -> case.Name = s) with
        |[|case|] -> Some(FSharpValue.MakeUnion(case,[||]) :?> 'a)
        |_ -> None


module Result =
    let inline ofOption error = function Some s -> Ok s | None -> Error error

    let inline isOk r = match r with | Ok _ -> true | Error _ -> false
    let inline isError r = r |> isOk |> not

    type ResultBuilder() =
        member __.Return(x) = Ok x

        member __.ReturnFrom(m: Result<_, _>) = m

        member __.Bind(m, f) = Result.bind f m
        /// Binding to (Error, Option<'T>) tuple in order to make interop with functions returning Option<'T> easier
        /// Having error as the first parameter is surprisingly more natural in usage
        member __.Bind((error, m): ('E * Option<'T>), f) = m |> ofOption error |> Result.bind f

        member __.Combine(m, f) = Result.bind f m

        member __.Delay(f: unit -> _) = f

        member __.Run(f) = f()

        member __.TryWith(m, h) =
            try __.ReturnFrom(m)
            with e -> h e

        member __.TryFinally(m, compensation) =
            try __.ReturnFrom(m)
            finally compensation()

        member __.Using(res:#System.IDisposable, body) =
            __.TryFinally(body res, fun () -> match res with null -> () | disp -> disp.Dispose())

        member __.While(guard, f) =
            if not (guard()) then Ok () else
            do f() |> ignore
            __.While(guard, f)

        member __.For(sequence:seq<_>, body) =
            __.Using(sequence.GetEnumerator(), fun enum -> __.While(enum.MoveNext, __.Delay(fun () -> body enum.Current)))

    let result = new ResultBuilder()
