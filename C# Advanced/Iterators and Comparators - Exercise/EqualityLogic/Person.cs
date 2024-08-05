using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityLogic;

public class Person : IComparable<Person>
{
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    //Read-only properties
    public string Name { get; }
    public int Age { get; }

    public int CompareTo(Person? other)
    {
        int nameComparison = Name.CompareTo(other.Name); 
        if(nameComparison == 0) 
        {
            return Age.CompareTo(other.Age);
        }
        return nameComparison;
    }

    public override bool Equals(object obj)
    {
        if (obj is Person other)
        {
            return Name == other.Name && Age == other.Age;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode() ^ Age.GetHashCode();
    }
}
