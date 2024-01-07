using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            double degrees = double.Parse(Console.ReadLine());
            string time = Console.ReadLine();
            string outfit = "";
            string shoes = "";

            if (degrees >= 10 && degrees <= 18)
            {
                if (time == "Morning") { outfit = "Sweatshirt"; shoes = "Sneakers"; }
                if (time == "Afternoon") { outfit = "Shirt"; shoes = "Moccasins"; }
                if (time == "Evening") { outfit = "Shirt"; shoes = "Moccasins"; }
            }
            else if (degrees > 18 && degrees <= 24)
            {
                if (time == "Morning") { outfit = "Shirt"; shoes = "Moccasins"; }
                if (time == "Afternoon") { outfit = "T-Shirt"; shoes = "Sandals"; }
                if (time == "Evening") { outfit = "Shirt"; shoes = "Moccasins"; }
            }
            else if (degrees >= 25)
            {
                if (time == "Morning") { outfit = "T-Shirt"; shoes = "Sandals"; }
                if (time == "Afternoon") { outfit = "Swim Suit"; shoes = "Barefoot"; }
                if (time == "Evening") { outfit = "Shirt"; shoes = "Moccasins"; }
            }
            Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
        }
    }
}