using System;

namespace P03.Detail_Printer;

public class Employee
{
    public Employee(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    public virtual void Print() => Console.WriteLine(Name);
}
