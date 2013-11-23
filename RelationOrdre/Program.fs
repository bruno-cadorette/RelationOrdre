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
    matriceM:bool[,]
    matriceC:bool[,]
}

type Relation<'T> with
    static member init<'T> (initializer:regleRelation<'T>) (elements:'T[]) =
        let matrice = Array2D.init elements.Length elements.Length (fun i j->initializer elements.[i] elements.[j])
        {elements=elements; regle= initializer; matriceM=matrice; matriceC=Relation<'T>.initCMatrice matrice}

    static member private initCMatrice (matrice:bool[,]) =
        let n = matrice.GetUpperBound(0)
        let mEnC i j =
            if (i=j) then
                true
            else if (matrice.[i,j]) then
                not (seq {0..n} |> Seq.exists(fun k-> i<>k && j<>k && matrice.[i,k] && matrice.[k,j]))
            else
                false
        Array2D.init (n+1) (n+1) mEnC
        
    static member private trouver (selecteur:int->bool[,]->seq<bool>)(relation:Relation<'T>) =
        [|0..relation.matriceM.GetUpperBound(0)|] 
        |> Array.filter(fun i->relation.matriceM |> selecteur(i) |> Seq.mapi(fun j x->(x,j)) |> Seq.forall(fun (x,j)-> not x || i=j)) 
        |> Array.map(fun i->relation.elements.[i])

    static member private unique (selecteur:int->bool[,]->seq<bool>) (relation:Relation<'T>) =
        let indice = [|0..relation.matriceM.GetUpperBound(0)|] |> Array.tryFind(fun i->relation.matriceM |> selecteur(i) |> Seq.forall(fun x->x))
        match indice with
        | Some n -> Some(relation.elements.[n])
        | None   -> None

    //TODO: Mettre les fonctions de tests comme ça encore plus généric comme pour les minimaux/maximaux et pour le minimum/maximum
    //TODO: Trouver un meilleur moyen pour générer les tuples
    static member estReflexif (relation:Relation<'T>) =
        seq { 0..relation.matriceM.GetUpperBound(0) } |> Seq.forall(fun i-> relation.matriceM.[i,i])

    static member estSymetrique (relation:Relation<'T>) =
        let n = relation.matriceM.GetUpperBound(0)
        seq { for i in [|0..n|] do for j in  [|0..n|] do yield (i,j) }
        |> Seq.forall(fun (i,j)->relation.matriceM.[i,j]=relation.matriceM.[j,i])

    static member estAntiSymetrique (relation:Relation<'T>) =
        let n = relation.matriceM.GetUpperBound(0)
        seq { for i in [|0..n|] do for j in  [|0..n|] do yield (i,j) }
        |> Seq.forall(fun (i,j)->i<>j||Convert.ToInt32(relation.matriceM.[i,j])+Convert.ToInt32(relation.matriceM.[j,i])>=1)

    //A optimiser
    static member estTransitif (relation:Relation<'T>) = 
        let n = relation.matriceM.GetUpperBound(0)
        seq { for i in [|0..n|] do for j in  [|0..n|] do for k in [|0..n|] do yield (i,j,k) }
        |> Seq.forall(fun (i,j,k)->(not relation.matriceM.[i,j] || not relation.matriceM.[j,k]) || (relation.matriceM.[i,j] && relation.matriceM.[j,k] && relation.matriceM.[i,k]))

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
          

    
    static member rangs (relation:Relation<'T>) =
        let rec trouverRangs (rangs:(int*int[])list) (rangActuel:int) (ligneDelete:int[]) =
            let func i = 
                relation.matriceC 
                |> Array2D.getColumn(i) 
                |> Seq.mapi(fun i x->(i,x)) 
                |> Seq.sumBy(fun (i,x)->Convert.ToInt32(not(ligneDelete|>Array.exists(fun y->y=i))&& x))=1

            let n = relation.matriceC.GetUpperBound(0)
            if (ligneDelete.Length<n) then
                let courant = [|0..n|] |> Array.filter(func)
                let predicat = fun (x,i)->not(courant |> Array.exists(fun x->x=i))
                let t = rangActuel, courant
                trouverRangs (t::rangs) (rangActuel+1) (Array.append courant ligneDelete)
            else 
                rangs
        trouverRangs []  0 [||]

let PrintMatrice (matrice: bool[,]) =
    for i in 0..(matrice|>Array2D.length1)-1 do
        Console.WriteLine(String.Join("",matrice |> Array2D.getRow(i) |> Seq.map(fun x->Convert.ToInt32(x))))
        
let IsIn a b=
    a |> Seq.forall(fun x->b|>Seq.exists(fun y->y=x))
    
//http://rosettacode.org/wiki/Power_set#F.23
let powerset xs = 
    List.foldBack (fun x rest -> rest @ List.map (fun ys -> x::ys) rest) xs [[]]

//TODO: Faire le diagramme de Hasse
[<EntryPoint>]
let main argv = 
    let sets = powerset [1..6]|> Seq.toArray
    let elements = [|0..20|]

    let divide = fun a b->(a<>0 && b % a = 0)||(a=b && a=0)
    printfn "%A" elements
    let relation = Relation.init (fun a b->divide a b) elements
    printfn "Les maximaux sont : %A" (relation |> Relation.maximaux )
    printfn "Les minimaux sont : %A" (relation |> Relation.minimaux )
    if (Relation.estRelationEquivalence relation) then
        printfn "Cette relation est une relation d'équivalence, il n'y a donc pas de maximum/minimum"
    else
        printfn "Le maximum est : %A" (relation |> Relation.maximum )
        printfn "Le minimum est : %A" (relation |> Relation.minimum )
        printfn "Relation d'ordre : %A" (relation |> Relation.estRelationOrdre )
        printfn "Les rangs sont : %A" (relation |> Relation.rangs )
    printfn "La matrice M est : "
    PrintMatrice(relation.matriceM)
    printfn "La matrice C est : "
    PrintMatrice(relation.matriceC)
    Console.ReadKey()|>ignore
    0 // retourne du code de sortie entier
