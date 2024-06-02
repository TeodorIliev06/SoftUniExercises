using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            double sum = 0.0;
            string operation = Console.ReadLine();

            if (operation == "+")
            {
                sum = a + b;
                if (sum % 2 == 0) { Console.WriteLine($"{a} + {b} = {sum} - even"); }
                else { Console.WriteLine($"{a} + {b} = {sum} - odd"); }
            }
            if (operation == "-")
            {
                sum = a - b;
                if (sum % 2 == 0) { Console.WriteLine($"{a} - {b} = {sum} - even"); }
                else { Console.WriteLine($"{a} - {b} = {sum} - odd"); }
            }
            if (operation == "*")
            {
                sum = a * b;
                if (sum % 2 == 0) { Console.WriteLine($"{a} * {b} = {sum} - even"); }
                else { Console.WriteLine($"{a} * {b} = {sum} - odd"); }
            }
            if (operation == "/")
            {
                if (b == 0) { Console.WriteLine($"Cannot divide {a} by zero"); }
                else if (b != 0)
                {
                    sum = (double)a / (double)b;
                    Console.WriteLine($"{a} / {b} = {sum:F2}");
                }
            }
            if (operation == "%")
            {
                if (b == 0) { Console.WriteLine($"Cannot divide {a} by zero"); }
                else if (b != 0)
                {
                    sum = (double)a % (double)b;
                    Console.WriteLine($"{a} % {b} = {sum}");
                }
            }
        }
    }
}
