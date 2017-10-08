<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
</Query>

void Main()
{
	//Console.WriteLine(Factorial(8));
	Console.WriteLine(Factorial(100).ToString().ToCharArray().Sum(x=>Convert.ToInt32(x.ToString())));
}

public System.Numerics.BigInteger Factorial(int n)
{
	if (n == 0)
		return 1;
	return n * Factorial(n - 1);
}