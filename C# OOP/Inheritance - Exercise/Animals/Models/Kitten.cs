namespace Animals.Models;

internal class Kitten : Cat
{
    private string gender;

    public string Gender
    {
        get { return gender; }
        set { gender = value; }
    }
    public Kitten(string name, int age) : base(name, age)
    {
        Gender = "Female";
    }
    public Kitten(string name, int age, string gender) : base(name, age, gender)
    {
        Gender = "Female";
    }

    public override string ProduceSound() => "Meow";
}
