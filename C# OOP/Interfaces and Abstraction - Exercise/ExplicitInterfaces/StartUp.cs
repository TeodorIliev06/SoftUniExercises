using ExplicitInterfaces.Interfaces;
using ExplicitInterfaces.Models;

namespace ExplicitInterfaces;

public class StartUp
{
    static void Main(string[] args)
    {
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] citizenTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = citizenTokens[0];
            string country = citizenTokens[1];
            int age = int.Parse(citizenTokens[2]);

            IPerson citizen = new Citizen(name, age, country);
            IResident newCitizen = new Citizen(name, age, country);
            Console.WriteLine(citizen.GetName());
            Console.WriteLine(newCitizen.GetName());
        }
    }
}