<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
</Query>

//System.Numerics.BigInteger big = System.Numerics.BigInteger.Pow(2,1000);
//
//string bigText = big.ToString();
//
////Console.WriteLine(bigText);
//
//int sum = 0;
//
//foreach (char s in bigText.ToString()) {
//	sum = sum + Convert.ToInt32(s.ToString());
//}
//
//Console.WriteLine(sum);

Console.WriteLine(System.Numerics.BigInteger.Pow(2,1000).ToString().ToCharArray().Sum(x=>Convert.ToInt32(x.ToString())));