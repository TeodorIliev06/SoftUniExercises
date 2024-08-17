namespace Animals.Models;

internal class Animal
{
    private string name;
    private int age;
    private string gender;

    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public Animal(string name, int age, string gender) : this(name, age)
    {
        Gender = gender;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public string Gender
    {
        get { return gender; }
        set { gender = value; }
    }

    public virtual string ProduceSound() => default;

    public override string ToString() => $"{Name} {Age} {Gender}";
}
