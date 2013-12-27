module Program
open RelationOrdre
open Automate
open System;
open Prime;


let PrintMatrice (matrice: bool[,]) =
    for i in 0..(matrice|>Array2D.length1)-1 do
        Console.WriteLine(String.Join("",matrice |> Array2D.getRow(i) |> Seq.map(fun x->Convert.ToInt32(x))))



let isIn a b=
    a |> Seq.forall(fun x->b|>Seq.exists(fun y->y=x))
    
//http://rosettacode.org/wiki/Power_set#F.23
let powerset xs = 
    List.foldBack (fun x rest -> rest @ List.map (fun ys -> x::ys) rest) xs [[]]

//TODO: Faire le diagramme de Hasse
[<EntryPoint>]
let main argv = 
    Console.WindowHeight <- Console.LargestWindowHeight
    Console.WindowWidth <- Console.LargestWindowWidth
    let t = (reduction(init()))
    printfn "%A" t
    let sets = powerset [1..6]|> Seq.toArray
    let elements = Eratosthenes 30 |> Seq.toArray
    let divide = fun a b->(a<>0 && b % a = 0)||(a=b && a=0)
    printfn "%A" elements
    let relation = Relation.init (fun a b-> divide a b) elements
    printfn "Les maximaux sont : %A" (relation |> Relation.maximaux )
    printfn "Les minimaux sont : %A" (relation |> Relation.minimaux )
    if (Relation.estRelationEquivalence relation) then
        printfn "Cette relation est une relation d'équivalence, il n'y a donc pas de maximum/minimum"
    else
        printfn "Le maximum est : %A" (relation |> Relation.maximum )
        printfn "Le minimum est : %A" (relation |> Relation.minimum )
        printfn "Relation d'ordre : %A" (relation |> Relation.estRelationOrdre )
        printfn "Les successeurs de 0 sont : %A" (relation |> Relation.succ(0) )
        let rangs = (relation |> Relation.rangs )
        printfn "Les rangs sont : %A" rangs
    printfn "La matrice M est : "
    PrintMatrice(relation.matriceM)
    printfn "La matrice C est : "
    PrintMatrice(relation.matriceC)
    Console.ReadKey()|>ignore
    0 // retourne du code de sortie entier
