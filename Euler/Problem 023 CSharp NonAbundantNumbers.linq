<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
</Query>

void Main()
{

	List<int> abundantNumbers = new List<int>();
	
	foreach (var v in Enumerable.Range(12, 28123 - 12))
		if (getDivisors(v).Sum() > v)
			abundantNumbers.Add(v);

	HashSet<int> sumsOfAbundants = new HashSet<int>();

	foreach (var v in abundantNumbers)
	{
		foreach (var y in abundantNumbers)
			sumsOfAbundants.Add(v+y);
	}
	
	var allNumbers = Enumerable.Range(1,28122).Except(sumsOfAbundants).Sum();
	//var allNumbers = Enumerable.Range(1,28123).ToList().Where(i=>!sumsOfAbundants.Any(n => n==i));
	
	//Console.WriteLine(allNumbers);
	
}

// Define other methods and classes here
private List<int> getDivisors(int n)
{
	List<int> divisors = new List<int>();

	for (int i = 1; i <= n / 2; i++)
	{
		if (n % i == 0)
			divisors.Add(i);
	}

	return divisors;

}

