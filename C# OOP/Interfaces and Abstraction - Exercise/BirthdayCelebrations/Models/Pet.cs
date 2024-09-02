using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations.Models;

public class Pet : BaseEntity, IBirthable
{
    public Pet(string name, string birthday) : base(name)
    {
        Birthday = birthday;
    }

    public string Birthday { get; set; }

    public string GetBirthday() => Birthday;
    public string GetYearFromBirthday(string birthday)
    {
        string[] parts = Birthday.Split('/');

        // Return the last part (equivalent to parts[parth.Lenght - 1])
        return parts[^1];
    }
}
