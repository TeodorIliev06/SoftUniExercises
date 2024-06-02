using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            if (figure == "square")
            {
                double a = double.Parse(Console.ReadLine());
                double S = a * a;
                Console.WriteLine($"{S:f3}");
            }
            if (figure == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                double S = a * b;
                Console.WriteLine($"{S:f3}");
            }
            if (figure == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                double S = r * r * Math.PI;
                Console.WriteLine($"{S:f3}");
            }
            if (figure == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());
                double S = a * h / 2;
                Console.WriteLine($"{S:f3}");
            }
        }
    }
}
