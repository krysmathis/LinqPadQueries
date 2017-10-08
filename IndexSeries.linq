<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Collections.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Text.RegularExpressions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.DataVisualization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.DataVisualization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
  <Namespace>System.Windows.Forms.DataVisualization.Charting</Namespace>
</Query>

void Main()
{

	SortedDictionary<int,double> sorty = new SortedDictionary<int,double>();
	sorty.Add(1,0.94);
	sorty.Add(2,0.95);
	sorty.Add(3,0.98);
	sorty.Add(4,0.88);
	sorty.Add(5,0.94);
	sorty.Add(6,0.95);
	sorty.Add(7,0.94);
	sorty.Add(8,0.95);
	sorty.Add(9,0.98);
	sorty.Add(10,0.81);
	sorty.Add(11,0.97);
	sorty.Add(12,0.94);
	sorty.Add(13,0.95);
	sorty.Add(14,0.94);
	sorty.Add(15,0.96);
	sorty.Add(16,0.97);
	sorty.Add(17,1.48);
	sorty.Add(18,0.95);
	sorty.Add(19,0.99);
	sorty.Add(20,0.88);
	sorty.Add(21,0.97);
	sorty.Add(22,0.97);
	sorty.Add(23,0.94);
	sorty.Add(24,0.96);
	sorty.Add(25,0.98);
	sorty.Add(26,0.95);
	sorty.Add(27,2.24);
	sorty.Add(28,2.27);
	sorty.Add(29,0.97);
	sorty.Add(30,0.94);
	sorty.Add(31,0.9);
	sorty.Add(32,0.95);
	sorty.Add(33,0.96);
	sorty.Add(34,0.78);
	sorty.Add(35,0.69);
	sorty.Add(36,0.91);
	sorty.Add(37,0.99);
	sorty.Add(38,0.93);
	sorty.Add(39,0.95);
	sorty.Add(40,0.93);
	sorty.Add(41,0.95);
	sorty.Add(42,0.96);
	sorty.Add(43,0.96);
	sorty.Add(44,0.9);
	sorty.Add(45,0.96);
	sorty.Add(46,0.96);
	sorty.Add(47,0.96);
	sorty.Add(48,0.96);
	sorty.Add(49,0.98);
	sorty.Add(50,0.97);
	sorty.Add(51,0.96);
	sorty.Add(52,0.95);



	
	IndexSeries indices = new IndexSeries(sorty);
	
	
	//indices.OriginalValues.Dump();
	indices.Shift(1.2,3);
	indices.Smooth(4, false,1.2);
	indices.Smooth(4, false,1.2);
	indices.Smooth(4, false,1.2);
	indices.OriginalValues.Dump();
	indices.CurrentValues.Dump();
	
	//for charting
	Dictionary<string,SortedDictionary<int,double>> valuesDict = new Dictionary<string,SortedDictionary<int,double>>();
	valuesDict.Add("Current",indices.CurrentValues);
	valuesDict.Add("Initial",indices.OriginalValues);
	
	SharpPlot plot = new SharpPlot(valuesDict);
	plot.Show();
	//index_2.Add("one",2.5);

}

// Define other methods and classes here
public class IndexSeries
{
	private SortedDictionary<int,double> indexValues = new SortedDictionary<int,double>();
	public SortedDictionary<int,double> OriginalValues {get; private set;}
	public SortedDictionary<int,double> CurrentValues {get {return indexValues;}}
	
	public IndexSeries(IEnumerable<KeyValuePair<int,double>> weekAndIndexValues)
	{
		//indexValues =  (SortedDictionary<int,double>)weekAndIndexValues;
		indexValues = Sprinkle(new SortedDictionary<int,double>(weekAndIndexValues.Where(x=> x.Key <=52).OrderBy(x=> x.Key).ToDictionary (x => x.Key, x=> x.Value )));
		OriginalValues = indexValues;
	}	
	
	public void Adder(){
	
		SortedDictionary<int,double> added = new SortedDictionary<int,double>();
		foreach (KeyValuePair<int,double> kvp in indexValues)
		{
			added[kvp.Key] = kvp.Value + 1;
		}
		indexValues = added;
	}
	
	private SortedDictionary<int,double> Sprinkle(SortedDictionary<int,double> toSprinkle)
        {
			
            SortedDictionary<int, double> sprinkled = toSprinkle;

            for (int i = 1; i < 53; i++) {
                sprinkled[i] = Math.Round(sprinkled[i] * 100, 0) / 100;
            }

            Random rnd = new Random();
            int randomWeek = 0;

            //sum of all values in the dictionary
            double valueToReallocate = Math.Round(52 - sprinkled.OrderBy(x => x.Key).Sum(x => Math.Round(x.Value, 2)), 2);
            int iterations = 0;

            while (Math.Abs(Math.Round(valueToReallocate, 2)) > 0 & iterations < 10000)
            {

                randomWeek = rnd.Next(52) + 1;

                if (valueToReallocate > 0)
                {
                    sprinkled[randomWeek] = sprinkled[randomWeek] + 0.01;
                    valueToReallocate += -0.01;
                }
                else if (valueToReallocate < 0)
                {
                    sprinkled[randomWeek] = sprinkled[randomWeek] - 0.01;
                    valueToReallocate += 0.01;
                }


                iterations++;

            }

            return sprinkled;
        }
	
	public void Shift(double peak_threshold, int shift_weeks)
        {

            IOutlierDetector outlierDetector = new OutlierDetectorStDev();

            //...converting the array of index values into a dictionary by fiscal week
            SortedDictionary<int, double> dictBaseIndexValues = OriginalValues;

            //Console.WriteLine("shifted...\n");
            SortedDictionary<int, double> shifted = shift_forward(dictBaseIndexValues);
            //PrintDictionary(shifted);

            //...stack the shifted results and send to the outlier detector
            SortedDictionary<int, double> shifted_stacked = new SortedDictionary<int, double>();
            int j = 0;

            for (int i = 1; i < 105; i++)
            {
                if (i > 52)
                    j = i - 52;
                else
                    j = i;

                shifted_stacked[j] = shifted[j];
            }

            //Console.WriteLine("outliers...\n");

            SortedDictionary<int, double> outliers = outlierDetector.DetectOutliers(shifted_stacked,peak_threshold);
            //PrintDictionary(outliers);

            List<List<int>> grouped_outliers = _grouped_peak_weeks(outliers);


            //Sprinkler.Sprinkle(peak_shifter(shifted, grouped_outliers));
            //return Sprinkler.Sprinkle(peak_shifter(shifted, grouped_outliers,shift_weeks));
			indexValues=  Sprinkle(peak_shifter(shifted,grouped_outliers,shift_weeks));

        }
		
		private SortedDictionary<int, double> peak_shifter(SortedDictionary<int, double> shifted, List<List<int>> outliers_grouped, int shift_weeks)
        {

            //...takes the shifted weekly values and the corresponding groups of weeks that need to be shifted

            //...for each group
            //...REPLACEMENT VALUES = place the values from the outlier weeks into the shifted dictionary, 
            //....using the key-3 (to simulate shifting it back in time by 3 weeks)
            //...FILL-IN VALUES = the last value + 3 weeks - have to configure this one, it could be a variable
            //...this would be the average of the value smoothed by some value

            //...Process each group

            int lastValue = 0; 

            if (outliers_grouped.Count() >0)
            {
                foreach (List<int> group in outliers_grouped)
                {
                    try
                    {
                        if (group.Count() > 1)
                        {
                            lastValue = group.Max();
                        }
                        else if (group.Count()==1)
                        {
                            lastValue = group[0];
                        }
                        
                            //...loop through the fiscal weeks in the group
                            foreach (int week in group)
                            {

                                //...the adjustment for greater than 52 allows for outlier ranges to cross 52 weeks, when using 104 weeks
                                int wk;
                                if (week > 52)
                                    wk = 52;
                                else
                                    wk = week;

                                //...take the future values and apply then to the past
                                shifted[_forecast_week(wk - shift_weeks)] = shifted[wk];

                            }

                            var fill_in_weeks = Enumerable.Range(lastValue, 4);

                            foreach (var fill_in_week in fill_in_weeks)
                                shifted[_forecast_week(fill_in_week - (shift_weeks - 1))] = (shifted[_forecast_week(fill_in_week + 1)] + shifted[_forecast_week(fill_in_week + 2)]) / 2;

                    }
                    
                    catch { }

                }
            }

                //List<string> temp = new List<string>();
                //List<double> listShifted = shifted.Values.ToList();


                //foreach (double d in listShifted)
                //    temp.Add(d.ToString());


                //System.IO.File.WriteAllLines("ShiftedPeaks.txt", temp);
            

            return shifted;
        }
		
		private SortedDictionary<int, double> shift_forward(SortedDictionary<int, double> base_index_values)
        {

            SortedDictionary<int, double> shifted_values = new SortedDictionary<int, double>();

            for (int i = 1; i < 53; i++)
            {
                //Console.WriteLine(_forecast_week(i));
                shifted_values[_forecast_week(i + 1)] = base_index_values[i];

            }

            return shifted_values;
        }
		
		private List<List<int>> _grouped_peak_weeks(SortedDictionary<int, double> outliers)
        {

            ///...here you want to create a set of lists to work with. The downstream shifting program will use this.
            ///...the basic ruls are: 1. take the first integer, this is automatically in the list
            ///...2. check the second integer in the list, if it is within x wks of the highest value in the list add it to the list
            ///...3. keep adding until a value is higher than the threshold (>3 weeks)
            ///...4. Once the program reaches a point where the next value is far enough away...
            ///......it stores the list it has accumulated and creates a new list and starts from there
            ///
            List<List<int>> listOfPeakGroups = new List<List<int>>();

            List<int> outlierWks = new List<int>(outliers.Keys);

            //PrintIntList(outlierWks);

            int position = 0;
            int maxPositions = outlierWks.Count();
            int firstValue = 0;
            //...for a list of 3 items count == 3

            List<int> currentRange = new List<int>();

            //...capture the first value, add it as first value and as the first
            //...value in the current range - which stores groups of items

            if (outliers.Count() > 0)
            {
                firstValue = outlierWks[0];
                currentRange.Add(outlierWks[0]);
            }

            foreach (int i in outlierWks)
            {

                if (!currentRange.Contains(outlierWks[position]))
                {

                    bool within_range = outlierWks[position] < currentRange.Last() + 3;
                    if (within_range)
                    {
                        currentRange.Add(outlierWks[position]);
                    }
                    else {

                        //...the next value is not in range
                        //...change current range into an enumerated range
                        listOfPeakGroups.Add(enumRange(currentRange));
                        currentRange = new List<int>();
                        currentRange.Add(outlierWks[position]);
                        firstValue = currentRange.First();

                    }


                }

                //Console.WriteLine(outlierWks[position].ToString());
                position++;
            }

            if (!listOfPeakGroups.Contains(currentRange))
                listOfPeakGroups.Add(currentRange);

            //Console.WriteLine("Peak groups = {0}", listOfPeakGroups.Count());

            if (listOfPeakGroups.Count() > 1)
            {
                foreach (List<int> l in listOfPeakGroups)
                {
                    //PrintIntList(l);
                    //...remove any invalid peak groups, those starting above 52
                    try
                    {
                        if (l.Min() > 52)
                            listOfPeakGroups.Remove(l);
                    }
                    catch { }
                }

            }

            return listOfPeakGroups;
        }
	
		private int _forecast_week(int i)
        {

            if (i == 0)
                return 52;
            else if (i % 52 == 0)
                return 52;
            else
                return i % 52; //using modulo
        }
	
		private List<int> enumRange(List<int> currentRange)
        {
            //...take the min and max values in the current range
            //...and return a list of all the values in between
            //...the + 1 ensures that the max value will be included in the list

            List<int> range = Enumerable.Range(currentRange.Min(), currentRange.Max() - currentRange.Min() + 1).ToList();

            if (currentRange.Count > 0)
            {
                return range;
            }
            else
            {
                return currentRange;
            }

        }
		
		

        public void SmoothIncludePeaks(int depth) {

            SortedDictionary<int, double> smoothedIndexValues = new SortedDictionary<int, double>();

            //...need a list hold the values to average together
            List<double> list_of_indexes_to_average = new List<double>();

            if (depth > 0) {
                foreach (KeyValuePair<int, double> index in indexValues) {

                list_of_indexes_to_average = new List<double>();
                list_of_indexes_to_average.Add(index.Value);

                    //TODO: if key is not an outlier

                    for (int i = 0; i < depth; i++) {

                        list_of_indexes_to_average.Add(indexValues[_forecast_week(index.Key + i)]);
                        list_of_indexes_to_average.Add(indexValues[_forecast_week(index.Key - 1)]);

                    }

                    smoothedIndexValues[index.Key] = list_of_indexes_to_average.Average();
                }



            } else
            {
                
                return;

            }

            indexValues = Sprinkle(smoothedIndexValues);

        }
		
		public void Smooth(int depth, bool includePeaks, double outlierThreshold = 1.5)
		{
            SortedDictionary<int, double> index_value_smoothed = new SortedDictionary<int, double>();
            SortedDictionary<int, double> outliers = new SortedDictionary<int, double>();

            //ISmoother smoother = new Smoother();
            IOutlierDetector outlierDetector = new OutlierDetectorStDev();

            outliers = outlierDetector.DetectOutliers(indexValues, outlierThreshold);

 

            if (includePeaks)
                SmoothIncludePeaks(depth);
            else
				SmoothExcludePeaks(depth, outliers);

            indexValues = Sprinkle(indexValues);
	
		}
		
        //...FIRST OVERLOAD WHICH INCLUDES OUTLIER CONTROL
        private void SmoothExcludePeaks(int depth, SortedDictionary<int,double> outliers)
        {

            SortedDictionary<int, double> smoothedIndexValues = new SortedDictionary<int, double>();

            //Take the outlier keys and turn them into a list
            //the use list contains the key to turn off the smoothing of not just have it put the value in
            List<int> outlierWeeks = new List<int>(outliers.Keys);

            //...need a list hold the values to average together
            List<double> list_of_indexes_to_average = new List<double>();

            if (depth > 0)
            {
                foreach (KeyValuePair<int, double> index in indexValues)
                {
                    list_of_indexes_to_average = new List<double>();
                    list_of_indexes_to_average.Add(index.Value);

                    //TODO: if key is not an outlier then process it otherwise just average the current value (which should result in itself).
                    if (!outlierWeeks.Contains(index.Key))
                    {
                        for (int i = 0; i < depth; i++)
                        {

                            list_of_indexes_to_average.Add(indexValues[_forecast_week(index.Key + i)]);
                            list_of_indexes_to_average.Add(indexValues[_forecast_week(index.Key - 1)]);

                        }
                    }

                    smoothedIndexValues[index.Key] = list_of_indexes_to_average.Average();
                }



            }
            else
            {
                //...if depth is zero we want an unsmoothed result
                return;

            }

            indexValues = Sprinkle(smoothedIndexValues);

        }

		
}

interface IOutlierDetector
{
   SortedDictionary<int, double> DetectOutliers(SortedDictionary<int, double> values, double st_dev_threshold);
}

class OutlierDetectorStDev : IOutlierDetector
{
   public SortedDictionary<int, double> DetectOutliers(SortedDictionary<int, double> values, double st_dev_threshold)
   {

       SortedDictionary<int, double> outliers = new SortedDictionary<int, double>();

       List<double> items = values.Select(d => d.Value).ToList();

       double average = items.Average();
       double sumSquaredDiff = items.Select(val => (val - average) * (val - average)).Sum();
       double standardDeviation = Math.Sqrt(sumSquaredDiff / (items.Count() - 1));

       int c = 1;
       //Process the outliers
       foreach (double val in items)
       {
           if (val > average + (st_dev_threshold * standardDeviation))
           {
               outliers[c] = val;
           }
           c++;
       }
       
       return outliers;
   }


}

 interface ISmoother

    {
        SortedDictionary<int, double> Smooth(SortedDictionary<int, double> index_values, int depth);
        SortedDictionary<int, double> Smooth(SortedDictionary<int, double> index_values, int depth,SortedDictionary<int,double> outliers);
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
	
	public SharpPlot(Dictionary<string, SortedDictionary<int,double>> xys, int width= 900, int height= 300)
	{
		
		this.width = width;
		this.height = height;
	
		chart.ChartAreas.Add(chartArea);
		chart.Size = new Size(width: this.width, height: this.height);
		
		
		chart.Legends.Add(new Legend("Legend"));
		chart.Legends["Legend"].DockedToChartArea = chartArea.Name;
		
		foreach (KeyValuePair<string,SortedDictionary<int,double>> d in xys)
		{
			//string firstKey = xys.FirstOrDefault (x => x.Key.ToString());
			this.xs_int = new int[xys[d.Key].Count ()];
			double[] ys = new double[xys[d.Key].Count ()];
			int c = 0;
			foreach (KeyValuePair<int,double> kvp in xys[d.Key]){
				// int key
				this.xs_int[c]= kvp.Key;
				// double value
				ys[c] = kvp.Value;
				c++;
			}
				Add(ys,d.Key);
				
		}
		
		// set chart x axis min and max
		var min = xs_int.Min ( );
		chart.ChartAreas[0].AxisX.Minimum=min;
		
		var max = xs_int.Max();
		chart.ChartAreas[0].AxisX.Maximum=max;
		
	
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
		
	}
	
	//you add ys to the value
	public void Add(double[] arr, string series_name){
		var s = new Series();
		s.Points.DataBindXY(this.xs_int,arr);
		s.Name = series_name;
		try {chart.Series.Add(s);} catch {Console.WriteLine ("name already exists");}
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