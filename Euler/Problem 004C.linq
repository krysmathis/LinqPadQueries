<Query Kind="Program" />

void Main()
{
	//A palindromic number reads the same both ways.The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
	//Find the largest palindrome made from the product of two 3-digit numbers.
	//foreach (var e in Enumerable.Range(100, 900))
	//	Console.WriteLine(e);

	//new List<int>(Enumerable.Range(900, 100)).ForEach(x => new List<int>(Enumerable.Range(900, 100)).ForEach(y =>isPalindrome(x, y)));
	//max([x*y for x in range(900,1000) for y in range(900,1000) if str(x*y) == str(x*y)[::-1]])

	int largestPalindrome = 0;
	Func<int, string> reverse = i => new string(i.ToString().ToCharArray().Reverse().ToArray());
	Func<int, int, bool> isPalindrome = (x, y) => (x * y).ToString() == reverse((x * y));

	var l = new List<int>()
	{
    foreach (var x in Enumerable.Range(100,900)
		{

		}
	}
	foreach (var x in Enumerable.Range(100, 900))
	{
		foreach (var y in Enumerable.Range(100, 900))
		{
			if (isPalindrome(x, y))
			{
				if (largestPalindrome<x*y)
					largestPalindrome=(x * y);
			}
		}
	}


	Console.WriteLine(largestPalindrome);

}


