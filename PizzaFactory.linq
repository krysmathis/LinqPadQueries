<Query Kind="Program" />

void Main()
{
	PizzaStore nyPizzaStore = new NYPizzaStore();
	nyPizzaStore.orderPizza(PizzaType.cheese);
	
}


// Define other methods and classes here
public abstract class PizzaStore
{

	public Pizza orderPizza(PizzaType type) {
		Pizza pizza;
		
		pizza = createPizza(type);
		
		
		pizza.prepare();
		pizza.bake();
		pizza.cut();
		pizza.box();
		
		return pizza;
	}

	public abstract Pizza createPizza(PizzaType type);
	
	

}

public class NYPizzaStore : PizzaStore {
 	
	public override Pizza createPizza(PizzaType type) {
	
	Pizza pizza = null;

		if (type == PizzaType.cheese) {
			pizza = new NYStyleCheesePizza();
			
		}

		return pizza;

	}


}

public class NYStyleCheesePizza : Pizza {

	public NYStyleCheesePizza() : base (
		name: "cheese", 
		dough: "thin crust",
		sauce: "marinara sauce",
		toppings: new List<string> { "grated reggiano"})
	
	{
	}

	public override void cut() {
		Console.WriteLine("Cutting into squares...");
	}
		

	
}

public abstract class Pizza
{
	public string pizzaName;
	public string dough;
	public string sauce;
	public List<string> toppings;

	public Pizza(string name, string dough, string sauce, List<string> toppings) {
		this.pizzaName = name;
		this.dough = dough;
		this.sauce = sauce;
		this.toppings = toppings;
	} 

	public virtual void prepare() {
		Console.WriteLine("Preparing..");
	}

	public virtual void bake() {
		Console.WriteLine("Baking...");
	}

	public virtual void cut() {
		Console.WriteLine("Cutting...");
	}
	public virtual void box() {
		Console.WriteLine("Boxing...");
	}

	public String getName() {
		return pizzaName;
	}

}

public enum PizzaType
{
	cheese,
	ocean
}
public class NYStylePizzaFactory
{

	public Pizza createPizza(PizzaType type)
	{

		Pizza pizza = null;

		if (type == PizzaType.cheese) {
			pizza = new NYStyleCheesePizza();
			
		}
	
	return pizza;
	
	}

}
