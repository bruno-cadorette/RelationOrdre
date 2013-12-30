module Prime
open System
open System.Collections
let Eratosthenes n=
    let sieve = new BitArray(n, true)
    let func i = 
        if sieve.[i] then 
            for j in i*i..i..(n-1) do
                sieve.[j]<-false
            true
        else false
    let sqrt = (int)(Math.Sqrt((float)n))
    let a = [|2..sqrt|] |> Array.filter(func)
    let b = [|(sqrt+1)..(n-1)|]|> Array.filter(fun i->sieve.[i])
    Seq.append a b
