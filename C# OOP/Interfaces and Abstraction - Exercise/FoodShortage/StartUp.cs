using BirthdayCelebrations.Models;
using FoodShortage.Interfaces;

namespace BirthdayCelebrations;

public class StartUp
{
    static void Main(string[] args)
    {
        List<IBuyer> livingEntities = new();
        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            string[] entityTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = entityTokens[0];
            int age = int.Parse(entityTokens[1]);
            if (entityTokens.Length == 3)
            {
                string group = entityTokens[2];
                livingEntities.Add(new Rebel(name, age, group));
            }
            else
            {
                string id = entityTokens[2];
                string birthday = entityTokens[3];
                livingEntities.Add(new Citizen(name, age, id, birthday));
            }
        }

        int sum = 0;
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            if (livingEntities.Any(x => x.Name == input))
            {
                IBuyer buyer = livingEntities.First(x => x.Name == input);

                buyer.BuyFood();
                sum += buyer.BuyFood();
            }
        }
        Console.WriteLine(sum);
    }
}