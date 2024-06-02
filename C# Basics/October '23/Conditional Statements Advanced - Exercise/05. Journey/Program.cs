using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string seazon = Console.ReadLine();
            string place = string.Empty;
            double sum = 0;
            if (budget <= 100 && seazon == "summer") { sum = budget * 0.3; Console.WriteLine("Somewhere in Bulgaria"); Console.WriteLine($"Camp - {sum:F2}"); }
            else if (budget <= 100 && seazon == "winter") { sum = budget * 0.7; Console.WriteLine("Somewhere in Bulgaria"); Console.WriteLine($"Hotel - {sum:F2}"); }
            else if (budget > 100 && budget <= 1000 && seazon == "summer") { sum = budget * 0.4; Console.WriteLine("Somewhere in Balkans"); Console.WriteLine($"Camp - {sum:F2}"); }
            else if (budget > 100 && budget <= 1000 && seazon == "winter") { sum = budget * 0.8; Console.WriteLine("Somewhere in Balkans"); Console.WriteLine($"Hotel - {sum:F2}"); }
            else if (budget > 1000) { sum = budget * 0.9; Console.WriteLine("Somewhere in Europe"); Console.WriteLine($"Hotel - {sum:F2}"); }
        }
    }
}