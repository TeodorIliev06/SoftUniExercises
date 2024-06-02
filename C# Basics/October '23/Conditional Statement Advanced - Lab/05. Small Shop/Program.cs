using System;

public class Program
{
    public static void Main()
    {
        string product = Console.ReadLine();
        string grad = Console.ReadLine();
        double br = double.Parse(Console.ReadLine());
        if (grad == "Sofia")
        {
            if (product == "coffee") { Console.WriteLine(br * 0.50); }
            if (product == "water") { Console.WriteLine(br * 0.80); }
            if (product == "beer") { Console.WriteLine(br * 1.20); }
            if (product == "sweets") { Console.WriteLine(br * 1.45); }
            if (product == "peanuts") { Console.WriteLine(br * 1.60); }
        }
        else if (grad == "Plovdiv")
        {
            if (product == "coffee") { Console.WriteLine(br * 0.40); }
            if (product == "water") { Console.WriteLine(br * 0.70); }
            if (product == "beer") { Console.WriteLine(br * 1.15); }
            if (product == "sweets") { Console.WriteLine(br * 1.30); }
            if (product == "peanuts") { Console.WriteLine(br * 1.50); }
        }
        else if (grad == "Varna")
        {
            if (product == "coffee") { Console.WriteLine(br * 0.45); }
            if (product == "water") { Console.WriteLine(br * 0.70); }
            if (product == "beer") { Console.WriteLine(br * 1.10); }
            if (product == "sweets") { Console.WriteLine(br * 1.35); }
            if (product == "peanuts") { Console.WriteLine(br * 1.55); }
        }
    }
}