using System.Threading.Channels;
using WildFarm.Interfaces;

namespace WildFarm.Models;

public abstract class Animal
{
	private string name;
	private double weight;
	private int foodEaten;

    protected Animal(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }

    public string Name
	{
		get => name;
		protected set { name = value; }
	}
	public double Weight
	{
		get => weight;
        protected set { weight = value; }
	}
	public int FoodEaten
    {
        get => foodEaten;
        protected set { foodEaten = value; }
    }   
    public virtual void ProduceSound() => Console.WriteLine("Produce sound");
}
