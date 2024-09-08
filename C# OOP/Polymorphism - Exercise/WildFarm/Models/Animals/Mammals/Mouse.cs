using System.Text;
using WildFarm.Interfaces;

namespace WildFarm.Models;

public class Mouse : Mammal, IEat
{
    public Mouse(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    {
    }

    public void Eat(Food food)
    {        
        string foodType = food.GetType().Name;
        if (foodType is "Vegetable" or "Fruit")
        {
            FoodEaten += food.Quantity;
            Weight += food.Quantity * 0.10;
        }
        else
        {
            Console.WriteLine($"{GetType().Name} does not eat {foodType}!");
        }
    }

    public override void ProduceSound() => Console.WriteLine("Squeak");

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine($"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]");
        return sb.ToString().TrimEnd();
    }
}
