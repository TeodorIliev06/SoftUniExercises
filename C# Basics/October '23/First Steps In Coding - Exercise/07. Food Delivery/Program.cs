using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int chicken = int.Parse(Console.ReadLine());
            int fish = int.Parse(Console.ReadLine());
            int veg = int.Parse(Console.ReadLine());

            double pricechicken = 10.35;
            double pricefish = 12.40;
            double priceveg = 8.15;

            double sum = chicken * pricechicken + fish * pricefish + veg * priceveg;
            double desert = sum * 0.2;
            double delivery = 2.5;

            Console.WriteLine(sum + desert + delivery);
        }
    }
}
