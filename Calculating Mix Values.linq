<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Text.RegularExpressions.dll</Reference>
  <NuGetReference>morelinq</NuGetReference>
</Query>

void Main()
{
	SortedDictionary<int,double?> LY2 = new SortedDictionary<int,double?>(){};
	SortedDictionary<int,double?> LY = new SortedDictionary<int,double?>(){};
	SortedDictionary<int,double?> TY = new SortedDictionary<int,double?>(){};
	SortedDictionary<int,double?> MIX = new SortedDictionary<int,double?>(){};
	
	LY2.Add(1,2000);
	LY2.Add(2,1000);
	LY2.Add(3,1000);
	LY2.Add(4,null);
	LY2.Add(5,1000);
	
	LY.Add(1,1000);
	LY.Add(2,1000);
	LY.Add(3,0);
	LY.Add(4,1000);
	LY.Add(5,1000);

	TY.Add(1,1000);
	TY.Add(2,1000);
	TY.Add(3,1000);
	TY.Add(4,1250);
	TY.Add(5,9000);
	
	Weights weights = new Weights(.25,.25,.5);
	
	Enumerable.Range(1,5).ToList().ForEach(x=> 
	{
		MIX.Add(x, CalculateMix(LY2[x],LY[x],TY[x],weights));
		//Console.WriteLine (CalculateMix(LY2[x],LY[x],TY[x],weights));
	});
	
	MIX.Dump("Index");
	
}

// Define other methods and classes here
public double CalculateMix(double? LY2, 
							double? LY,
							double? TY,
							Weights weights)
{
		//a rule that says any value must meet some minimum
		//threshold, so a 1 or 15 value doesn't sneak in.
		List<double?> values = new List<double?>(){LY2,LY,TY};
		double minimumThreshold = values.Sum()/values.Count()/2 ?? 0;

		//could be a function returning tuples of bool values
		bool LY2_valid = false;
		bool LY_valid = false;
		bool TY_valid = false;
		
		if (LY2 >= minimumThreshold) {  LY2_valid = true; }
		if (LY >= minimumThreshold) {  LY_valid = true; }
		if (TY >= minimumThreshold) {  TY_valid = true ;}
		
		List<bool> valids = new List<bool>(){LY2_valid, LY_valid, TY_valid};
		int numberOfValids = valids.Where(x=> x==true).Count();
		
		switch (numberOfValids)
		{
			case 1:
				if (LY2_valid) {return (double) LY2;}
				if (LY_valid) {return (double) LY;}
				if (TY_valid) {return (double) TY;}
				break;
				
			case 2:
				//will need to adjust the weights in this case due to the 
				//missing values
				if (LY_valid & TY_valid){
					Weights adjWeights = new Weights(0.0,weights.LY,weights.TY);
					return (double)(LY*adjWeights.LY + TY * adjWeights.TY);
				}
				
				if (LY2_valid & TY_valid){
					Weights adjWeights = new Weights(weights.LY2,0,weights.TY);
					return (double)(LY2*adjWeights.LY2 + TY * adjWeights.TY);
				}
				
				if (LY2_valid & LY_valid){
					Weights adjWeights = new Weights(weights.LY2,weights.LY,0);
					return (double)(LY2*adjWeights.LY2 + LY * adjWeights.LY);
				}
				break;
			case 3:
				return (double)(LY2 * weights.LY2 + LY * weights.LY + TY * weights.TY);
			default:
				return 0.0;
		
		}

		//double default
		return 0;
		
}


public class Weights {

	public double LY2 {get; private set;}
	public double LY {get; private set;}
	public double TY {get; private set;}
	
	
	public Weights(double ly2, double ly, double ty){
		LY2 = ly2;
		LY = ly;
		TY = ty;
		calculateBase();

	}


	public void calculateBase() 
	{
		double sumOfWeights = LY2 + LY + TY;
		
		if (sumOfWeights!=1.0) {
			Console.WriteLine ("Weights do not equal 1, recalculating");
			LY2 = LY2/sumOfWeights;
			LY = LY/sumOfWeights;
			TY = TY/sumOfWeights;
		}
	}

}