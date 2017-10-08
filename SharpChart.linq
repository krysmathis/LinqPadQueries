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
	int N = 50000;
	double[] r = run_experiment (1.0, 2.0, 3.0, .1, N);
	double[] r2 = run_experiment (1.0, 2.0, 3.0, .05, N);
	double[] r3 = run_experiment (1.0, 2.0, 3.0, .01, N);
	
	List<Tuple<string,double[]>> ys = new List<Tuple<string,double[]>>(){
		new Tuple<string,double[]>("series1",r),
		new Tuple<string,double[]>("series2",r2),
		new Tuple<string,double[]> ("series3",r3)

	};
	
	int[] xs = Enumerable.Range(0,r.Length).ToArray();
	
	var sp = new SharpPlot(xs, ys,1200,300);
	sp.Show();

}

// Define other methods and classes here
public class SharpPlot {
	

	readonly int[] xs_int;
	readonly int width;
	readonly int height;
	
	Chart chart = new Chart();	
	ChartArea chartArea = new ChartArea();
	

	
	public SharpPlot(int[] xs, int width= 900, int height= 300)
	{
		
		this.xs_int = xs;
		this.width = width;
		this.height = height;
	
		chart.ChartAreas.Add(chartArea);
		chart.Size = new Size(width: this.width, height: this.height);
		
	
	}
	
	public SharpPlot(int[] xs, List<double[]> ys, int width= 900, int height= 300)
	{
		
		this.xs_int = xs;
		this.width = width;
		this.height = height;
	
		chart.ChartAreas.Add(chartArea);
		chart.Size = new Size(width: this.width, height: this.height);
		
		
		ys.ForEach(x=> {
			var g = Guid.NewGuid();
			Add(x, g.ToString());
		});
		
		
	}
	
	//overload that takes tuples...
	public SharpPlot(int[] xs, List<Tuple<string,double[]>> ys, int width= 900, int height= 300)
	{
		
		this.xs_int = xs;
		this.width = width;
		this.height = height;
	
		chart.ChartAreas.Add(chartArea);
		chart.Size = new Size(width: this.width, height: this.height);
		
		chart.Legends.Add(new Legend("Legend"));
		chart.Legends["Legend"].DockedToChartArea = chartArea.Name;
		
		
		ys.ForEach(x=> {
			Add(x.Item2, x.Item1);
			
			
		});
		
		//Draw vertical line
            ChartArea CA = chartArea;
			VerticalLineAnnotation annotation = new VerticalLineAnnotation();
           //LineAnnotation annotation = new LineAnnotation();
			annotation.IsSizeAlwaysRelative = false;
			annotation.AxisX = chartArea.AxisX;
			annotation.AxisY = chartArea.AxisY;
			annotation.AnchorX = 10000;
			annotation.AnchorY = 0;
			annotation.IsInfinitive = true;
			annotation.ClipToChartArea = chartArea.Name;
			annotation.LineDashStyle= ChartDashStyle.Dot;
			annotation.LineColor = Color.Gray;
			annotation.TextStyle = TextStyle.Frame;
			//annotation.Height = 2.5;
			annotation.Width = 1;
			annotation.LineWidth = 2;
			annotation.StartCap = LineAnchorCapStyle.None;
			annotation.EndCap = LineAnchorCapStyle.None;
			chart.Annotations.Add(annotation);
			

			
			var rectangleAnnotation = new RectangleAnnotation();
			rectangleAnnotation.AxisX = chartArea.AxisX;
			rectangleAnnotation.IsSizeAlwaysRelative = false;
			//rectangleAnnotation.Width = 2000;
			//rectangleAnnotation.Height = .5;
			rectangleAnnotation.AxisY = chartArea.AxisY;
			rectangleAnnotation.Y = 1;
			rectangleAnnotation.X = 10000;
			rectangleAnnotation.Text = "LY2";
			rectangleAnnotation.ForeColor = Color.Black;
			rectangleAnnotation.BackColor = Color.Transparent;
			rectangleAnnotation.LineColor = Color.Transparent;
			rectangleAnnotation.Font = new System.Drawing.Font("Arial",8f);
			
			chart.Annotations.Add(rectangleAnnotation);


		
	}
	
	//you add ys to the value
	public void Add(double[] arr, string series_name){
		var s = new Series();
		s.Points.DataBindXY(this.xs_int,arr);
		s.Name = series_name;
		try {chart.Series.Add(s);} catch {Console.WriteLine ("name exists");}
		s.ChartType = SeriesChartType.FastLine;
		s.IsVisibleInLegend = true;
		

		
	}
	
	public void Show()
	{
		
		var frm = new Form();
		frm.ClientSize = new Size(width: this.width, height: this.height);
		frm.Controls.Add(chart);
		Application.Run(frm);
	}
	
	

}


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