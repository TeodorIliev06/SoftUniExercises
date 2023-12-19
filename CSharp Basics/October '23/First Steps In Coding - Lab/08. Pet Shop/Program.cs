using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogFood = int.Parse(Console.ReadLine());
            int catFood = int.Parse(Console.ReadLine());

            double catFoodPrice = catFood * 4;
            double dogFoodPrice = dogFood * 2.5;
            double totalPrice = dogFoodPrice + catFoodPrice;

            Console.WriteLine(totalPrice + " lv.");
        }
    }
}