<Query Kind="Program" />

void Main()
{

	Euler003 solution = new Euler003();
	
	solution.Solve();
	
}

// Define other methods and classes here
public class Euler003
{
	//The prime factors of 13195 are 5, 7, 13 and 29.
	//What is the largest prime factor of the number 600851475143 ?
	
	//prime numbers
	//starting with the number roll down and calculate the prime numbers and see if they are a factor
	//calc factors of a number
	
	long factorSearchNum = 600851475143;

	
	public void Solve()
	{

		long prime = 0;
		long lastPrime = 0;

		for (long i = 2; i < Math.Sqrt(factorSearchNum); i++)
		{
			if (isPrime(i))
			{
				prime = i;
				if (factorSearchNum % prime == 0)
				{
					Console.WriteLine($"factor of {prime}");
					//factorSearchNum = factorSearchNum / prime;
					lastPrime = prime;
				}

			}

			
		}

		Console.WriteLine(lastPrime);

	}



	public bool isPrime(long x)
	{
			//test all the numbers from the top of the square root down
		if (x == 2 || x == 3)
			return true;
			
		for (long i = 2; i < Math.Sqrt(x)+1; i++)
			if (x % i == 0)
				return false;
		
		return true;
		
	}


}