using Prototype.Models;
using Prototype.Repositories;

namespace Prototype;

public class Program
{
    static void Main(string[] args)
    {
        SandwichMenu sandwichMenu = new();

        sandwichMenu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");
        sandwichMenu["PB&J"] = new Sandwich("White", "", "", "Peanut Butter, Jelly");
        sandwichMenu["Turkey"] = new Sandwich("Rye", "Turkey", "Swiss", "Lettuce, Onion, Tomato");

        sandwichMenu["LoadedBLT"] = new Sandwich("Wheat", "Turkey, Bacon", "American", "Lettuce, Tomato, Onion, Olives");
        sandwichMenu["ThreeMeatCombo"] = new Sandwich("Rye", "Turkey, Ham, Salami", "Provolone", "Lettuce, Onion");
        sandwichMenu["Vegetarian"] = new Sandwich("Wheat", "", "", "Lettuce, Onion, Tomato, Onion, Spinach");

        Sandwich s1 = (Sandwich)sandwichMenu["BLT"].Clone();
        Sandwich s2 = (Sandwich)sandwichMenu["ThreeMeatCombo"].Clone();
        Sandwich s3 = (Sandwich)sandwichMenu["Vegetarian"].Clone();
    }
}
