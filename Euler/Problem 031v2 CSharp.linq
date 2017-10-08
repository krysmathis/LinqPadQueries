<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Text.RegularExpressions.dll</Reference>
  <NuGetReference>morelinq</NuGetReference>
</Query>

void Main()
{
	
	Dictionary<int, int> change = new Dictionary<int, int>();
	change.Add(1, 0);
	change.Add(2, 0);
	change.Add(5, 0);
	change.Add(10, 0);
	change.Add(50, 0);
	change.Add(100, 0);
	change.Add(200, 0);
	
	int baseCase = 25;
	int remainder = 0;
	//change.Sum(x => x.Key * x.Value).Dump();
	
	List<Currency> currency = new List<Currency>();
	currency.Add(new Currency(10,false));
	currency.Add(new Currency(5,false));
	currency.Add(new Currency(1,false));
	//currency.Dump();
	
	//currency.Sum(j=> j.Value * j.Count).Dump("currency dump");
	remainder = baseCase;
	bool allClear = false;
	int cntr = 0;
	while (!allClear) 
	{
		cntr+=1;
		
		while (remainder > 0) {

			
			currency.OrderByDescending(c => c.Value).Where(c => c.Completed == false).ToList().ForEach(j =>
			  {
				  Console.WriteLine(j.Value);
				  if (j.Value <= remainder & j.Count == 0)
				  {
					  j.Count = remainder / j.Value;
					  j.Completed = true;
					  remainder = remainder % (j.Count * j.Value);
					  Console.WriteLine($"remainder: {remainder}");
				  }
		
				  allClear = currency.All(c => c.Completed == true);
		
			  });
		

			//break;
		}

		if (cntr > 10) { break;}
	}
	

	
	
	
	currency.Dump();
	//subtracting out of one thing only then roll through it, keep track of which bucket you're subtracting from
}

// Define other methods and classes here
public class Currency
{
	public int Value;
	public bool Completed;
	public int CurrentValue;
	public int Count;
	
	public Currency(int value, bool completed, int count = 0)
	{
		Value = value;
		Completed = completed;
		Count = count;
		CurrentValue = 0;
	}
}