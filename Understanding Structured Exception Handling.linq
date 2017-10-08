<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Text.RegularExpressions.dll</Reference>
  <NuGetReference>morelinq</NuGetReference>
</Query>

void Main()
{
	Console.WriteLine ("***** Simple Exception Example *****");
	Console.WriteLine ("=> Creating a car and stepping on it!");
	Car myCar = new Car("Zippy",20);
	myCar.CrankTunes(true);
	
	try{
	for (int i=0; i<10;i++)
		myCar.Accelerate(10);
	} catch (Exception e)
	{
		Console.WriteLine ("\n*** Error! ***");
		Console.WriteLine ("Method: {0}", e.TargetSite);
		Console.WriteLine ("Message: {0}", e.Message);
		Console.WriteLine ("Source: {0}",e.Source);
		Console.WriteLine ("Source: {0}",e.StackTrace);
		Console.WriteLine ("Source: {0}",e.HelpLink);
		foreach (DictionaryEntry de in e.Data)
			Console.WriteLine ("-> {0}:  {1}",de.Key, de.Value);
	}
	
	Console.WriteLine ("\n ****** Out of Exception Logic *****");
	
	//Console.ReadLine();
	
	
}

// Define other methods and classes here
class Radio
{
	public void TurnOn(bool on)
	{
		if(on)
			Console.WriteLine ("Jamming...");
		else
		{
			Console.WriteLine ("Quite time...");
		}
	}
}

class Car
{
	public const int MaxSpeed = 100;
	
	public int CurrentSpeed = 0;
	public string PetName  = "";
	
	private bool carIsDead;
	
	private Radio theMusicBox = new Radio();
	
	public Car() {}
	public Car(string name, int speed)
	{
		CurrentSpeed = speed;
		PetName = name;
	}
	
	public void CrankTunes(bool state)
	{
		theMusicBox.TurnOn(state);
	}
	
	public void Accelerate(int delta)
	{
		if (carIsDead)
			Console.WriteLine ("{0} is out of order...", PetName);
		else
		{
			CurrentSpeed += delta;
			if (CurrentSpeed > MaxSpeed)
			{

				CurrentSpeed = 0;
				carIsDead = true;
				//Option 1
				//throw new Exception(string.Format("{0} has overheaded!",PetName));
				
				//Option 2
				Exception ex = new Exception(string.Format("{0} has overheaded!",PetName));
				ex.HelpLink = "http://www.CarsRUs.com";
				ex.Data.Add("TimeStamp", string.Format("The car exploded at {0}",DateTime.Now));
				throw ex;
			}
			else
			{
				Console.WriteLine ("=> CurrentSpeed = {0}",CurrentSpeed);
			}
		}
	}

}