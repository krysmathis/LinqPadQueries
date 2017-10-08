<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Text.RegularExpressions.dll</Reference>
</Query>

void Main()
{
	SortedList<int,double> detrendValues = new SortedList<int,double>();
	detrendValues.Add(1,1.23);
	detrendValues.Add(2,1.11);
	detrendValues.Add(3,1.05);
	detrendValues.Add(4,0.85);
	detrendValues.Add(5,0.55);

	//detrendValues.Dump("detrend");

	//var a = detrendValues.Keys.ToArray();
	//var b = detrendValues.Values.ToArray();
	foreach (var v in Enumerable.Range(1, 1000))
	{
		//detrendValues.Dump("Before");
		detrendValues = getDetrended(detrendValues);
		//detrendValues.Dump("After");
	}
	

}

// Define other methods and classes here

public static SortedList<int,double> getDetrended(SortedList<int, double> data) 
{
	double slope = Slope(data);
	double intercept = Intercept(data);

	SortedList<int, double> detrended = new SortedList<int, double>();
	
	if (RSquared(data) > .80)
	{
		data.ToList().ForEach(x => detrended.Add(x.Key, x.Value / (intercept + (x.Key * slope))));
	}
	else
	{
		detrended = data;
	}

	Slope(data).Dump("slope");
	RSquared(data).Dump("r2");

	return detrended;
}

public static double Slope(IEnumerable<KeyValuePair<int,double>> data)
{
	double averageX = data.Average(d => d.Key);
	double averageY = data.Average(d => d.Value);

	return data.Sum(d => (d.Key - averageX) * (d.Value - averageY)) / data.Sum(d => Math.Pow(d.Key - averageX, 2));
}

public static double Intercept(IEnumerable<KeyValuePair<int,double>> data)
{
	double slope = Slope(data);
	return data.Average(d => d.Value) - slope * data.Average(d => d.Key);
}

public static double RSquared(IEnumerable<KeyValuePair<int, double>> data) 
{
	var SStot = data.Sum(p => Math.Pow(p.Value - data.Average(d => d.Value), 2.0));
	var SSerr = data.Sum(p => Math.Pow(p.Value - (Slope(data) * p.Key + Intercept(data)), 2.0));
	
	double RSquare = 1.0 - SSerr / SStot;;
	return RSquare;
}