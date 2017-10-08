<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
</Query>

void Main()
{

	//decimal numerator = 1;
	//decimal denominator = 7;

	foreach (int v in Enumerable.Range(1, 999))
	{
		string fraction = Fraction(10000000000000, v*10000000000000);
		Console.WriteLine(fraction);
		string recurringCycle = "";
		int y = 0;

		//open a window and then move across keep doing it
		List<string> sections = new List<string>();

		for (int i = 0; i < fraction.Length; i++)
		{
			//build the string
			recurringCycle = recurringCycle + fraction[i];

			y = 0;

			while (y < fraction.Length - recurringCycle.Length)
			{
				if (fraction.Substring(y, recurringCycle.Length) == recurringCycle & isUnique(recurringCycle))
				{
					//Console.WriteLine($"string: {recurringCycle}, isUnique: {isUnique(recurringCycle)}");
					sections.Add(recurringCycle);

				}

				y += recurringCycle.Length;
			}

		}

		//var result = sections.GroupBy(s => s);
		if (sections.Count() > 0)
			Console.WriteLine($"{v}: {sections.Last()}");

	}
	
}

string Fraction(System.Numerics.BigInteger numerator, System.Numerics.BigInteger denominator) {
	return (numerator / denominator).ToString().Replace("0.", "");
}

// Define other methods and classes here
bool isUnique(string s) {
	if (s.ToList().Distinct().Count() == s.Count() )
		return true;
	else
	{
		return false;
	}
}