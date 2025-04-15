using System;

namespace NestedLoops
{
    internal class Program
    {
        private static int[] elements;
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            elements = new int[number];
            GenerateVectors(0);
        }

        private static void GenerateVectors(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(String.Join(" ", elements));
                return;
            }

            //Going to the bottom then iterating and repeating so as to increment up to N
            for (int i = 1; i <= elements.Length; i++)
            {
                elements[index] = i;
                GenerateVectors(index + 1);
            }
        }
    }
}
