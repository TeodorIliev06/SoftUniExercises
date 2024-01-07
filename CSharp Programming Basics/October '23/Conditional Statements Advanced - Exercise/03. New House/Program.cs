using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string flower = Console.ReadLine();
            int ctr = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double price = 0;
            if (flower == "Roses")
            {
                price = ctr * 5;
                if (ctr > 80) { price *= 0.9; }
            }
            else if (flower == "Dahlias")
            {
                price = ctr * 3.80;
                if (ctr > 90) { price *= 0.85; }
            }
            else if (flower == "Tulips")
            {
                price = ctr * 2.80;
                if (ctr > 80) { price *= 0.85; }
            }
            else if (flower == "Narcissus")
            {
                price = ctr * 3;
                if (ctr < 120)
                {
                    price *= 1.15;
                }
            }
            else if (flower == "Gladiolus")
            {
                price = ctr * 2.50;
                if (ctr < 80) { price *= 1.2; }
            }
            if (price <= budget) { Console.WriteLine($"Hey, you have a great garden with {ctr} {flower} and {(budget - price):F2} leva left."); }
            else if (price > budget) { Console.WriteLine($"Not enough money, you need {(price - budget):F2} leva more."); }
        }
    }
}