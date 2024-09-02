namespace BirthdayCelebrations.Models;

public class Robot : BaseEntity
{
    public Robot(string name, string id) : base(name)
    {
        Id = id;
    }

    public string Id { get; set; }
}
