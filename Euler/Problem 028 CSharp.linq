<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Text.RegularExpressions.dll</Reference>
</Query>

int total = 1;
int corner = 1;

Enumerable.Range(2, 1000).Where(x => x % 2 == 0).ToList().ForEach(i =>
{
	Enumerable.Range(1,4).ToList().ForEach(c => 
	{
		total += i + corner;
		corner += i;
	});

});

Console.WriteLine(total);