<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Text.RegularExpressions.dll</Reference>
</Query>

void Main()
{


	List<int> startingNumbersResolveAt89 = new List<int>() { 89};
	List<int> numbersThatResolveTo89 = new List<int>();

	Enumerable.Range(20, 1).AsParallel().ToList().Where(x => !numbersThatResolveTo89.Contains(x)).ToList().ForEach(x =>
	{
		
		List<int> numbers = new List<int>();
		int startingNumber = x;
		bool resolving = true;
		while (resolving)
		{

			int digitTotal = digitizer(x).Aggregate(0, (sum, value) =>
			{
				sum += value * value;
				numbers.Add(sum);
				return sum;
			});
		
	
			x = digitTotal;

			Console.WriteLine($"x={x}, digitTotal={digitTotal}");
			if (digitTotal == 89)
			{

				startingNumbersResolveAt89.Add(startingNumber);
				//Console.WriteLine("{0} Equals 89", x);
				resolving = false;
			}
			else if (digitTotal == 1)
			{
				resolving = false;
				break;

			}
		}
	});

	startingNumbersResolveAt89.Count().Dump("Count of numbers that resolve at 89");
	startingNumbersResolveAt89.Dump("list");
}


public IEnumerable<int> digitizer(int digits) 
{
	return digits.ToString().ToCharArray().Select(d => Convert.ToInt32(d.ToString())).ToList();
}


public IEnumerable<int> GetAggregate(IEnumerable<int> digits) {

	int runningTotal = 0;
	foreach (int d in digits) 
	{
		runningTotal += d*d;
		yield return runningTotal;
	}
}