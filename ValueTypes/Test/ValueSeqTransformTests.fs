namespace Peregrine.ValueTypes.Test

open NUnit.Framework
open FsUnit
open Peregrine.ValueTypes

[<RequireQualifiedAccess; TestFixture>]
module ValueSeqTransformTests =

    //
    // ValueSeq.skip tests
    //

    [<Test>]
    let ``Test skipping over a longer than n sequence`` () =
        [| 1; 2; 4; 8 |]
        |> ValueSeq.ofArray
        |> ValueSeq.skip 2
        |> ValueSeq.toSeq
        |> should equal [ 4; 8 ]

    [<Test>]
    let ``Test skipping over a shorter than n sequence`` () =
        [| 1; 2; 4; 8 |]
        |> ValueSeq.ofArray
        |> ValueSeq.skip 6
        |> ValueSeq.toSeq
        |> should be Empty

    [<Test>]
    let ``Test a skip of zero`` () =
        [| 1; 2; 4; 8 |]
        |> ValueSeq.ofArray
        |> ValueSeq.skip 0
        |> ValueSeq.toSeq
        |> should equal [ 1; 2; 4; 8 ]

    [<Test>]
    let ``Test skpping over an empty sequnce`` () =
        []
        |> ValueSeq.ofList
        |> ValueSeq.skip 1
        |> ValueSeq.toSeq
        |> should be Empty

    //
    // ValueSeq.truncate tests
    //

    [<Test>]
    let ``Test truncating over a longer than n sequence`` () =
        [| 1; 2; 4; 8 |]
        |> ValueSeq.ofArray
        |> ValueSeq.truncate 2
        |> ValueSeq.toSeq
        |> should equal [ 1; 2 ]

    [<Test>]
    let ``Test truncating over a shorter than n sequence`` () =
        [| 1; 2; 4; 8 |]
        |> ValueSeq.ofArray
        |> ValueSeq.truncate 6
        |> ValueSeq.toSeq
        |> should equal [ 1; 2; 4; 8 ]

    [<Test>]
    let ``Test truncating to zero`` () =
        [| 1; 2; 4; 8 |]
        |> ValueSeq.ofArray
        |> ValueSeq.truncate 0
        |> ValueSeq.toSeq
        |> should be Empty

    [<Test>]
    let ``Test truncating empty sequence`` () =
        []
        |> ValueSeq.ofList
        |> ValueSeq.truncate 1
        |> ValueSeq.toSeq
        |> should be Empty

    //
    // Combined ValueSeq.skip and ValueSeq.truncate tests
    //

    [<Test>]
    let ``Test skipping and truncating a sequence`` () =
        [| 1; 2; 4; 8 |]
        |> ValueSeq.ofArray
        |> ValueSeq.skip 1
        |> ValueSeq.truncate 2
        |> ValueSeq.toSeq
        |> should equal [2; 4]