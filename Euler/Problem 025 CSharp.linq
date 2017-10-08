<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
</Query>

//initialize list with the first two values in the fibinocci sequence
List<System.Numerics.BigInteger> fibValues = new List<System.Numerics.BigInteger>() { 1, 1 };
while (true)
{
	//picking the last two values from the fib sequence
	System.Numerics.BigInteger nextFib = fibValues[fibValues.Count - 1] + fibValues[fibValues.Count - 2];
	
	//add the newly created value
	fibValues.Add(nextFib);
	
	//get the length of the number using this little trick
	if (Math.Floor(System.Numerics.BigInteger.Log10(nextFib)) + 1 == 1000)
		break;
}
Console.WriteLine(fibValues.Count);
//}