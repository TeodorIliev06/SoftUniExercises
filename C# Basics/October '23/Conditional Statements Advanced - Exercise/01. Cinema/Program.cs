using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string projection = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            double price = 0;
            if (projection == "Premiere") { price = 12.00 * rows * cols; }
            else if (projection == "Normal") { price = 7.50 * rows * cols; }
            else if (projection == "Discount") { price = 5.00 * rows * cols; }
            Console.WriteLine($"{price:F2} leva");
        }
    }
}