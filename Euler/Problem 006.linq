<Query Kind="Program" />

void Main()
{
	
	var sumOfSquares = Enumerable.Range(1,100).Select(x => x*x).Sum();
	var squareOfSums = Math.Pow(Enumerable.Range(1,100).ToList().Sum(),2);
	
	Console.WriteLine(squareOfSums-sumOfSquares);

	
}

