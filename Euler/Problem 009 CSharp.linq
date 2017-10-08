<Query Kind="Program" />

void Main()
{
	foreach (var c in Enumerable.Range(1, 500))
	{
		foreach (var b in Enumerable.Range(1, 500).Where(x => x < c))
		{
			foreach (var a in Enumerable.Range(1, 500).Where(x => x < b))
			{
				if (isPythagoreanTriple(a, b, c))
				{
					var primitive = getPrimitive(a,b,c);
					if (primitive.Item1 + primitive.Item2 + primitive.Item3 == 1000)
						Console.WriteLine($"{primitive} with a produce of {primitive.Item1 * primitive.Item2 * primitive.Item3}");
						
				}
			}
		}
	}

}

bool isPythagoreanTriple(int x, int y, int z) {
	return x * x + y * y == z * z;
}

Tuple<int, int, int> getPrimitive(int x, int y, int z)
{
	if (x % 2 == 0 & y % 2 == 0 & z % 2 == 0) {
		return new Tuple<int,int,int>(x/2,y/2,z/2);
	}
	return new Tuple<int,int,int>(x,y,z);
	
}




