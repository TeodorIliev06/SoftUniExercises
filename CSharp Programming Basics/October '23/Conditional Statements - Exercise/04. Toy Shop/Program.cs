using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            double price = double.Parse(Console.ReadLine());
            int puzzle = int.Parse(Console.ReadLine());
            int doll = int.Parse(Console.ReadLine());
            int bear = int.Parse(Console.ReadLine());
            int minion = int.Parse(Console.ReadLine());
            int truck = int.Parse(Console.ReadLine());

            double puzzlePrice = 2.60;
            double dollPrice = 3.0;
            double bearPrice = 4.10;
            double minionPrice = 8.20;
            double truckPrice = 2.0;

            int count = puzzle + doll + bear + minion + truck;
            double totalPrice = puzzlePrice * puzzle + bearPrice * bear 
                + dollPrice * doll + minionPrice * minion + truckPrice * truck;

            if (count >= 50) 
            { 
                price *= 0.75; 
            }

            price *= 0.9;

            if (price >= price) 
            { 
                Console.WriteLine($"Yes! {price - price:F2} lv left."); 
            }
            else 
            { 
                Console.WriteLine($"Not enough money! {price - price:F2} lv needed.");
            }
        }
    }
}
