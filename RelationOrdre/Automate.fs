module Automate
open RelationOrdre
type automate<'T,'U>={
    E:seq<int>
    A:seq<'T>
    Z:seq<'U>
    m:int[,]
    s:'U[,]
}
type etat=seq<seq<int>>


let etat0 (automate:automate<_,_>)=
    let e = automate.E|>Seq.toArray
    [|0..automate.s.GetUpperBound(1)|]:>seq<int>
    |>Seq.map(fun i->(i,automate.s|>Array2D.getColumn(i)|>Seq.toArray))
    |>Seq.groupBy(fun (i,x)->x)
    |>Seq.map(fun(a,b)->b|>Seq.map(fun (x,y)->e.[x]))

let init() =
    let m = array2D [|[|0;9;2;1;1;1;3;5;7;6|];
              [|4;4;5;3;7;6;8;9;0;1|]|]
    let s = array2D [|[|'A';'A';'A';'R';'R';'R';'A';'R';'R';'R'|];
                [|'R';'R';'R';'A';'A';'A';'R';'A';'A';'A'|]|]
    {E=seq{0..9}; A=[|'a';'b'|]; Z=[|'A';'R'|]; m=m;s=s}




let etatNth (automate:automate<_,_>) (etat:etat)=
    let e = automate.E|>Seq.toArray
    let columns = 
        [|0..automate.s.GetUpperBound(1)|]:>seq<int>
        |>Seq.map(fun i->(e.[i],automate.m|>Array2D.getColumn(i)|>Seq.toArray))
        |> Map.ofSeq
    
    let memeEtat (a)(b)=
        let i = etat|>Seq.findIndex(fun x->x|>Seq.exists(fun y->y=a))
        etat|>Seq.nth(i)|>Seq.exists(fun y->y=b)
    let equivalent (column1:int[]) (column2:int[]) =
         [|0..column1.GetUpperBound(0)|]
         |>Array.forall(fun i->memeEtat (column1.[i]) (column2.[i]))     
    seq{for classe in etat do
        let first = classe |>Seq.nth(0)
        yield seq{
        for element in classe do
            if (equivalent (columns.[first]) (columns.[element])) then
                yield element}}

            
let reduction automate =
    
    let rec reduire (etat:etat) = 
        let etatActuel = etatNth(automate)(etat)
        if (etat=etatActuel) then
            etat
        else
            reduire etatActuel
    reduire(etat0(automate))