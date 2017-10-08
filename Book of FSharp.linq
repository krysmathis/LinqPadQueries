<Query Kind="FSharpExpression">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Text.RegularExpressions.dll</Reference>
  <NuGetReference>morelinq</NuGetReference>
</Query>



let slope p1 p2 = 
    let x1, y1 = p1
    let x2, y2 = p2
    (y1 - y2)/(x1-x2)
    
let slope2 (x1,y1)(x2,y2) = (y1-y2)/(x1-x2)


printfn "slope %A" (slope2 (13.0,8.0) (1.0,2.0))

let showValue (v : _ option) =
  printfn "%s" (match v with 
                | Some x -> x.ToString() 
                | None -> "None")
        
Some 123 |> showValue;