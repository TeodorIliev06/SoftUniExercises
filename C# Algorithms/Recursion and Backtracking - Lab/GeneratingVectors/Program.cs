using System;

namespace GeneratingVectors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vectors = int.Parse(Console.ReadLine());
            var array = new int[vectors];

            Gen01(array, 0);
        }

        private static void Gen01(int[] array, int index)
        {
            if (index >= array.Length)
            {
                Console.WriteLine(String.Join("", array));
                return;
            }

            //Putting zeroes and trying to reach the bottom, then replacing with ones and again going for zeroes
            for (int i = 0; i <= 1; i++)
            {
                array[index] = i;
                Gen01(array, index + 1);
            }
        }
    }
}
