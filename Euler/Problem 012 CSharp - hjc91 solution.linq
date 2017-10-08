<Query Kind="Statements" />

int tot = 0;
int triangle = 0;
for (int i = 1; tot <= 500; i++)
{
	triangle += i;
	tot = 0;
	double sqr = Math.Sqrt(triangle);
	for (int a = 1; a <= sqr; a++)
	{
		if (triangle % a == 0)
		{
			
			tot += 2;
		}
	}

}
Console.WriteLine(triangle.ToString());