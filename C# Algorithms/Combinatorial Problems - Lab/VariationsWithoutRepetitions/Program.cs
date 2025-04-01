using System;

namespace VariationsWithoutRepetitions
{
    internal class Program
    {
        private static int count;
        private static string[] elements;
        private static string[] variations;
        private static bool[] used;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            count = int.Parse(Console.ReadLine());
            variations = new string[count];
            used = new bool[elements.Length];

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
                if (used[i] == false)
                {
                    used[i] = true;

                    variations[index] = elements[i];
                    Vary(index + 1);

                    used[i] = false;
                }
            }
        }
    }
}