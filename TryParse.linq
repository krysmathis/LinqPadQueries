<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Text.RegularExpressions.dll</Reference>
  <NuGetReference>morelinq</NuGetReference>
</Query>

double d;
var parsing = double.TryParse("35.7", out d);
parsing.Dump();
d.Dump();

var parsingNoOut = double.TryParse("36.77", out d);
if (parsingNoOut)
	parsingNoOut.Dump("parsingNoOut");