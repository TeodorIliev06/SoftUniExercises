using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._List_Of_Predicates
{
    internal class Program
    {       
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> result = FindDivisibleNumbers(end, dividers);

            foreach (int num in result)
            {
                Console.Write($"{num} ");
            }
        }

        static List<int> FindDivisibleNumbers(int end, int[] dividers)
        {
            List<int> divisibleNumbers = new List<int>();

            for (int i = 1; i <= end; i++)
            {
                if (IsDivisible(i, dividers))
                {
                    divisibleNumbers.Add(i);
                }
            }

            return divisibleNumbers;
        }

        static bool IsDivisible(int num, int[] dividers)
        {
            foreach (int divider in dividers)
            {
                if (num % divider != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
