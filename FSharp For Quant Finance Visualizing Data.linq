<Query Kind="FSharpProgram">
  <Reference>&lt;RuntimeDirectory&gt;\System.Collections.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Drawing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Text.RegularExpressions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <NuGetReference>morelinq</NuGetReference>
</Query>

open System
open System.Drawing
open System.Windows.Forms
open System.Collections.Generic

//the form
let form2 = new Form(Visible = true, Text = "Display Data in F#", TopMost = true, Size = Drawing.Size(600,600))

let data = new DataGridView(Dock = DockStyle.Fill, Text = "Data grid", Font = new Drawing.Font("Lucinda Console",10.0f), ForeColor = Drawing.Color.DarkBlue)

form2.Controls.Add(data)

//data.DataSource <- [| ("ORCL", 32.2000, 31.1000, 31.1200, 0.0100); ("MSFT", 72.050, 72.3100, 72.400, 0.0800);|]

//Generic list
let myList = new List<(string * float * float * float * float)>()

myList.Add(("ORCL", 32.2000, 31.1000, 31.1200, 0.0100))
myList.Add(("MSFT", 72.050, 72.3100, 72.400, 0.0800))

data.DataSource <- myList.ToArray()

//Set column headers
do data.Columns.[0].HeaderText <- "Symb"
do data.Columns.[1].HeaderText <- "Last Sale"
do data.Columns.[2].HeaderText <- "Bid"
do data.Columns.[3].HeaderText <- "Ask"
do data.Columns.[4].HeaderText <- "Spread"
do data.Columns.[0].Width <- 100

