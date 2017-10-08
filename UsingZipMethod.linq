<Query Kind="Statements" />

//var letters = new string[] { "A", "B", "C", "D", "E" };
//var numbers = new int[] { 1, 2, 3 };
//var q = letters.Zip(numbers, (l, n) => l + n.ToString());
//foreach (var s in q)
//	Console.WriteLine(s);


var letters2 = Enumerable.Range(5,10);
var numbers2 = new List<int>() { 1, 2, 3,5};

var z1 = letters2.Zip(numbers2, (a, b) => a + b.ToString());

foreach (var z in z1) {
	Console.WriteLine(z);
}
