<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
</Query>

var data =
	File.ReadAllLines(@"C:\Users\krys\Documents\ProjectEuler18.txt");

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

int rightSum = 0;
int leftSum = 0;
int bestLeft = 0;
int bestRight = 0;
int left = 0;
int right = 0;



//test right, test left
//column next then go down and test the best
//add the peak item
path.Add(triangle[0][0]);
List<int> leftValues = new List<int>();
List<int> rightValues = new List<int>();

//starting with row 1 (second row in triangle)
foreach (var r in Enumerable.Range(1, triangle.Length - 1))
{

	leftSum = 0;
	rightSum = 0;

	//include the original r row in the first look
	leftValues.Clear();
	rightValues.Clear();

	//going to go down 2 rows ahead
	if (r + 2 < triangle.Length - 1)
	{
	
	int forwardRow = 2;
		for (int i = 0; i < 2; i++)
		{
			int toggleIncrementer = 0;
			for (int toggle = 0; toggle < 2; toggle++)
			{
				
				left = triangle[r][column] + triangle[r + forwardRow][column + i] + triangle[r + forwardRow + 1][column + (toggle + toggleIncrementer + i)];
				toggleIncrementer++;
				Console.WriteLine($"left = {left}");
				if (bestLeft< left)
					bestLeft = left;
			}
			// if this value is greater than existing use otherwise use new
		}
	
		left = triangle[r][column]+Math.Max(
			Math.Max(triangle[r + 1][column] + triangle[r+2][column], 
			triangle[r + 1][column] + triangle[r+2][column+1]),Math.Max(
			triangle[r + 1][column + 1]+triangle[r+2][column+1],
			triangle[r + 1][column + 1]+triangle[r+2][column+2])
			);
		
		right = triangle[r][column+1]+Math.Max(
			Math.Max(triangle[r + 1][column + 1] + triangle[r+2][column+1], 
			triangle[r + 1][column + 1] + triangle[r+2][column+2]),Math.Max( 
			triangle[r + 1][column + 2] + triangle[r+2][column+2],
			triangle[r+1][column + 2] + triangle[r+2][column+3]));
	}
	else
	{
		left = triangle[r][column];
		right = triangle[r][column+1];
	}
	
	if (left > right)
	{
		//path.Add(triangle[r][column]);
		Console.WriteLine("left");
	}
	else
	{
		column = column + 1;
		Console.WriteLine("right");
	}
	
	path.Add(triangle[r][column]);

		
	}

	Console.WriteLine(path);
	//Console.WriteLine(forwardLooks);
	Console.WriteLine(path.Sum());