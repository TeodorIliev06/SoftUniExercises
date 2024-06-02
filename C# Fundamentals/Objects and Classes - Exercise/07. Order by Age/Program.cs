using System;

namespace _07._Order_by_Age;

internal class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new();

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] personTokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = personTokens[0];
            int id = int.Parse(personTokens[1]);
            int age = int.Parse(personTokens[2]);

            Person renamePerson = people.FirstOrDefault(x => x.ID == id);

            if (renamePerson != null)
            {
                renamePerson.Name = name;
                renamePerson.Age = age;
            }
            else
            {
                people.Add(new Person(name, id, age));
            }
        }

        people = people.OrderBy(x => x.Age).ToList();
        people.ForEach(p => Console.WriteLine($"{p.Name} with ID: {p.ID} is {p.Age} years old."));
    }
}
public class Person
{
    public Person(string name, int id, int age)
    {
        Name = name;
        ID = id;
        Age = age;
    }
    public string Name { get; set; }
    public int ID { get; set; }
    public int Age { get; set; }
    public string HomeTown { get; set; }
}