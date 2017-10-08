<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
</Query>

List<string> names = new List<string>(File.ReadAllText(@"C:\Users\krys\Documents\p022_names.txt").Split(',').OrderBy(f =>f ).ToList());

int position = 0;
int nameSum = 0;
long totalSum = 0;


foreach (string name in names)
{
	position += 1; nameSum = 0;

	foreach (char c in name.Replace("\"","").ToCharArray())
	{
		nameSum += (int)c-64;
	}
	totalSum += position * nameSum;
}

Console.WriteLine(totalSum);