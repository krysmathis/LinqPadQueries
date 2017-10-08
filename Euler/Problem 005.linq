<Query Kind="Program" />

//2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder
//What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20 ?

void Main()
{
	long x = 20;

//    foreach (long a in Enumerable.Range(20, 1000000000).Where(y => y % 5 == 0 & y%2==0)) {
//        
//		if (isEvenlyDivisible(a))
//                {
//			x = a;
//			break;
//		}
//	}
//
//	Console.WriteLine(x);

	while (true) {

		if (x % 5 == 0 & x % 2 == 0)
			if (Enumerable.Range(1, 20).All(i => x % i == 0))
				break;

		x++;
	}
	
	Console.WriteLine(x);
}

public static bool isEvenlyDivisible(long x)
{

	foreach (long y in Enumerable.Range(1, 20))
		if (x % y > 0)
			return false;

	return true;
}