using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine(); // Skipping the first line

            string[] bestDna = null;
            int bestLength = -1;
            int bestStartIndex = -1;
            int bestDnaSum = 0;
            int bestSampleIndex = 0;

            int currentSampleIndex = 0;

            string input;
            while ((input = Console.ReadLine()) != "Clone them!")
            {
                string[] currentDna = input.Split('!', StringSplitOptions.RemoveEmptyEntries);

                int currentLength = 0;
                int currentBestLength = 0;
                int currentEndIndex = 0;

                for (int i = 0; i < currentDna.Length; i++)
                {
                    if (currentDna[i] == "1")
                    {
                        currentLength++;
                        if (currentLength > currentBestLength)
                        {
                            currentEndIndex = i;
                            currentBestLength = currentLength;
                        }
                    }
                    else
                    {
                        currentLength = 0;
                    }
                }

                int currentStartIndex = currentEndIndex - currentBestLength + 1;

                int currentDnaSum = currentDna.Select(int.Parse).Sum();

                bool isCurrentDnaBetter = currentBestLength > bestLength ||
                                           (currentBestLength == bestLength && currentStartIndex < bestStartIndex) ||
                                           (currentBestLength == bestLength && currentStartIndex == bestStartIndex && currentDnaSum > bestDnaSum);

                currentSampleIndex++;

                if (isCurrentDnaBetter)
                {
                    bestDna = currentDna;
                    bestLength = currentBestLength;
                    bestStartIndex = currentStartIndex;
                    bestDnaSum = currentDnaSum;
                    bestSampleIndex = currentSampleIndex;
                }
            }

            Console.WriteLine($"Best DNA sample {bestSampleIndex} with sum: {bestDnaSum}.");
            Console.WriteLine(string.Join(' ', bestDna));
        }
    }
}
