<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Text.RegularExpressions.dll</Reference>
  <NuGetReference>morelinq</NuGetReference>
</Query>

void Main()
{
	int baseline = 200;
	
	List<Currency> currency = new List<Currency>();
	currency.Add(new Currency(200,baseline));
	currency.Add(new Currency(100,baseline));
	currency.Add(new Currency(50,baseline));
	currency.Add(new Currency(20,baseline));
	currency.Add(new Currency(10,baseline));
	currency.Add(new Currency(5, baseline));
	currency.Add(new Currency(2, baseline));
	currency.Add(new Currency(1, baseline));
	

	int remainder = baseline;
	bool tappedOut = false;
	int counter = 0;
	
	while (!tappedOut)
	{

		remainder = baseline;
		ClearCounts(currency);

		//decrement the first value that is > 0
		foreach (var v in currency.OrderByDescending(c => c.Value).Where(x => x.MaxValue > 0).ToList())

		{
			if (v.MaxValue > 0)
			{
				v.MaxValue -= 1;

				if (v.MaxValue == 0) { v.Completed = true; }

				//	}
				break;
			}
		}

		//calculate the value for each one
		while (remainder > 0)
		{
			currency.OrderByDescending(c => c.Value).Where(x => x.MaxValue > 0).ToList().ForEach(j =>
			{
				if (j.Value <= remainder & j.Count == 0)
				{
					if (remainder / j.Value > j.MaxValue)
					{
						j.Count = j.MaxValue;
					}
					else
					{
						j.Count = remainder / j.Value;
					}

					//j.Completed = true;
					remainder = remainder - (j.Count * j.Value);
					//Console.WriteLine($"remainder: {remainder}");

					
				}
			});

			counter += 1;
			if (currency.Where(c => c.Value > 1).Any(b => b.MaxValue > 0))
				tappedOut = false;
			else tappedOut = true;
		}
		currency.Dump();
	}
	
	counter.Dump();
	//currency.Dump();
	
}

// Define other methods and classes here
public class Currency
{
	public int Value;
	public bool Completed;
	public int MaxValue;
	public int Count;

	public Currency(int value, int baseline)
	{
		Value = value;
		Completed = false;
		Count = 0;
		MaxValue = baseline/value;
	}
}

public void ClearCounts(List<Currency> currency) {
	currency.ForEach(c=> c.Count = 0);
}

public void ResetMaxValue(List<Currency> currency, int baseline) {
	currency.Where(c=>c.Completed==false).ToList().ForEach(c=> c.MaxValue = baseline/c.Value);
}