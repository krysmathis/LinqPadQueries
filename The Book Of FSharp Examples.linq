<Query Kind="FSharpProgram">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Text.RegularExpressions.dll</Reference>
</Query>

let farenheitToCelcius degreesF = (degreesF - 32.0) * (5.0 / 9.0)

let marchHighTemps = [ 90.0; 90.0; 90.0; 90.0;]

marchHighTemps
|> List.average
|> farenheitToCelcius
|> printfn "March Average (C): %f"

let averageInCelcius = List.average >> farenheitToCelcius

printfn "March Functional Composition: %f" <| averageInCelcius marchHighTemps

let rec factorial v = 
    match v with | 1L -> 1L
                 | _ -> v * factorial (v - 1L)
    


//let factorial num =
//    [1..num] |> Seq.fold (fun acc n -> acc * n) 1
    
printfn "factorial: %i" <| factorial 5L