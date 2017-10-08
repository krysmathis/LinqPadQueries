<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Namespace>System.Numerics</Namespace>
</Query>

void Main()
{
	var data = File.ReadAllLines(@"C:\Users\krys\Documents\projecteuler13.txt");

	List<int> results = new List<int>();
	
	int rowTotal = 0;
	int carryOver = 0;
	int numberOfCols = data[0].ToCharArray().Count()-1;

	for (int col = 0; col <= numberOfCols; col++)
	{
		rowTotal = 0;
		foreach (var line in data.ToList())
		{
			rowTotal += line[numberOfCols - col].ToInt32();
		}
		//now add the carryover value
		rowTotal += carryOver;
		
		//store the results
		results.Add(rowTotal.OnesPlace());
		
		carryOver = (rowTotal - rowTotal.OnesPlace())/10;
	}

	//process the last carryover value to be the beginning of the number
	foreach (char c in carryOver.AsCharArr()) {
		results.Add(c.ToInt32());
	}
	
	results.Reverse();
	foreach (var v in results.Take(10))
		Console.Write(v.ToString());

}

public static class Extension
{

	public static int OnesPlace(this int me)
	{
		return Convert.ToInt32(me.ToString().Substring(me.ToString().Length - 1));
	}

	public static int ToInt32(this char me)
	{
		return Convert.ToInt32(me.ToString());
	}

	public static char[] AsCharArr(this int me) 
	{
		return me.ToString().ToCharArray();
	}

}
