using System;

namespace RecursiveFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFactorial(num));
        }

        //Without memoization in this case
        private static int GetFactorial(int num)
        {
            if (num == 1)
            {
                return 1;
            }

            return num * GetFactorial(num - 1);
        }
    }
}