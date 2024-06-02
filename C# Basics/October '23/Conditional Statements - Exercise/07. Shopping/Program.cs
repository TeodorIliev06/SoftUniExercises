using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int graphicCards = int.Parse(Console.ReadLine());
            int cpu = int.Parse(Console.ReadLine());
            int ram = int.Parse(Console.ReadLine());

            double priceGraphicCards = graphicCards * 250;
            double priceCpu = (priceGraphicCards * 0.35) * cpu;
            double priceRam = (priceGraphicCards * 0.10) * ram;
            double totalPrice = priceGraphicCards + priceCpu + priceRam;

            if (graphicCards > cpu) 
            { 
                totalPrice *= 0.85;
            }
            if (budget >= totalPrice) 
            { 
                Console.WriteLine($"You have {budget - totalPrice:F2} leva left!"); 
            }
            else 
            { 
                Console.WriteLine($"Not enough money! You need {totalPrice - budget:F2} leva more!"); 
            }
        }
    }
}
