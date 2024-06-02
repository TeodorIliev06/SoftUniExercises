using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int number = int.Parse(Console.ReadLine());
            int counter = 0;
            bool done = false;

            for (int a = start; a <= end; a++)
            {
                for (int b = start; b <= end; b++)
                {
                    counter++;
                    if (a + b == number)
                    {
                        Console.WriteLine($"Combination N:{counter} ({a} + {b} = {number})");
                        done = true;
                        break;
                    }
                }
                if (done) { break; }
            }
            if (done == false)
            {
                Console.WriteLine($"{counter} combinations - neither equals {number}");
            }
        }
    }
}