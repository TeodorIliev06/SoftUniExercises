﻿namespace Person;

public class Person
{
    private string name;
    private int age;


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

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} -> Name: {this.Name}, Age: {this.Age}";
    }
}