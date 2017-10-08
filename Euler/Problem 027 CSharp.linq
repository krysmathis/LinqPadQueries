<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Text.RegularExpressions.dll</Reference>
</Query>

void Main()
{

	var primeVals = getPrimes(1000);
	var maxCount = 0;
	var maxA = 0;
	var maxB = 0; 
	
	for (int a = -1000; a <= 1000; a++)
	{
		for (int b = -1000; b <= 1000; b++)
		{
			List<int> primes = new List<int>();

			for (int n = 0; n <= 100; n++)
			{
				int result = (n * n) + (n * a) + b;
					
					if (primeVals.Contains(result))
						primes.Add(result);
					else
					{
						break;
					}
			}


			var numberOfPrimes = primes.Count();
			if (numberOfPrimes > maxCount)
			{	
				maxCount = numberOfPrimes;
				maxA = a;
				maxB = b;
			}
		}
	}
	Console.WriteLine($"a: {maxA} b: {maxB} count: {maxCount}, product: {maxA * maxB}");
}


// Define other methods and classes here


public HashSet<long> getPrimes(int numberOfPrimes){
	
	HashSet<long> listOfPrimes = new HashSet<long>();
	int c = 0;
	while (c < numberOfPrimes)
	{
		for (long primeCounter = 2; primeCounter < 10000; primeCounter++)
		{
			if (isPrime(primeCounter))
			{
				c += 1;
				listOfPrimes.Add(primeCounter);
			}
		}
	}
	return listOfPrimes;

}

public bool isPrime(long x)
{
	//test all the numbers from the top of the square root down
	if (x == 2 || x == 3)
		return true;

	for (long i = 2; i < Math.Sqrt(x) + 1; i++)
		if (x % i == 0)
			return false;

	return true;

}