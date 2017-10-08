<Query Kind="Program" />

void Main()
{
	var watch = System.Diagnostics.Stopwatch.StartNew();
	// the code that you want to measure comes here

	//seive approach
	List<long> primes = Enumerable.Range(2,1999998).Select(x=>(long)x).ToList();
	int topVal = Convert.ToInt32(Math.Ceiling(Math.Sqrt(2000000)));

	foreach (var v in Enumerable.Range(2, topVal)) {
		if (isPrime(v))
			primes.RemoveAll(x=>x % v==0 && x!=v);

	}

	watch.Stop();
	var elapsedMs = watch.ElapsedMilliseconds;

	Console.WriteLine($"{primes.Sum().ToString()} in {elapsedMs}");

}

// Define other methods and classes here
private bool isPrime(long x)
{
	//test all the numbers from the top of the square root down
	if (x == 2 || x == 3)
		return true;

	for (long i = 2; i < Math.Sqrt(x)+1; i++)
	{     
		if (x % i == 0)
			return false;
	}
	return true;

}
