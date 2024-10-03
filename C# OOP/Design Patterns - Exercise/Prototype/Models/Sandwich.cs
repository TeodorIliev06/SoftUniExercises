using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.Models;

public class Sandwich : SandwichPrototype
{
	private string _bread;
	private string _meat;
	private string _cheese;
	private string _veggies;

    public Sandwich(string bread, string meat, string cheese, string veggies)
    {
        Bread = bread;
        Meat = meat;
        Cheese = cheese;
        Veggies = veggies;
    }

    public string Bread
    {
        get => _bread;
        set => _bread = value;
    }
    public string Meat
    {
        get => _meat;
        set => _meat = value;
    }
    public string Cheese
    {
        get => _cheese;
        set => _cheese = value;
    }
    public string Veggies
    {
        get => _veggies;
        set => _veggies = value;
    }

    public override SandwichPrototype Clone()
    {
        string ingredients = $"{Bread}, {Meat}, {Cheese}, {Veggies}";
        Console.WriteLine($"Cloning sandwich with ingredients: {ingredients}");

        return (SandwichPrototype)MemberwiseClone();
    }
}
