using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Oldest_Family_Member
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Family family = new Family();
            string input;

            for (int i = 0; i < count; i++)
            {
                input = Console.ReadLine();
                string[] inputData = input.Split();
                string name = inputData[0];
                int age = int.Parse(inputData[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }

            Console.WriteLine($"{family.GetOldestMember()}");
        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }

    class Family
    {
        public Family()
        {
            People = new List<Person>();
        }

        public List<Person> People { get; set; }

        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public Person GetOldestMember()
        {
            return People.OrderByDescending(p => p.Age).FirstOrDefault();
        }        
    }
}
