<Query Kind="Program" />

void Main()
{
	// using delegates as an example
	 //returnLength;
//	returnLength = delegate (string text) { return text.Length;};


	// first lambda
	//returnLength = (string text) => { return text.Length;};
	
	// new lamda
	//returnLength = t => t.Length;
	// also try
	Func<string, int> returnLength = text => text.Length;
	Console.WriteLine(returnLength("Hello"));
	
}