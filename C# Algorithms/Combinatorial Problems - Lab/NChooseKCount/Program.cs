using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace NChooseKCount
{
    internal class Program
    {
        private static Dictionary<(int, int), long> memo = new Dictionary<(int, int), long>();
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            Console.WriteLine(GetBinom(row, col));
        }

        private static long GetBinom(int row, int col)
        {
            //If row == col then we are on the last col (Pascal's triangle -> 1)
            if (row <= 1 || col == 0 || row == col)
            {
                return 1;
            }

            var key = (row, col);
            if (memo.ContainsKey(key))
            {
                return memo[key];
            }

            long result = GetBinom(row - 1, col) + GetBinom(row - 1, col - 1);
            memo[key] = result;

            return result;
        }
    }
}
