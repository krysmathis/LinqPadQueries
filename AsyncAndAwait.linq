<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Text.RegularExpressions.dll</Reference>
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	StartLongRunningTask();
	
	Console.WriteLine ("Working on something else");
	
}


// Define other methods and classes here
private async void StartLongRunningTask()
	{
		int seconds= await SleepAsync(2000);
		Console.WriteLine ("I completed in: " + seconds.ToString() + " seconds");
	
	}
	
	public static Task<int> SleepAsync(int MS){
	
		return Task.Run(()=>{
			Thread.Sleep(MS);
			return MS/1000;
		});
	
	}