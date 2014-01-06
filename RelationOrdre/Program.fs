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


// Si la liste est [1;2;3;4;5;6], cette fonction retourne [(f 1 2);(f 2 3);(f 3 4);(f 4 5);(f 5 6)]
module List =
    let rec couple f list =
        match list with
        |h::t when not t.IsEmpty->(f h t.Head)::couple f t
        |_->[]


let hasseForm relation rangs =    
    let startX,startY = 40,40
    let hauteur = 
        let a = startY * 4
        (rangs |> List.length) * startY + a

    let largeur = 
        let a = startX * 4
        (rangs |> List.map(fun (i,x)-> x|>Array.length) |> List.max) * startX + a

    let formHasse = new Form(Text = "Diagramme de Hasse", Width = largeur, Height = hauteur)
    let position i (rangs,elems) =
        let y = (i+1)*startY
        elems |> Array.mapi(fun j elem->elem,((j+1)*startX,y))
    //Tableau de labels
    let getLabels arr =
        let f (elem,(x,y)) =
            new Label(
                Location = new Drawing.Point(x,y),
                Text = relation.elements.[elem].ToString(),
                AutoSize = true)
        arr |> Array.map(f)
    //Tableau de coordonnées pour les lignes
    let getLignes haut bas=
        let dessiner (i,(x1,y1)) =
            let r = relation.matriceC |> Array2D.getRow(i)
            haut 
            |> Array.filter(fun (j,p)->r.[j])
            |> Array.map(fun (j,(x2,y2))->new Point(x1+3,y1+3),new Point(x2+3,y2+3))
        bas |> Array.collect(dessiner)

    let dessinerRelations points =
        fun (e:PaintEventArgs) ->
            let g = e.Graphics
            let pen = new Pen(Color.Black)
            points |> Seq.iter(fun (p1:Point,p2)->g.DrawLine(pen,p1,p2))

    let elements = rangs |> List.mapi(position)
    //AddRange accepte seulement un tableau de Control
    let labels = 
        elements
        |> Seq.collect(getLabels)
        |> Seq.cast<Control>
        |> Seq.toArray

    let lignes =
        elements
        |> List.couple getLignes
        |> Seq.concat
    formHasse.Controls.AddRange(labels)
    formHasse.Paint.Add(dessinerRelations lignes)
    formHasse
   

let proprieteRelation relation (form:FormRelation) =
    let text m = 
        match m with
        |Some(a)->a.ToString()
        |None->"-"
    if Relation.estRelationEquivalence relation then
        form.labelEquivalence.Visible <- true
        form.panelOrdre.Visible <- false
    else
        form.labelEquivalence.Visible <- false
        form.panelOrdre.Visible <- true
        form.labelMaximaux.Text<-sprintf "%A" (relation |> Relation.maximaux)
        form.labelMaximum.Text <- text(relation |> Relation.maximum)
        form.labelMinimaux.Text <- sprintf "%A" (relation |> Relation.minimaux)
        form.labelMinimum.Text <- text(relation |> Relation.minimum)
    
let getElements (text:string) =
    let e = text.Split(',') |> Array.map(Int32.TryParse)
    match Array.forall fst e with
    |true->Some(Array.map snd e)
    |false->None
        


let calcul (form:FormRelation) =
    fun e ->
        let check(x:Control) = 
            match x with
            | :?RadioButton as x when x.Checked->true
            |_->false
        //Peut être null
        let elements = (getElements form.textBoxElements.Text).Value
        let fonction =
            let radios = [|Relations.Divise;Relations.Egal;Relations.Puissance|] 
            //Peut être null
            let tag = 
                form.groupBoxRelation.Controls 
                |> Seq.cast<Control> 
                |> Seq.tryFind(check)
            radios.[Convert.ToInt32(tag.Value.Tag)]
        let relation = Relation.init fonction elements
        let rangs = relation |> Relation.rangs
        proprieteRelation relation form
        (*Ça serait bien si a la place de recréer le bouton à chaque fois je pourrais simplement changer 
        l'évènement ou quelque chose comme ça*)
        let buttonHasse = 
            new Button(
                Text="Diagramme de Hasse")
        buttonHasse.Click.Add(fun e->
        (hasseForm relation rangs).Show()) 
        for x in form.panelHasse.Controls do
            form.panelHasse.Controls.Remove(x)
        form.panelHasse.Controls.Add(buttonHasse)


//TODO: Faire le diagramme de Hasse
[<EntryPoint>]
let main argv = 
    let form = new FormRelation()
    form.buttonCalcul.Click.Add(calcul form)
    Application.Run(form)
    0 // retourne du code de sortie entier
