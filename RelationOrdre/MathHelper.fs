namespace MathHelper

open System
open System.Collections

module Helper =
    //http://rosettacode.org/wiki/Power_set#F.23
    let Powerset xs = 
        List.foldBack (fun x rest -> rest @ List.map (fun ys -> x::ys) rest) xs [[]]

module Prime =
    let FindPrimes n=
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

module Relations =
    let inline Divise a b =
        (a<>0 && b % a = 0)||(a=b && a=0)
    let inline Contient a b =
        a |> Seq.forall(fun x->b|>Seq.exists(fun y->y=x))
    let inline Egal a b =
        a=b