using System;

namespace PermutationsWithoutRepetitions
{
    internal class Program
    {
        private static string[] elements;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(String.Join(" ", elements));
                return;
            }

            //We want to reach the base case for every iteration
            Permute(index + 1);

            for (int i = index + 1; i < elements.Length; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int first, int second)
        {
            //(elements[first], elements[second]) = (elements[second], elements[first]);

            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}
