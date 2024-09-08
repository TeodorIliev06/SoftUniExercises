using System.Text;
using WildFarm.Interfaces;

namespace WildFarm.Models;

public class Cat : Feline, IEat
{
    public Cat(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion, breed)
    {
    }

    public void Eat(Food food)
    {       
        string foodType = food.GetType().Name;
        if (foodType is "Vegetable" or "Meat")
        {
            FoodEaten += food.Quantity;
            Weight += food.Quantity * 0.30;
        }
        else
        {
            Console.WriteLine($"{GetType().Name} does not eat {foodType}!");
        }
    }

    public override void ProduceSound() => Console.WriteLine("Meow");

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine(base.ToString());
        return sb.ToString().TrimEnd();
    }
}
