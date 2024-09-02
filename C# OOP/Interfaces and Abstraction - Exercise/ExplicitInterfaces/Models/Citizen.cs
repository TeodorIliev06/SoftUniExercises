using ExplicitInterfaces.Interfaces;

namespace ExplicitInterfaces.Models
{
    public class Citizen : IResident, IPerson
    {
        public Citizen(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Country { get; private set; }

        string IPerson.GetName() => Name;

        string IResident.GetName() => $"Mr/Ms/Mrs {Name}";
    }
}
