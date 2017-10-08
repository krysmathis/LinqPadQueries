<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Text.RegularExpressions.dll</Reference>
  <NuGetReference>morelinq</NuGetReference>
</Query>


int[] nums = {1,2,3};
var m = nums.Aggregate((e,next) => e+next);
m = nums.Where(x=>x>0).Aggregate ((x,y) => (y*2)+x);

m.Dump();

string sentence = "the quick brown fox jumps over the lazy dog";

// Split the string into individual words.
string[] words = sentence.Split(' ');

// Prepend each word to the beginning of the 
// new sentence to reverse the word order.
string reversed = words.Aggregate((workingSentence, next) =>
                                      workingSentence + " " + next);

Console.WriteLine(reversed);

//when to use aggregate function
// so when you want to accumlate values into a list
// where you might have used a string builder type function to append.
// or to add up values in a list
