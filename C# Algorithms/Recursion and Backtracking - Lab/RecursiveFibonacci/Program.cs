using System;
using System.Collections.Generic;

namespace RecursiveFibonacci
{
    internal class Program
    {
        private static Dictionary<int, long> memo = new Dictionary<int, long>();
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFibonacci(input));
        }

        //With memoization
        private static long GetFibonacci(int input)
        {
            if (input <= 1)
            {
                return 1;
            }

            if (memo.ContainsKey(input))
            {
                return memo[input];
            }

            long result = GetFibonacci(input - 1) + GetFibonacci(input - 2);
            memo[input] = result;

            return result;
        }
    }
}
