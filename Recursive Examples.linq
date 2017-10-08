<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
</Query>

void Main()
{
	int count = 0;
	int total = Recursive(6,ref count);
	
	Console.WriteLine(count);
	Console.WriteLine(total);
	
	Console.WriteLine(Factorial(3));
	Console.WriteLine(recursiveTest(4));
}

// Define other methods and classes here
static int Recursive(int value, ref int count)
{
	count++;
	if (value >= 10)
	{
		// throw new Exception("End");
		return value;
	}
	return Recursive(value + 1, ref count);
}

public long Factorial(int n)
{
	if (n == 0)//The condition that limites the method for calling itself
		return 1;
	return n * Factorial(n - 1);
}

private int recursiveTest(int parameter) 
{
	return (parameter ==0) ? 0 : recursiveTest(parameter-1)+parameter;
}

public long Fib(int n)
{
	if (n == 0 || n == 1)//satisfaction condition
		return n;
	return Fib(k - 2) + Fib(k - 1);
}