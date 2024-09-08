using System.Text;
using WildFarm.Interfaces;

namespace WildFarm.Models;

public class Owl : Bird, IEat
{
    public Owl(string name, double weight, double wingSize) 
        : base(name, weight, wingSize)
    {
    }

    public void Eat(Food food)
    {       
        string foodType = food.GetType().Name;
        if (foodType == "Meat")
        {
            FoodEaten += food.Quantity;
            Weight += food.Quantity * 0.25;
        }
        else
        {
            Console.WriteLine($"{GetType().Name} does not eat {foodType}!");
        }
    }

    public override void ProduceSound() => Console.WriteLine("Hoot Hoot");

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine(base.ToString());
        return sb.ToString().TrimEnd();
    }
}
