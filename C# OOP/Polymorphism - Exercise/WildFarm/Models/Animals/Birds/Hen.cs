using System.Text;
using WildFarm.Interfaces;

namespace WildFarm.Models;

public class Hen : Bird, IEat
{
    public Hen(string name, double weight, double wingSize)
        : base(name, weight, wingSize)
    {
    }

    public void Eat(Food food) 
    { 
        FoodEaten += food.Quantity;
        Weight += food.Quantity * 0.35; 
    }

    public override void ProduceSound() => Console.WriteLine("Cluck");

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine(base.ToString());
        return sb.ToString().TrimEnd();
    }
}
