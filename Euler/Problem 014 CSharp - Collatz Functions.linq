<Query Kind="Statements" />

Func<long, long> even = n => n / 2;
Func<long, long> odd = n => 3 * n + 1;
Func<long, bool> isOdd = n => n % 2 != 0;

long currentValue = 0;
long maxValue = 0;
long maxSequence = 0;

List<long> sequence = new List<long>();

var numberOfSteps = 0;

for (long i = 1; i <= 1000000; i++)
{
	sequence.Clear();
	currentValue = i;
	sequence.Add(i);

	while (currentValue > 1)
	{
		if (isOdd(currentValue))
			currentValue = odd(currentValue);
		else
			currentValue = even(currentValue);

		sequence.Add(currentValue);
	}

	numberOfSteps = sequence.Count();

	if (maxSequence < numberOfSteps)
	{
		maxValue = i;
		maxSequence = numberOfSteps;
	}

}

Console.WriteLine("value: {0}, count: {1}", maxValue, maxSequence);