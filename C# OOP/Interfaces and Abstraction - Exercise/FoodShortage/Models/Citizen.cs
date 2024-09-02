using FoodShortage.Interfaces;

namespace BirthdayCelebrations.Models;

public class Citizen : IBirthable, IBuyer
{
    public Citizen(string name, int age, string id, string birthday)
    {
        Name = name;
        Age = age;
        Id = id;
        Birthday = birthday;
        Food = 0;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public string Id { get; set; }
    public string Birthday { get; set; }
    public int Food { get; set; }

    public string GetBirthday() => Birthday;
    public void GetYearFromBirthday(string birthday, string year)
    {
        if (birthday.EndsWith(year))
        {
            Console.WriteLine(birthday);
        }
    }
    
    public int BuyFood()
    {
        Food += 10;
        return 10;
    }

    public int ReturnFood() => Food;
}
