namespace Animals.Models;

internal class Tomcat : Cat
{
    private string gender;

    public string Gender
    {
        get { return gender; }
        set { gender = value; }
    }
    public Tomcat(string name, int age) : base(name, age)
    {
        Gender = "Male";
    }

    public Tomcat(string name, int age, string gender) : base(name, age, gender)
    {
        Gender = "Male";
    }

    public override string ProduceSound() => "MEOW";
}
