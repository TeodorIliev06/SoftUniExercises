using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            double min = 10000000;
            string number = Console.ReadLine();

            while (number != "Stop")
            {
                if (double.Parse(number) < min)
                {
                    min = double.Parse(number);
                }
                number = Console.ReadLine();
            }
            Console.WriteLine(min);
        }
    }
}