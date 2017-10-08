<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Text.RegularExpressions.dll</Reference>
</Query>

Stopwatch s = new Stopwatch();
s.Start();

HashSet<System.Numerics.BigInteger> distinctTerms = new HashSet<System.Numerics.BigInteger>();

Enumerable.Range(2,(100-1)).ToList().ForEach(a=>
	Enumerable.Range(2,(100-1)).ToList().ForEach(b=>
		distinctTerms.Add(System.Numerics.BigInteger.Pow(a,b))));
		

distinctTerms.Count().Dump("Total Records");

s.Stop();
s.ElapsedMilliseconds.Dump("milliseconds");
