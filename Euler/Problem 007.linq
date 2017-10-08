<Query Kind="Program" />

void Main()
{
	var primeNumber = 0;
	var primeCounter = 0;
	var i = 1;
	
	
	while (true) {

		i++;
		if (isPrime(i))
		{
			primeNumber= i;
			primeCounter++;
		}

		if (primeCounter == 10001) {
			break;
		}
	}
	
	Console.WriteLine($"{primeCounter}:{primeNumber}");
}

// Define other methods and classes here
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