namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {

            string[] words = File.ReadAllLines(wordsFilePath);
            string text = File.ReadAllText(textFilePath);

            Dictionary<string, int> wordCountDictionary = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (string word in words)
            {
                int count = 0;
                int index = text.IndexOf(word, StringComparison.OrdinalIgnoreCase);

                while (index != -1)
                {
                    count++;
                    index = text.IndexOf(word, index + 1, StringComparison.OrdinalIgnoreCase);
                }

                wordCountDictionary[word] = count;
            }

            var sortedWordCounts = wordCountDictionary.OrderByDescending(pair => pair.Value);

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var pair in sortedWordCounts)
                {
                    writer.WriteLine($"{pair.Key}: {pair.Value}");
                }
            }
        }
    }
}
