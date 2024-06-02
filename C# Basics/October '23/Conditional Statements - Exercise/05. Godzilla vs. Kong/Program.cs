using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statists = int.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());

            double decor = budget * 0.1;

            if (statists > 150) 
            {
                price = price * 0.9; 
            }

            double total = decor + (price * statists);

            if (total > budget) 
            {
                Console.WriteLine("Not enough money!"); 
                Console.WriteLine($"Wingard needs {(total - budget):F2} leva more."); 
            }
            else if (total <= budget) 
            {
                Console.WriteLine("Action!"); 
                Console.WriteLine($"Wingard starts filming with {(budget - total):F2} leva left.");
            }
        }
    }
}
