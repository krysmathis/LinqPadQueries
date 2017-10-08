<Query Kind="FSharpProgram">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Text.RegularExpressions.dll</Reference>
  <NuGetReference>morelinq</NuGetReference>
</Query>

/// Adopted from https://en.wikipedia.org/wiki/OCaml#Birthday_paradox

let year_size = 365.

let rec birthday_paradox prob people =
    let prob = (year_size - (float people)) / year_size * prob  in
    if prob < 0.5 then
        printfn "answer = %d\n" (people+1)
    else
        birthday_paradox prob (people+1) ;;

 birthday_paradox 1.0 1