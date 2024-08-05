namespace ComparingObjects;

public class Person : IComparable<Person>
{
    //Properties are read-only
    public string Name { get; }
    public int Age { get; }
    public string Town { get; }

    public Person(string name, int age, string town)
    {
        Name = name;
        Age = age;
        Town = town;
    }

    public int CompareTo(Person? other)
    {
        if (other == null)
            return 1;

        int nameComparison = Name.CompareTo(other.Name);
        if (nameComparison == 0)
        {
            int ageComparison = Age.CompareTo(other.Age);
            if (ageComparison == 0)
            {
                return Town.CompareTo(other.Town);
            }
            return ageComparison;
        }
        return nameComparison;
    }
}
