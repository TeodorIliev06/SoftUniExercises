using System;

namespace VariationsWithRepetitions
{
    internal class Program
    {
        private static int count;
        private static string[] elements;
        private static string[] variations;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            count = int.Parse(Console.ReadLine());
            variations = new string[count];

            Vary(0);
        }

        private static void Vary(int index)
        {
            if (index >= variations.Length)
            {
                Console.WriteLine(String.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                variations[index] = elements[i];
                Vary(index + 1);
            }
        }
    }
}
