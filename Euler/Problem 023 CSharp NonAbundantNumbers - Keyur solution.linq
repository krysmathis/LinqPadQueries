<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
</Query>

Func<int,bool> isAbundant = (x => Enumerable.Range(1, (int)Math.Sqrt(x)).Where(i => x % i == 0).Sum(i => (i != x / i && i != 1) ? (i + x / i) : i) > x);

var allAbundant = Enumerable.Range(1, 28122).Where(i => isAbundant(i)).ToList();
List<int> allSums = new List<int>();
foreach (int n in allAbundant)
	foreach (int m in allAbundant)
		if (n + m < 28123)
			allSums.Add(n + m);

var sum = Enumerable.Range(1, 28122).Except(allSums.Distinct()).Sum();