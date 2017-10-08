<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Text.RegularExpressions.dll</Reference>
  <NuGetReference>morelinq</NuGetReference>
</Query>

void Main()
{
	var john = new Client
	{
		Name = "John Doe",
		Income = 40000,
		YearsInJob = 1,
		UsesCreditCard = true,
		CriminalRecord = false
	};
	
	TestClient(GetTests(),john);
}

class Client
{
	public string Name { get; set; }
	public int Income { get; set; }
	public int YearsInJob { get; set; }
	public bool UsesCreditCard { get; set; }
	public bool CriminalRecord { get; set; }
}

Func<Client, bool> isRiskyYearsInJob = client => client.YearsInJob < 2;

static List<Func<Client, bool>> GetTests()
{
	return new List<Func<Client, bool>>{
		client=> client.CriminalRecord,
		client=> client.Income < 30000,
		client=> !client.UsesCreditCard,
		client=> client.YearsInJob < 2
	};
}

void TestClient(List<Func<Client, bool>> tests, Client client)
{
	int issueCount = tests.Count(t => t(client));
	bool suitable = issueCount < 1;
	Console.WriteLine("Client: {0} \nOffer a Loan: {1}", client.Name, suitable ? "YES" : "NO");
	
}

