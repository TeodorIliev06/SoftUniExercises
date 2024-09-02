using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations;

public class StartUp
{
    static void Main(string[] args)
    {
        List<IBirthable> livingEntities = new();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] entityTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string type = entityTokens[0];
            string name = entityTokens[1];
            string birthday;

            switch (type)
            {
                case "Citizen":
                    int age = int.Parse(entityTokens[2]);
                    string id = entityTokens[3];
                    birthday = entityTokens[4];
                    Citizen citizen = new Citizen(name, age, id, birthday);
                    livingEntities.Add(citizen);
                    break;
                case "Pet":
                    birthday = entityTokens[2];
                    Pet pet = new Pet(name, birthday);
                    livingEntities.Add(pet);
                    break;
                //We don't do anything if we receive a robot
                case "Robot":
                    break;
            }
        }

        string yearFilter = Console.ReadLine();
        foreach (var entity in livingEntities.Where(e => e.GetYearFromBirthday(e.GetBirthday()) == yearFilter))
        {
            Console.WriteLine(entity.GetBirthday());
        }
    }
}