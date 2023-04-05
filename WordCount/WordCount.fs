namespace WordCount

open System
open System.IO
open System.Text.RegularExpressions

module WordCount =

//counts number of words in a string
    let countWords (content: string) : Map<string, int> =
        if String.IsNullOrWhiteSpace content then
            Map.empty
        else
            let words = 
                content.Split([|' '; ','; '.'; '!'|], StringSplitOptions.RemoveEmptyEntries)
                |> Array.map (fun w -> w.Trim().ToLower())

            let wordCounts = Array.fold (fun counts w -> Map.change w (function | None -> Some 1 | Some n -> Some (n + 1)) counts) Map.empty words
            wordCounts

//tries to read a file, returns None if file not found
    let tryReadFile (filePath: string) =
        try 
            Some (File.ReadAllText(filePath))
        with
            | :? FileNotFoundException -> printfn "File Not Found"; None

//counts words in a file
    let countWordsInFile (filePath: string) : Map<string, int> =
        let content = tryReadFile filePath
        match content with
        | None -> Map.empty
        | Some(value) -> countWords value

//prints word counts to console
    let printWordCounts (wordCounts: Map<string, int>) =
        wordCounts
        |> Map.iter (fun key value -> printfn "%i: %s" value key)
