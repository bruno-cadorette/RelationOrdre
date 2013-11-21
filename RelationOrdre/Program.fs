// Obtenez des informations sur F# via http://fsharp.net
// Voir le projet 'Didacticiel F#' pour obtenir de l'aide.

open System;

type regleRelation<'T> = 'T->'T->bool

//On peut remplacer par array.[i, *] en f# 3.1
module Array2D =
    let getRow (i:int)(array:'T[,]) = 
        array.[i..i, *] |> Seq.cast<'T>
    let getColumn (i:int)(array:'T[,]) = 
        array.[*, i..i] |> Seq.cast<'T>

type Relation<'T> = {
    elements:'T[]
    regle:regleRelation<'T>
    matrice:bool[,]
}

type Relation<'T> with
    static member init<'T> (initializer:regleRelation<'T>) (elements:'T[]) =
        let matrice = Array2D.init elements.Length elements.Length (fun i j->initializer elements.[i] elements.[j])
        {elements=elements; regle= initializer; matrice=matrice}

    static member private trouver (selecteur:int->bool[,]->seq<bool>)(relation:Relation<'T>) =
        [|0..relation.matrice.GetUpperBound(0)|] 
        |> Array.filter(fun i->relation.matrice |> selecteur(i) |> Seq.mapi(fun j x->(x,j)) |> Seq.forall(fun (x,j)-> not x || i=j)) 
        |> Array.map(fun i->relation.elements.[i])

    static member private unique (selecteur:int->bool[,]->seq<bool>) (relation:Relation<'T>) =
        let indice = [|0..relation.matrice.GetUpperBound(0)|] |> Array.tryFind(fun i->relation.matrice |> selecteur(i) |> Seq.forall(fun x->x))
        match indice with
        | Some n -> Some(relation.elements.[n])
        | None   -> None

    //TODO: Mettre les fonctions de tests comme ça encore plus généric comme pour les minimaux/maximaux et pour le minimum/maximum
    //TODO: Trouver un meilleur moyen pour générer les tuples
    static member estReflexif (relation:Relation<'T>) =
        seq { 0..relation.matrice.GetUpperBound(0) } |> Seq.forall(fun i-> relation.matrice.[i,i])

    static member estSymetrique (relation:Relation<'T>) =
        let n = relation.matrice.GetUpperBound(0)
        seq { for i in [|0..n|] do for j in  [|0..n|] do yield (i,j) }
        |> Seq.forall(fun (i,j)->relation.matrice.[i,j]=relation.matrice.[j,i])

    static member estAntiSymetrique (relation:Relation<'T>) =
        let n = relation.matrice.GetUpperBound(0)
        seq { for i in [|0..n|] do for j in  [|0..n|] do yield (i,j) }
        |> Seq.forall(fun (i,j)->i<>j||Convert.ToInt32(relation.matrice.[i,j])+Convert.ToInt32(relation.matrice.[j,i])>=1)

    static member estTransitif (relation:Relation<'T>) = 
        let n = relation.matrice.GetUpperBound(0)
        seq { for i in [|0..n|] do for j in  [|0..n|] do for k in [|0..n|] do yield (i,j,k) }
        |> Seq.forall(fun (i,j,k)->(not relation.matrice.[i,j] || not relation.matrice.[j,k]) || (relation.matrice.[i,j] && relation.matrice.[j,k] && relation.matrice.[i,k]))

    static member estRelationOrdre (relation:Relation<'T>) =
        Relation.estReflexif relation && Relation.estAntiSymetrique relation && Relation.estTransitif relation

    static member estRelationEquivalence (relation:Relation<'T>) =
        Relation.estReflexif relation && Relation.estSymetrique relation && Relation.estTransitif relation
     
    static member minimaux (relation:Relation<'T>) = 
        Relation.trouver Array2D.getColumn relation

    static member maximaux (relation:Relation<'T>) = 
        Relation.trouver Array2D.getRow relation

    static member minimum (relation:Relation<'T>) = 
        Relation.unique Array2D.getRow relation

    static member maximum (relation:Relation<'T>) =
        Relation.unique Array2D.getColumn relation
          
let PrintMatrice (matrice: bool[,]) =
    for i in 0..(matrice|>Array2D.length1)-1 do
        for j in 0..(matrice|>Array2D.length2)-1 do
            Console.Write(Convert.ToInt32(matrice.[i,j]))
        Console.WriteLine();
        
let IsIn a b=
    a |> Seq.forall(fun x->b|>Seq.exists(fun y->y=x))
    
//http://rosettacode.org/wiki/Power_set#F.23
let powerset xs = 
    List.foldBack (fun x rest -> rest @ List.map (fun ys -> x::ys) rest) xs [[]]

//TODO: Transformer la matrice M en matrice C
//TODO: Faire le diagramme de Hasse
[<EntryPoint>]
let main argv = 
    let elements = powerset [1..5]|> Seq.toArray
    
    let divide = fun a b->(a<>0 && b % a = 0)||(a=b && a=0)
    printfn "%A" elements
    let relation = Relation.init (fun a b->IsIn a b) elements
    printfn "Les maximaux sont : %A" (relation |> Relation.maximaux )
    printfn "Les minimaux sont : %A" (relation |> Relation.minimaux )
    if (Relation.estRelationEquivalence relation) then
        printfn "Cette relation est une relation d'équivalence, il n'y a donc pas de maximum/minimum"
    else
        printfn "Le maximum est : %A" (relation |> Relation.maximum )
        printfn "Le minimum est : %A" (relation |> Relation.minimum )
        printfn "Relation d'ordre : %A" (relation |> Relation.estRelationOrdre )
    printfn "La matrice est : "
    PrintMatrice(relation.matrice)
    Console.ReadKey()|>ignore
    0 // retourne du code de sortie entier
