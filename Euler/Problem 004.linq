<Query Kind="Program" />

void Main()
{
	//A palindromic number reads the same both ways.The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
	//Find the largest palindrome made from the product of two 3-digit numbers.
	int y = 999;
	int subtractor = 0;
	string product;
	List<int> Products = new List<int>();
	
	while (y >= 100){
		for (int x = 1000; x >=100; x--)
		{
			
			product = (x*y).ToString();
			if (product ==Reverse(product))
				Products.Add(x*y);

		}
		y--;
	}
	
	Console.WriteLine(Products.Max());
	
}

// Define other methods and classes here
private string Reverse(string product) {	
	return new string(product.ToCharArray().Reverse().ToArray());
}



