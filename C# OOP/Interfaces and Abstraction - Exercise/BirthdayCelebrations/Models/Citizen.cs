using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations.Models;

public class Citizen : BaseEntity, IBirthable
{
    public Citizen(string name, int age, string id, string birthday) : base(name)
    {
        Age = age;
        Id = id;
        Birthday = birthday;
    }

    public int Age { get; set; }
    public string Id { get; set; }
    public string Birthday { get; set; }

    public string GetBirthday() => Birthday;
    public string GetYearFromBirthday(string birthday)
    {
        string[] parts = Birthday.Split('/');

        // Return the last part (equivalent to parts[parth.Lenght - 1])
        return parts[^1];
    }
}
