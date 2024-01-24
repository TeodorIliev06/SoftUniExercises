using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int judges = int.Parse(Console.ReadLine());
            string input, prezentation;
            int ctr = 0;
            double sum = 0;

            while ((input = Console.ReadLine()) != "Finish")
            {
                double prezentationEV = 0;
                prezentation = input;
                for (int i = 1; i <= judges; i++)
                {
                    prezentationEV += double.Parse(Console.ReadLine());
                }
                prezentationEV = prezentationEV / judges;
                sum += prezentationEV;

                Console.WriteLine($"{prezentation} - {prezentationEV:F2}.");
                ctr++;                
            }

            Console.WriteLine($"Student's final assessment is {sum / ctr:F2}.");
        }
    }
}