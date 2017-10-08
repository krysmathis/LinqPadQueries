<Query Kind="Program">
  <Namespace>MoreLinq</Namespace>
  <AppConfig>
    <Path>&lt;ProgramFilesX86&gt;\LINQPad5\LPRun.exe.config</Path>
  </AppConfig>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{
	//LINQ Operators
		
		
		//Any
		//the Any operator returns true if there is a single element
		//in a collection that matches the given condition
		int[] nums = { 14, 21, 24, 51, 131, 11, 54};
		bool isAny = nums.Any(n=> n >= 150);
		
		//All
		//The all operator is useful when you want to check whether all elements
		//ina collection match a given condition
		bool isAll = nums.All(n=> n <150);
		Console.WriteLine("isAll {0}", isAll);
		
		//Take
		//Selects the first specified number of elements from the given collection
		int[] first4 = new int[4];
		first4 = nums.Take(4).ToArray().Dump("Take Operator");
		
		//Skip
		//picks all except the first k elements from a collection
		int[] skip4 = new int[nums.Length - 4];
		skip4 = nums.Skip(4).ToArray();
		skip4.Dump("Skip");
		
		//TakeWhile
		//Enables you to take elements from a collection as long as a
		//given condition is true
		List<int> until50 = new List<int>();
		until50 = nums.TakeWhile(n=> n < 50).ToList().Dump("TakeWhile");
		
		//SkipWhile
		List<int> skipWhileDivisibleBy7 = nums.SkipWhile(n => n % 7 == 0).ToList();
		skipWhileDivisibleBy7.Dump("SkipWhile");
		
		//Where
		int[] above50 = nums.Where(n => n > 50).ToArray();
		above50.Dump("Where");
		
		//Zip
		//The zip operator applies a specified function to the corresponding elements of
		//two sequences to generate a result sequence
		string[] salutations = { "Mr.", "Mrs.", "Master.", "Ms." };
		string[] names = { "Patrick", "Nancy", "Jon", "Jane"};
		salutations.Zip(names,(salutation,name) => salutation + " " + name + " Smith").Dump("Zip");
		salutations.Zip(names,(s,n) => s + " " + n + " Smith").Dump("Zip Shortened");
		
		//OrderBy
		string[] codes = { "abc", "bc", "a", "d", "abcd"};
		List<string> codesAsList = codes.OrderBy(item => item.Length ).ToList();
		codesAsList.Dump("OrderBy Length of string");
		
		//Distinct
		string[] names2 = { "Sam", "David", "Sam", "Eric", ""};
		List<string> distinctNames = names2.Distinct().ToList();
		distinctNames.Dump("Distince Names");
		
		//Union
		string[] names3 = { "Sam", "David", "Eric", "Sam", "Daniel", "Sam" };
		string[] names4 = { "David", "Eric", "Samuel"};
		List<string> unionNames= names3.Union(names4).ToList().Dump("Union");
		
		//Intersect
		var commonNames = names4.Intersect(names3).ToList().Dump("Intersect");
		
		//Except
		//Exclusive strings, in one list but not another
		//uses default comparer, you have to create a custom comparer otherwise
		List<string> exclusiveNames = new List<string>();
		exclusiveNames= names3.Except(names4).ToList();
		exclusiveNames.Dump("Except");
		
		
		//Concat
		//concatenates two sequences together back to back
		string[] names5 = names3.Concat(names4).ToArray().Dump("Concat");
		
		//SequenceEqual
		//Checks whether two sequences have the same element at each index starting from the 0th index and maintaining order
		int[] codes2 = { 343, 2132, 12, 32143, 234 };
		int[] expected = { 343, 2132, 12, 32143, 234 };
		codes2.SequenceEqual(expected).Dump("SequenceEqual");
		//alternative
		bool all = codes2.All(x=>expected.Contains(x)).Dump("Alternate to check sequence out of order");
		
		//OfType
		object[] things = { "Sam", 1, DateTime.Today, "Eric"};
		things.OfType<string>().Dump("OfType");
		
		//Cast
		object[] things1 = { "Sam", "Dave", "Greg", "Travis", "Dan", 2};
		things1.Select (t => t as string)
		.Where (t => t!= null)
		.Cast<string>()
		.Dump("Cast");
		
		//Aggregate
		names.Aggregate((f,s) => f + "," + s).Dump("Aggregate");
		
		//SelectMany
		//A way to replace nested loops
		//string[] words = { "dog", "elephant", "fox", "bear" };
		//List<char> allChars = new List<char>();
		//foreach (string word1 in words)
		//{
		//	allChars.Add(word1.ToCharArray());
		//}
		//
		//words.SelectMany(w => w.ToCharArray()).Dump();
		
		//Parallel processing
		Stopwatch w = new Stopwatch();
		w.Start();
		List<int> Qs = new List<int>();
		List<int> Qsp = new List<int>();
		
		for (int i = 0; i <2;i++)
			Qs  = Enumerable.Range(1,10000).AsParallel().Where(d=>Enumerable.Range(2,d/2)
			.All(e=> d % e!=0)).ToList();
		
		w.Stop();
		Console.WriteLine(w.Elapsed.TotalMilliseconds);
		
		
		
		//*** MORE LINQ ***
		int[] mLnumbers = {1,4,5};
		mLnumbers.Scan((a,b)=>a+b).Last ().Dump("Last");
	
	
	// Define other methods and classes here
}

// Define other methods and classes here
