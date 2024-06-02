using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum1 = 0;
            int sum2 = 0;
            string input; 

            while ((input = Console.ReadLine()) != "stop")
            {
                              
                int number;
                if (!int.TryParse(input, out number))
                {
                    continue;
                }

                if (number < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }

                if (IsPrime(number))
                    sum1 += number;
                else
                    sum2 += number;
            }

            Console.WriteLine("Sum of all prime numbers is: " + sum1);
            Console.WriteLine("Sum of all non prime numbers is: " + sum2);

            static bool IsPrime(int number)
            {
                if (number < 2)
                    return false;

                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                        return false;
                }

                return true;
            }
        }
    }
}