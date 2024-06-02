using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string grade = Console.ReadLine();
            double price = 0;
            if (type == "room for one person")
            {
                price = 18 * (days - 1);
                if (grade == "positive") { price *= 1.25; }
                else if (grade == "negative") { price *= 0.9; }
            }
            else if (type == "apartment")
            {
                price = 25 * (days - 1);
                if (days < 10) { price *= 0.7; }
                else if (days < 15 && days > 10) { price *= 0.65; }
                else if (days > 15) { price *= 0.50; }
                if (grade == "positive") { price *= 1.25; }
                else if (grade == "negative") { price *= 0.9; }
            }
            else if (type == "president apartment")
            {
                price = 35 * (days - 1);
                if (days < 10) { price *= 0.9; }
                else if (days < 15 && days > 10) { price *= 0.85; }
                else if (days > 15) { price *= 0.80; }
                if (grade == "positive") { price *= 1.25; }
                else if (grade == "negative") { price *= 0.9; }
            }
            Console.WriteLine($"{price:F2}");
        }
    }
}
