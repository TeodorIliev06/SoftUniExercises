using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            double area = double.Parse(Console.ReadLine());

            double areaeWithoutDiscount = area * 7.61;
            double discount = areaeWithoutDiscount * 0.18;
            double price = areaeWithoutDiscount - discount;

            Console.WriteLine($"The final price is: {price} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");
        }
    }
}