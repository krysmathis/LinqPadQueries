<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
</Query>

var data =
	File.ReadAllLines(@"C:\Users\krys\Documents\projecteuler18.txt");

int[][] triangle = new int[data.Length][];
List<int> path = new List<int>();

int rows = 0;
foreach (var line in data)
{
	triangle[rows] = line.Split(' ').Select(l => Int32.Parse(l)).ToArray();
	rows++;
}

//all first values
int pathSum = triangle[0][0];
int column = 0;
int maxPath = 0;

int rightSum = 0;
int leftSum = 0;


//test right, test left
//column next then go down and test the best
//add the peak item
path.Add(triangle[0][0]);
List<int> leftValues = new List<int>();
List<int> rightValues = new List<int>();
Random rand = new Random();

for (int i = 0; i <100000; i++)
{
	path.Clear();
	column = 0;
	path.Add(triangle[0][0]);
	//starting with row 1 (second row in triangle)
	foreach (var r in Enumerable.Range(1, triangle.Length - 1))
	{
		if (rand.Next(0, 2) == 0)
			column += 1;

		path.Add(triangle[r][column]);

	}

	if (maxPath < path.Sum())
	{
		maxPath = path.Sum();
		leftValues = path.ToList();	
	}
}

Console.WriteLine(maxPath);
Console.WriteLine(leftValues);
//	leftSum = 0;
//	rightSum = 0;
//
//	
//
//	//include the original r row in the first look
//	leftValues.Clear();
//	rightValues.Clear();
//	
//	for (int forwardRow = 0; forwardRow < 15; forwardRow++)
//		{
//			//this controls for the fact that you run out of rows as you go forward
//			if (r + forwardRow < triangle.Length)
//			{
//				//max path from there
//				//try each combination underneath, once I choose one then i eliminate a lot of possibilities
//
//				//Console.WriteLine("Round {0}",r);
//				//scrolls through all the values underneath and sums them up
//				//maybe take the max values
//				for (int j = 0; j <= forwardRow; j++)
//				{
//					leftValues.Add(triangle[r + forwardRow][column + j]);
//					rightValues.Add(triangle[r + forwardRow][column + j + 1]);
//					
//					//if (triangle[r + forwardRow][column + j] >0)
//					//	leftSum += triangle[r + forwardRow][column + j];
//
//					//if (triangle[r + forwardRow][column + j + 1] >0)
//					//	rightSum += triangle[r + forwardRow][column + j + 1];
//					//summing this up
//
//					//rightSum += triangle[r + forwardRow][column + j + 1];
//				}
//
//				//Console.WriteLine($"inner: Left Sum: {leftSum}, Right Sum: {rightSum}");
//			}
//		}
//
//
//		if (leftValues.Where(x=> x>0).Sum() > rightValues.Where(x =>x>0 ).Sum()) //if (leftSum >= rightSum)
//		{
//			//Console.WriteLine(triangle[r+1][column]);
//			path.Add(triangle[r][column]);
//
//		}
//		else
//		{
//			path.Add(triangle[r][column + 1]);
//			column = column + 1;
//		}

//	}
	
	//Console.WriteLine(path);
	//Console.WriteLine(forwardLooks);
	//Console.WriteLine(path.Sum());