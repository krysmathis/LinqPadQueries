<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
</Query>

Dictionary<int,string> numbers = new Dictionary<int,string>();

numbers[1] = "one";
numbers[2] = "two";
numbers[3] = "three";
numbers[4] = "four";
numbers[5] = "five";
numbers[6] = "six";
numbers[7] = "seven";
numbers[8] = "eight";
numbers[9] = "nine";
numbers[10] = "ten";
numbers[11] = "eleven";
numbers[12] = "twelve";
numbers[13] = "thirteen";
numbers[14] = "fourteen";
numbers[15] = "fifteen";
numbers[16] = "sixteen";
numbers[17] = "seventeen";
numbers[18] = "eighteen";
numbers[19] = "nineteen";
numbers[20] = "twenty";
numbers[30] = "thirty";
numbers[40] = "forty";
numbers[50] = "fifty";
numbers[60] = "sixty";
numbers[70] = "seventy";
numbers[80] = "eighty";
numbers[90] = "ninety";

//build the rest of the dictionary to fill in between 21..29, 31..39...
for (int i = 2; i < 10; i++)
{
	foreach (var v in Enumerable.Range(1, 9))
	{
		numbers[(i) * 10 + v] = numbers[(i) * 10] + numbers[v];
	}		
}


var oneTo99 = 0;
foreach (var y in Enumerable.Range(1, 99)) 
{
	oneTo99 += numbers[y].Length;
}

var justHundreds = 0;
foreach (var z in Enumerable.Range(1, 9)) 
{
	justHundreds += (numbers[z] + "hundred").Length;
}

var allHundreds = 0;
foreach (var a in Enumerable.Range(1, 9))
{
	allHundreds += (numbers[a] + "hundredand").Length * 99 + oneTo99;
}

var oneThousand = "onethousand".Length;

Console.WriteLine(oneTo99 + justHundreds + allHundreds + oneThousand);