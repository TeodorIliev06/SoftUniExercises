using System;
using System.Linq;

namespace ReverseArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            ReverseArray(array, 0, array.Length - 1);
            Console.WriteLine(String.Join(' ', array));
        }

        private static void ReverseArray(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            (array[start], array[end]) = (array[end], array[start]);

            ReverseArray(array, start + 1, end - 1);
        }
    }
}
