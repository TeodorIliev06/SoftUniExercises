namespace BirthdayCelebrations.Models;

public abstract class BaseEntity
{
    public BaseEntity(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
