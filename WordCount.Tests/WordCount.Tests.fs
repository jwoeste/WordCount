module WordCount.Tests

open Xunit
open WordCount
open System.Collections.Generic

[<Fact>]
let ``Test countWords``() =
    let input = "Go do that thing that you do so well"
    let expected: Map<string,int> = Map.ofList<string,int>[
        ("go", 1);
        ("do", 2);
        ("that", 2);
        ("thing", 1);
        ("you", 1);
        ("so", 1);
        ("well", 1)]
    let actual = WordCount.WordCount.countWords input
    printfn "Input: %A" input
    printfn "Expected: %A" expected
    printfn "Actual: %A" actual
    Assert.Equal<IDictionary<string,int>>(expected, actual)

[<Fact>]
let ``Test countWords with latin 1 characters``() =
    let input = "¡Hola! ¿Qué tal?"
    let expected: Map<string,int> = Map.ofList<string,int>[
        ("¡hola", 1);
        ("¿qué", 1);
        ("tal?", 1)]
    let actual = WordCount.WordCount.countWords input
    printfn "Input: %A" input
    printfn "Expected: %A" expected
    printfn "Actual: %A" actual
    Assert.Equal<IDictionary<string,int>>(expected, actual)

[<Fact>]
let ``Test countWords with empty string``() =
    let input = ""
    let expected = Map.empty
    let actual = WordCount.countWords input
    printfn "Input: %A" input
    printfn "Expected: %A" expected
    printfn "Actual: %A" actual
    Assert.Equal<IDictionary<string,int>>(expected, actual)

[<Fact>]
let ``Test countWords with punctuation and mixed casing``() =
    let input = "Hello, World! hello, world!"
    let expected: Map<string,int> = Map.ofList<string,int>[
        ("hello", 2);
        ("world", 2)
    ]
    let actual = WordCount.countWords input
    printfn "Input: %A" input
    printfn "Expected: %A" expected
    printfn "Actual: %A" actual
    Assert.Equal<IDictionary<string,int>>(expected, actual)

[<Fact>]
let ``Test countWords with various delimiters``() =
    let input = "This is a test, a simple test. It's just a test!"
    let expected: Map<string,int> = Map.ofList<string,int>[
        ("this", 1);
        ("is", 1);
        ("a", 3);
        ("test", 3);
        ("simple", 1);
        ("it's", 1);
        ("just", 1)
    ]
    let actual = WordCount.countWords input
    printfn "Input: %A" input
    printfn "Expected: %A" expected
    printfn "Actual: %A" actual
    Assert.Equal<IDictionary<string,int>>(expected, actual)

[<Fact>]
let ``Test countWords from non-existing file``() =
    let input = "not-existing-file.txt"

    let expected = Map.empty
    let actual = WordCount.countWordsInFile input
    printfn "Input: %A" input
    printfn "Expected: %A" expected
    printfn "Actual: %A" actual
    Assert.Equal<IDictionary<string,int>>(expected, actual)

(*[<Fact>]
let ``Test countWords from file``() =
    let input = "test.txt"
    let expected: Map<string,int> = Map.ofList<string,int>[
        ("hello", 1);
        ("world", 1)
    ]
    let actual = WordCount.countWordsInFile input
    printfn "Input: %A" input
    printfn "Expected: %A" expected
    printfn "Actual: %A" actual
    Assert.Equal<IDictionary<string,int>>(expected, actual)*)
    