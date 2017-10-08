<Query Kind="Program" />

void Main()
{
	WeekData w1 = new WeekData( 0, 20, 10);
	
	bool include_ty = true;
	double weight = 0.50;
	
	w1.CalculateWeightedAvg(weight,include_ty);
	
	Console.WriteLine(w1.WeightedAvg.ToString());
}

// Define other methods and classes here
public class WeekData
{

	public double ? TY { get; private set; }
	public double ? LY { get; private set; }
	public double ? LY2 { get; private set; }
	public double ? WeightedAvg { get; set; }

	public WeekData(double ty, double ly, double ly2)
	{
		TY = ty;
		LY = ly;
		LY2 = ly2;
	}

	public void CalculateWeightedAvg(double weight, bool include_ty)
	{

		//if it includes ty then you have to choose between ty and ly
		//if no values exist then just make it the average of all values


		bool ty_exists = TY > LY / 2;
		bool ly_exists = LY > 0;
		bool ly2_exists = LY2 > LY / 2;

		double second_weight_value = TY ?? 0;

		//if there's no TY then just use LY2
		if (!ty_exists & !ly2_exists)
		{
			second_weight_value = 0;
			WeightedAvg = LY ?? 0;
		}
		else if (!ty_exists || !include_ty)
			second_weight_value = LY2 ?? 0;

		else if (!ly2_exists & !include_ty)
			second_weight_value = TY ?? 0;


		if (ly_exists)
			WeightedAvg = LY * weight + second_weight_value * (1 - weight);
		else if (ty_exists || ly2_exists)
			WeightedAvg = second_weight_value;
		else
		{
			WeightedAvg = null;
		}
	}

}



