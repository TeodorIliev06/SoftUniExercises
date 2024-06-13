using System.Collections.Generic;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var setsLenghts = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int firstLen = setsLenghts[0];
            int secondLen = setsLenghts[1];

            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();
            var outputSet = new HashSet<int>();

            for (int i = 0; i < firstLen; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                firstSet.Add(currentNumber);
            }
            for (int i = 0; i < secondLen; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                secondSet.Add(currentNumber);
            }

            if (firstSet.Count >= secondSet.Count)
            {
                foreach (var number in secondSet)
                {
                    if (firstSet.Contains(number))
                    {
                        outputSet.Add(number);
                    }
                }
            }
            else
            {
                foreach (var number in firstSet)
                {
                    if (secondSet.Contains(number))
                    {
                        outputSet.Add(number);
                    }
                }
            }

            foreach (var number in outputSet)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
