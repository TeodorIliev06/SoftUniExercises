using System;

namespace CombinationsWithRepetitions
{
    internal class Program
    {
        private static int count;
        private static string[] elements;
        private static string[] combinations;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            count = int.Parse(Console.ReadLine());
            combinations = new string[count];

            Combine(0, 0);
        }

        private static void Combine(int index, int startIndex)
        {
            if (index >= combinations.Length)
            {
                Console.WriteLine(String.Join(" ", combinations));
                return;
            }

            for (int i = startIndex; i < elements.Length; i++)
            {
                combinations[index] = elements[i];
                Combine(index + 1, i);
            }
        }
    }
}