module Program
open RelationOrdre
open Automate
open System
open System.Windows.Forms
open System.Drawing
open GUI
open MathHelper

let PrintMatrice (matrice: bool[,]) =
    for i in 0..(matrice|>Array2D.length1)-1 do
        Console.WriteLine(String.Join("",matrice |> Array2D.getRow(i) |> Seq.map(fun x->Convert.ToInt32(x))))

// Si la liste est [1;2;3;4;5;6], cette fonction retourne [(1,2);(2,3);(3;4);(4;5);(5;6)]
let rec listCouple f list =
    match list with
    |h::t when not t.IsEmpty->(f h t.Head)::listCouple f t
    |_->[]


let hasseForm relation rangs =
    let formHasse = new Form()
    formHasse.Text<-"Diagramme de Hasse"
    
    let startX,startY = 40,40
    let hauteur = 
        let a = startY * 4
        (rangs |> List.length) * startY + a

    let largeur = 
        let a = startX * 4
        (rangs |> List.map(fun (i,x)-> x|>Array.length) |> List.max) * startX + a

    formHasse.Width <- largeur
    formHasse.Height <- hauteur


    let position i (rangs,elems) =
        let y = (i+1)*startY
        elems |> Array.mapi(fun j elem->elem,((j+1)*startX,y))
    let getLabels arr =
        let f (elem,(x,y)) =
            let label = new Label()
            label.Location <- new Drawing.Point(x,y)
            label.Text <- relation.elements.[elem].ToString()
            label.AutoSize <- true
            label
        arr |> Array.map(f)

    let getLignes haut bas=
        let dessiner (i,(x1,y1)) =
            let r = relation.matriceC |> Array2D.getRow(i)
            haut 
            |> Array.filter(fun (j,p)->r.[j])
            |> Array.map(fun (j,(x2,y2))->new Point(x1+3,y1+3),new Point(x2+3,y2+3))
        bas |> Array.collect(dessiner)

    let dessinerRelations points =
        let paint(e:PaintEventArgs) = 
            let g = e.Graphics
            let pen = new Pen(Color.Black)
            points |> Seq.iter(fun (p1:Point,p2)->g.DrawLine(pen,p1,p2))
        paint

    let elements = rangs |> List.mapi(position)

    let labels = 
        elements
        |> Seq.collect(getLabels)
        |> Seq.cast<Control>
        |> Seq.toArray

    let lignes =
        elements
        |> listCouple getLignes
        |> Seq.concat
    formHasse.Controls.AddRange(labels)
    formHasse.Paint.Add(dessinerRelations lignes)
    formHasse
   

//TODO: Faire le diagramme de Hasse
[<EntryPoint>]
let main argv = 
    let elements = [|1..20|]
    let relation = Relation.init Relations.Divise elements
    let rangs = (relation |> Relation.rangs )
    let form = new FormRelation()
    form.buttonHasse.Click.Add(fun e->(hasseForm relation rangs).Show())
    Application.Run(form)
//    printfn "Les maximaux sont : %A" (relation |> Relation.maximaux )
//    printfn "Les minimaux sont : %A" (relation |> Relation.minimaux )
//    if (Relation.estRelationEquivalence relation) then
//        printfn "Cette relation est une relation d'équivalence, il n'y a donc pas de maximum/minimum"
//    else
//        printfn "Le maximum est : %A" (relation |> Relation.maximum )
//        printfn "Le minimum est : %A" (relation |> Relation.minimum )
//        printfn "Relation d'ordre : %A" (relation |> Relation.estRelationOrdre )
//        
//        printfn "Les rangs sont : %A" rangs
//    printfn "La matrice M est : "
//    PrintMatrice(relation.matriceM)
//    printfn "La matrice C est : "
//    PrintMatrice(relation.matriceC)
//    Console.ReadKey()
    0 // retourne du code de sortie entier
