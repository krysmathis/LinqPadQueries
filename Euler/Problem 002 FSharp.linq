<Query Kind="FSharpProgram" />

//If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
//Find the sum of all the multiples of 3 or 5 below 1000.

let isEven x = 
    x % 2 = 0
    

let multiples = 
    [1..999]
    |> List.filter (fun x -> x % 3 = 0 || x % 5 = 0)
    |> List.sum
    
printfn "sum of multiples: %i" (multiples)

let fibonacciSeq = Seq.unfold (fun (current, next) -> Some(current, (next, current + next))) (0,1)

let fibTotal =
    fibonacciSeq
    |> Seq.takeWhile (fun n -> n < 4000000)
    |> Seq.filter (fun n -> n % 2 = 0)
    |> Seq.sum
    
printfn "sub of fibonacci: %i" (fibTotal)
//Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:
//1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
//By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.

