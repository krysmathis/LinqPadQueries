<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Text.RegularExpressions.dll</Reference>
  <NuGetReference>morelinq</NuGetReference>
</Query>

void Main()
{
	//1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
	
	HashSet<string> combinations = new HashSet<string>();
	

	
	List<int> pence = new List<int>(){1,2,5,10,20,50,100,200};
	
	pence = pence.OrderByDescending (p=>p).ToList();
	pence.Dump();
	
	int baseCase = 20;

	pence.ForEach(p =>
	{
		if (p <= baseCase)
		{
			
		}
		
	});
	

combinations.Dump();




}

// Define other methods and classes here

public Dictionary<int, int> resetChange() 
{
	Dictionary<int, int> change = new Dictionary<int, int>();
	change.Add(1, 0);
	change.Add(2, 0);
	change.Add(5, 0);
	change.Add(10, 0);
	change.Add(50, 0);
	change.Add(100, 0);
	change.Add(200, 0);
	
	return change;


}
public string coinCombination(Dictionary<int,int> change){

	string combinations = "";
	
	change.OrderByDescending (c =>c.Key ).ToList().ForEach(p=> {
		
		if (combinations.Length>1)
			combinations = combinations + "+" + p.Value + "x" + p.Key +"p";
		else
			combinations = p.Value + "x" + p.Key +"p";
	});
	
	return combinations;

}