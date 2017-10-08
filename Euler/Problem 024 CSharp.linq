<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
</Query>

void Main()
{

	List<string> values = new List<string> { "0", "1", "3","4","5","6","7","8","9" };

	IEnumerable<IEnumerable<string>> result = GetPermutations(values, 9);
	Console.WriteLine(result.ElementAt(274239));
}


public static IEnumerable<IEnumerable<T>>
	GetPermutations<T>(IEnumerable<T> list, int length)
{
	if (length == 1) return list.Select(t => new T[] { t });

	return GetPermutations(list, length - 1)
		.SelectMany(t => list.Where(e => !t.Contains(e)),
			(t1, t2) => t1.Concat(new T[] { t2 }));
}


