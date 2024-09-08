using System.Text;
using WildFarm.Interfaces;

namespace WildFarm.Models;

public class Tiger : Feline, IEat
{
    public Tiger(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion, breed)
    {
    }

    public void Eat(Food food)
    {       
        string foodType = food.GetType().Name;
        if (foodType == "Meat") 
        {
            FoodEaten += food.Quantity;
            Weight += food.Quantity;
        }
        else
        {
            Console.WriteLine($"{GetType().Name} does not eat {foodType}!"); 
        }
    }

    public override void ProduceSound() => Console.WriteLine("ROAR!!!");

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine(base.ToString());
        return sb.ToString().TrimEnd();
    }
}
