using FoodShortage.Interfaces;

namespace BirthdayCelebrations.Models;

public class Pet : IBirthable
{
    public Pet(string name, string birthday)
    {
        Name = name;
        Birthday = birthday;
    }

    public string Name { get; set; }
    public string Birthday { get; set; }

    public string GetBirthday() => Birthday;
    public void GetYearFromBirthday(string birthday, string year)
    {
        if (birthday.EndsWith(year))
        {
            Console.WriteLine(birthday);
        }
    }
}
