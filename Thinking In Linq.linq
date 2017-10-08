<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Text.RegularExpressions.dll</Reference>
</Query>

var q = Enumerable.Range(2, 10).Select
	(c => new
	{
		Length = 2 * c,
		Height = c * c - 1,
		Hypotenuse = c * c + 1})
		.ToList();
		
Console.WriteLine(q[0].Height);
q[0].Height.Dump("Height");

//weighted sum
int[] values = { 1, 2, 3 };
int[] weights = { 3, 2, 1};

//dot product of vector
values.Zip(weights, (value,weight) => value * weight) //same as a dot product
	.Sum().Dump("Weighted Sum");
	
//fizzbuzz
List<string> fizzBuzzes = new List<string>();
Enumerable.Range(1,20).ToList().ForEach(k => fizzBuzzes.Add(k % 15 == 0 ? "FizzBuzz" : 
k % 5 == 0 ? "Buzz" : k % 3 == 0 ? "Fizz" : k.ToString()));
fizzBuzzes.Take(20).Dump("Fizz Buzz Challenge");

//Currency
int[] curvals = { 500, 100, 50, 20, 10, 5, 2, 1, 1000};

int amount = 2548;

Dictionary<int,int> map = new Dictionary<int,int>();

curvals.OrderByDescending(c =>c )
	.ToList()
	.ForEach(c => { map.Add(c, amount / c); amount = amount % c;});
	
map.Where(m => m.Value!=0).Dump();