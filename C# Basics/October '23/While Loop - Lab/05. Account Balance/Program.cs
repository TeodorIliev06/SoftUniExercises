using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string vnoska = Console.ReadLine();
            double sum = 0;
            while (vnoska != "NoMoreMoney")
            {
                if (double.Parse(vnoska) < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                Console.WriteLine($"Increase: {double.Parse(vnoska):F2}");
                sum += double.Parse(vnoska);
                vnoska = Console.ReadLine();
            }
            Console.WriteLine($"Total: {sum:F2}");
        }
    }
}