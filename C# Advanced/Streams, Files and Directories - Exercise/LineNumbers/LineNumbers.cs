using System;
using System.IO;

namespace LineNumbers
{
    class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = "../../../text.txt";
            string outputFilePath = "../../../output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] inputLines = File.ReadAllLines(inputFilePath);
            string[] outputLines = new string[inputLines.Length];

            for (int i = 0; i < inputLines.Length; i++)
            {
                string currentLine = inputLines[i];

                int lettersCount = CountLetters(currentLine);
                int punctuationMarksCount = CountPunctuationMarks(currentLine);

                outputLines[i] = $"Line {i + 1}: {currentLine} ({lettersCount})({punctuationMarksCount})";
            }

            File.WriteAllLines(outputFilePath, outputLines);

            Console.WriteLine("Processing completed. Result written to output file.");
        }

        private static int CountPunctuationMarks(string currentLine)
        {
            int punctuationMarksCount = 0;
            for (int j = 0; j < currentLine.Length; j++)
            {
                char currentSymbol = currentLine[j];

                if (char.IsPunctuation(currentSymbol))
                {
                    punctuationMarksCount++;
                }
            }

            return punctuationMarksCount;
        }

        private static int CountLetters(string currentLine)
        {
            int lettersCount = 0;

            for (int j = 0; j < currentLine.Length; j++)
            {
                char currentSymbol = currentLine[j];

                if (char.IsLetter(currentSymbol))
                {
                    lettersCount++;
                }
            }

            return lettersCount;
        }
    }
}