namespace BirthdayCelebrations.Models.Interfaces;

public interface IBirthable
{
    string GetBirthday();
    string GetYearFromBirthday(string birthday);
}
