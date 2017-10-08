<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
</Query>

void Main()
{

	System.Numerics.BigInteger numerator = System.Numerics.BigInteger.Pow(10,10000);
	//decimal denominator = 7;
	var maxValue = 0;
	var currentMax = 0;
	bool debug = false;

	foreach (int v in Enumerable.Range(1,999).Where(s=> isPrime(s)).OrderByDescending(s =>s ))
	{
		string fraction = Fraction(numerator, v);
		
		var sequences = getSequences(fraction);

		if (debug) {
			Console.WriteLine($"v = {v}: {fraction}");
			Console.WriteLine(sequences);
		}


		if (sequences.Count() > 0)
		{
			var maxLength = lengthOfMaxOccuringSequenceValue(sequences);

			if (currentMax < maxLength)
			{
				currentMax = maxLength;
				maxValue = v;

			}
			else 
			{
				break;
			}
		}



	}
	
	Console.WriteLine($"v = {maxValue}, maxLength = {currentMax}");
	
}

string Fraction(System.Numerics.BigInteger numerator, System.Numerics.BigInteger denominator) {
	return (numerator / denominator).ToString().Replace("0.", "");
}

private int lengthOfMaxOccuringSequenceValue(Dictionary<string, int> sequences) {
	
	var maxCount = sequences.Max(s => s.Value );
	var value = sequences.FirstOrDefault(x => x.Value == maxCount).Key;
	return value.Length;
	
}

private Dictionary<string, int> getSequences(string fraction) {

Dictionary<string,int> sections = new Dictionary<string,int>();

	for (int startingPoint = 0; startingPoint < fraction.Length/2; startingPoint++)
	{
			for (int lengthOfSection = 0; lengthOfSection < fraction.Length - startingPoint; lengthOfSection++)
			{
		
				string portionUnderConsideration = fraction.Substring(startingPoint, lengthOfSection);
				
				if (startingPoint-1 + lengthOfSection*2 <fraction.Length)
				{
		
		
					var nextPart = fraction.Substring(startingPoint+ lengthOfSection, lengthOfSection);
					//Console.WriteLine($"portion: {portionUnderConsideration}, nextPart: {nextPart}");
		
					if (nextPart == portionUnderConsideration && portionUnderConsideration.Length>1)
					{
						
						if (sections.ContainsKey(portionUnderConsideration))
							sections[portionUnderConsideration]=sections[portionUnderConsideration]+1;
						else
						{
							sections[portionUnderConsideration]=1;
						}
						
						break;
					}
				
				}
		
		
		
			}
	}	

	return sections;
}

// Define other methods and classes here
public bool isPrime(long x)
{
	//test all the numbers from the top of the square root down
	if (x == 2 || x == 3)
		return true;

	for (long i = 2; i < Math.Sqrt(x) + 1; i++)
		if (x % i == 0)
			return false;

	return true;

}