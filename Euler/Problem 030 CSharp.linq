<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Text.RegularExpressions.dll</Reference>
</Query>

void Main()
{
	List<int> digitFifthPowers = new List<int>();
	
	foreach (var v in Enumerable.Range(1, 354294))
	{
		List<double> values = new List<double>();
		
		v.ToString().ToCharArray().ToList().ForEach(c => 
			values.Add(Math.Pow((int.Parse(c.ToString())),5)));
		
		if (v == values.Sum())
			digitFifthPowers.Add(v);
	}


	digitFifthPowers.Where(d=> d>1).Sum().Dump("sum of digits");
}






public int pow4(int i) 
{
	return Convert.ToInt32(Math.Pow(i,5));
}