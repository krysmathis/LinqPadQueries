<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
</Query>




DateTime startValue = new DateTime(1901,1,1);
DateTime endValue = new DateTime(2000, 12, 31);

DateTimeOffset dateOffset = new DateTimeOffset(startValue);

int firstAndSundayCounter = 0;

bool isSunday;
bool isFirstOfMonth;

for (int i = 0; i <= (endValue - startValue).Days; i++) 
{	
	isSunday = startValue.AddDays(i).DayOfWeek == DayOfWeek.Sunday;
	isFirstOfMonth = startValue.AddDays(i).Day.ToString("d") == "1";
	
	if (isSunday & isFirstOfMonth) {
		firstAndSundayCounter += 1;
	}

}

Console.WriteLine(firstAndSundayCounter);
