<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Text.RegularExpressions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.dll</Reference>
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	
	TaskCreator tc = new TaskCreator();
	Reactor r = new Reactor(tc);
	
	tc.somethingHappened += r.OnSomethingHappened;
	
		
	StartLongRunningTask(tc);
	
	Console.WriteLine ("Working on something else");
	
	
	
}

interface ITaskCreator
{
	void publish();	
}

public class TaskCreator: ITaskCreator
{

		//public delegate void SomethingHappenedEventHandler(object sender, EventArgs e);
        public event EventHandler somethingHappened;
		
		public TaskCreator(){
		
		}
		
		public virtual void publish() {

            if (somethingHappened != null)
            {
                somethingHappened(this,new EventArgs());
                
            }

        }

}



// Define other methods and classes here
private async void StartLongRunningTask(ITaskCreator tc)
{
	
	int seconds= await SleepAsync(2000);
	Console.WriteLine ("I completed in: " + seconds.ToString() + " seconds");
	
	//if (somethingHappened != null){
	tc.publish();

		
	//}
	
	

}
	
public static Task<int> SleepAsync(int MS){
	
	return Task.Run(()=>{
		Thread.Sleep(MS);
		return MS/1000;
	});

}

public class Reactor
{
	
	
	public Reactor(TaskCreator tc){
	
	}
	
	public void OnSomethingHappened(object sender, EventArgs e)
        {
            Console.WriteLine("I'm shot here and now!");
			
        }
	
	

}