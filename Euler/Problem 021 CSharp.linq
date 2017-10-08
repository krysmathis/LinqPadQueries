<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
</Query>

void Main()
{
	HashSet<int> uniqueValues = new HashSet<int>();
	
	foreach (var v in Enumerable.Range(1, 10000))
	{
		if (isAmicable(v, getDivisors(v).Sum())) {
					uniqueValues.Add(v);
		}
	}
	
	Console.WriteLine(uniqueValues.Sum());

}

private bool isAmicable(int a, int b)
{
	if (a!=b & getDivisors(a).Sum() == b & getDivisors(b).Sum()==a) 
		return true;
	else
		return false;
}


private List<int> getDivisors(int n) 
{
	List<int> divisors = new List<int>();

	for (int i = 1; i <= n / 2; i++) 
	{
		if (n % i ==0)
			divisors.Add(i);
	}

	return divisors;

}