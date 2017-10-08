<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Linq</Namespace>
</Query>

void Main()
{

	//generate a list of prime number to feed into the program
	List<long> listOfPrimes = new List<long>();
	
    for (long primeCounter = 2; primeCounter < 1000000; primeCounter++)
	{
		if (primeCounter.isPrime())
			listOfPrimes.Add(primeCounter);
	}

	int totalFactors = 1;
	long triangular = 1;
	long number = 1;

	while (totalFactors < 500) 
	{	

		number ++;
		triangular = number * (number + 1) / 2;

		Dictionary<long, int> primeFrequency = new Dictionary<long, int>();

		List<long> primes = primeFactorSearch(triangular,listOfPrimes); //triangular.PrimeFactors(); //
		if (primes.Count() > 0)
		{
			//populate a dictionary to store the numbers
			foreach (var prime in primes)
				primeFrequency[prime] = 0;

			bool divisorGreaterThanOne = true;
			long remainder = triangular;

			//Prime Factorization
			while (divisorGreaterThanOne)
			{
				foreach (var p in primes)
				{
					if (remainder % p == 0)
					{
						primeFrequency[p] = primeFrequency[p] + 1;
						remainder = remainder / p;
					}
				}

				if (remainder == 1) divisorGreaterThanOne = false;
			}

			//
			totalFactors = 1;
			foreach (KeyValuePair<long, int> kvp in primeFrequency)
			{
				totalFactors = totalFactors * (kvp.Value + 1);
			}
			
			if (totalFactors>500)
				Console.WriteLine($"*********i: {number}, triangular: {triangular}, total factors: {totalFactors}");
			
			

		}
	}
	
}

private List<long> primeFactorSearch(long factorSearchNum, List<long> primeNumbers) {
	
	List<long> factors = new List<long>();

	foreach (long v in primeNumbers) {
		if (factorSearchNum % v == 0)
			factors.Add(v);
	}
	
	return factors;
}

public List<long> primeFactors(long factorSearchNum) {

	List<long> factors = new List<long>();
	
	for (long i = 2; i < factorSearchNum/2+1; i++)
	{
		if (i.isPrime())
		{
			
			if (factorSearchNum % i == 0)
			{
				if (i > 300)
				{
					return new List<long>();
				}
				factors.Add(i);
			}
		}
	}
	
	return factors;

}



// Define other methods and classes here
public static class Extension
{
//	public static List<long> PrimeFactors(this long me)
//	{
//		return Enumerable.Range(2L, me/2+1).Where(x => x.isPrime() & me % x == 0L).ToList();	
//	}

	public static bool isPrime(this long me)
	{
		
		//test all the numbers from the top of the square root down
			//test all the numbers from the top of the square root down
		if (me == 2 || me == 3)
			return true;
			
		for (long i = 2; i < Math.Sqrt(me)+1; i++)
			if (me % i == 0)
				return false;
		
		return true;

	}
}





