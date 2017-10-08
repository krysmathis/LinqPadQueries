<Query Kind="Program" />

void Main()
{
	var data = 
		File.ReadAllLines(@"C:\Users\krys\Documents\projecteuler11.txt");
	
	//int[][] workon = data.Replace("\r", "").Split('\n').Select(n=>n.Split(' ').Select(m=>Int32.Parse(m)).ToArray()).ToArray(); //turning input into 2d int array
	Dictionary<int,int[]> rowData = new Dictionary<int,int[]>();
	
	int rows = 0;
	foreach (var line in data) {
		rowData[rows] = line.Split(' ').Select(l => Int32.Parse(l)).ToArray();
		rows++;
	}
	
	int columns = 19;

	long product = 0;
	long highestValue = 0;
	
	//Diagonals down
	for (int r = 0; r < rows; r++)
	{
		if (r < rows - 3)
		{
			foreach (var c in Enumerable.Range(0, rows - 3))
			{
				product = 					
					Math.Max(product,rowData[r][c] * rowData[r + 1][c + 1] * rowData[r + 2][c + 2] * rowData[r + 3][c + 3])
				
			}

			//Diagonal up
			foreach (var c in Enumerable.Range(0, rows - 3))
			{
				product =
					Math.Max(product,rowData[r + 3][c] *
					rowData[r + 2][c + 1] *
					rowData[r + 1][c + 2] *
					rowData[r][c + 3]);
			}

			//Verticals
			foreach (var c in Enumerable.Range(0, rows))
			{
				product =
					Math.Max(product,rowData[r][c] *
					rowData[r + 1][c] *
					rowData[r + 2][c] *
					rowData[r + 3][c]);

				if (highestValue < product) highestValue = product;

			}

		}
		else
		{
			//Horizontals
			//TODO: i to r and r to c
			foreach (var c in Enumerable.Range(0, rows - 3))
			{
				product =
					Math.Max(product,rowData[r][c] *
					rowData[r][c + 1] *
					rowData[r][c + 2] *
					rowData[r][c + 3]);

				if (highestValue < product) highestValue = product;
			}

			
		}

	}

	
	Console.WriteLine(product);

}

// Define other methods and classes here