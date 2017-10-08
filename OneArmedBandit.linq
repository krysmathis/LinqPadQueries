<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Text.RegularExpressions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.DataVisualization.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.DataVisualization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.DataVisualization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <NuGetReference>MedallionRandom</NuGetReference>
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
  <Namespace>System.Windows.Forms.DataVisualization.Charting</Namespace>
</Query>

void Main()
{
	int N = 5000;
	double[] r = run_experiment (1.0, 2.0, 3.0, .1, N);
	double[] r2 = run_experiment (1.0, 2.0, 3.0, .05, N);
	double[] r3 = run_experiment (1.0, 2.0, 3.0, .01, N);
	
	
	var chart = new Chart();	
	var chartArea = new ChartArea();
	chart.ChartAreas.Add(chartArea);
	chart.Size = new Size(width: 900, height: 300);
	
	var xs = Enumerable.Range(1,N).ToArray();
	var rand = new Random(Guid.NewGuid().GetHashCode());
	var ys = r;
	var ys2 = r2;
	var ys3 = r3;
	
	var series = new Series();
	series.Points.DataBindXY(xs,ys);
	var series2 = new Series();
	var series3 = new Series();
	
	series2.Points.DataBindXY(xs,ys2);
	series3.Points.DataBindXY(xs,ys3);
	
	chart.Series.Add(series);
	chart.Series.Add(series2);
	chart.Series.Add(series3);
	
	series.ChartType = SeriesChartType.FastLine;
	series2.ChartType = SeriesChartType.FastLine;
	series3.ChartType = SeriesChartType.FastLine;
	
	var frm = new Form();
	frm.ClientSize = new Size(width: 900, height: 300);
	frm.Controls.Add(chart);
	
	Application.Run(frm);
	

}

// Define other methods and classes here
public double[] run_experiment(double m1, double m2, double m3, double eps, int N)
{

	Bandit[] bandits = new Bandit[]{
				new Bandit(m1),
				new Bandit (m2),
				new Bandit(m3)
			};

	List<double> data = new List<double>() { };

	Random p = new Random();
	int j = 0;
	double x;

	foreach (var v in Enumerable.Range(0, N))
	{


		if (p.NextDouble() < eps)
		{
			j = p.Next(0, 3);
		}
		else
		{
			var max = bandits.ToList().Max(b => b.mean);
			j = bandits.ToList().FindIndex(m => m.mean == max);
		}

		x = bandits[j].pull();
		//Console.WriteLine($"pull value: {x}");
		bandits[j].update(x);
		data.Add(x);
	}


	//double sum = 0;
	//double cumSum = data.Select(c => (sum += c)).ToArray().Sum();

	//int countSum  = Enumerable.Range (1, N + 1).Sum ();


	var cumsum = data.ToList().CumulativeSum();
	var r = Enumerable.Range(1, N+1).ToList();

	double[] cumulative_average = cumsum.Zip(r, (a, b) => a / b).ToArray();

	bandits.ToList().ForEach(ba =>
	{
		Console.WriteLine("mean: {0}", ba.mean);
	});

	return cumulative_average;
}


	
public class Bandit
{
	public double mean { get; private set; }
	private double N;
	private double m;
	Random r = new Random();
	public Bandit(double m)
	{
		this.m = m;
		mean = 0;
		N = 0;
	}

	public double pull()
	{
		return Medallion.Rand.NextGaussian(r)+m;
	}

	public void update(double x)
	{
		N += 1;
		mean = (1 - 1.0 / N) * mean + 1.0 / N * x;
	}
	

}

public static class Extensions
{

	public static int MaxIndex<T>(this IEnumerable<T> sequence)
		where T : IComparable<T>
	{
		int maxIndex = -1;
		T maxValue = default(T); // Immediately overwritten anyway

		int index = 0;
		foreach (T value in sequence)
		{
			if (value.CompareTo(maxValue) > 0 || maxIndex == -1)
			{
				maxIndex = index;
				maxValue = value;
			}
			index++;
		}
		return maxIndex;
	}

	public static IEnumerable<double> CumulativeSum(this IEnumerable<double> sequence)
	{
		double sum = 0;
		foreach (var item in sequence)
		{
			sum += item;
			yield return sum;
		}
	}

}