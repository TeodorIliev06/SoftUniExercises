namespace BorderControl.Models;

public class Citizen : BaseEntity
{
    public Citizen(string name, int age, string id)
    {
        Name = name;
        Age = age;
        Id = id;
    }
    public int Age { get; set; }
    public string Name { get; set; }
}
