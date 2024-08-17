using Animals.Models;
using System;

namespace Animals;

public class StartUp
{
    public static void Main(string[] args)
    {
        string animalType;
        string[] animalInfo;
        while ((animalType = Console.ReadLine()) != "Beast!")
        {
            animalInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = animalInfo[0];
            int age = int.Parse(animalInfo[1]);

            if (age < 0)
            {
                Console.WriteLine("Invalid input!");
                continue;
            }

            switch (animalType)
            {
                case "Dog":
                    string dogGender = animalInfo[2];
                    Dog dog = new Dog(name, age, dogGender);
                    Console.WriteLine(animalType);
                    Console.WriteLine(dog);
                    Console.WriteLine(dog.ProduceSound());
                    break;
                case "Cat":
                    string catGender = animalInfo[2];
                    Cat cat = new Cat(name, age, catGender);
                    Console.WriteLine(animalType);
                    Console.WriteLine(cat);
                    Console.WriteLine(cat.ProduceSound());
                    break;
                case "Frog":
                    string frogGender = animalInfo[2];
                    Frog frog = new Frog(name, age, frogGender);
                    Console.WriteLine(animalType);
                    Console.WriteLine(frog);
                    Console.WriteLine(frog.ProduceSound());
                    break;
                case "Kitten":
                    Kitten kitten = default;
                    if (animalInfo.Length == 2)
                    {
                        kitten = new Kitten(name, age);
                    }
                    else
                    {
                        string kittenGender = animalInfo[2];
                        kitten = new Kitten(name, age, kittenGender);
                    }

                    Console.WriteLine(animalType);
                    Console.WriteLine(kitten);
                    Console.WriteLine(kitten.ProduceSound());
                    break;
                case "Tomcat":
                    Tomcat tomcat = default;
                    if (animalInfo.Length == 2)
                    {
                        tomcat = new Tomcat(name, age);
                    }
                    else
                    {
                        string tomcatGender = animalInfo[2];
                        tomcat = new Tomcat(name, age, tomcatGender);
                    }
                    Console.WriteLine(animalType);
                    Console.WriteLine(tomcat);
                    Console.WriteLine(tomcat.ProduceSound());
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    break;
            }
        }
    }
}
