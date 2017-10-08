<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
</Query>

void Main()
{

	//2x2 matrix routes
	//algo= from top row go to end and down, back up go down 1, go down, go to end and down
	//do i need to be able to define the location at any time of the x value as it traverses the matrix
	//how many time do you go down until you are at the bottom, so there are three lines in a 2x2 matrix
	
	//define the boundaries
	//have the robot always move either to the right or down, collect each unique path
	
	Random random = new Random();

	//boundaries y<3

	//if you hit x=2 then you can only go down
	//if you hit y=3 you can only go across
	//you can never go in reverse only positive

	HashSet<HashSet<Tuple<int,int>>> routes = new HashSet<HashSet<Tuple<int,int>>>();
	
	

	foreach (var v in Enumerable.Range(1, 100000))
	{
		int x = 0;
		int y = 0;


		int boundary = 20;
	

		HashSet<Tuple<int,int>> moves = new HashSet<Tuple<int,int>>();
		//Console.WriteLine("Start!");

		Tuple<int, int> start = new Tuple<int, int>(x, y);
		//moves.Add(start);

		
		while (x != boundary | y != boundary)
		{
			if (random.Next(0, 2) == 0)
			{
				if (x + 1 <= boundary)
					x++;
			}
			else
			{
				if (y + 1 <= boundary)
					y = y + 1; ;
			}

			Tuple<int, int> coords = new Tuple<int, int>(x, y);
			moves.Add(coords);

		}

		routes.Add(moves);
		Console.WriteLine(moves.Count());


	}

	//Console.WriteLine("routes: {0}",routes.Count());
	var distinct = routes.Distinct(HashSet<Tuple<int,int>>.CreateSetComparer());
	
	Console.WriteLine(distinct.Count());
	

}

// Define other methods and classes here
//20x20 matrix routes
// solution was that if you have 20 squares you have 40 moves, but divided by 20! to remove redundancies
//(40!/20!)/20! = 137846528820