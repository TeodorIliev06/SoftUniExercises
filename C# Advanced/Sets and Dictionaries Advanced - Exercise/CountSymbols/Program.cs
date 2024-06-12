using System.Reflection.Metadata;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            var occurrences = new SortedDictionary<char, int>();

            for (int chIndex = 0; chIndex < text.Length; chIndex++)
            {
                if (!occurrences.ContainsKey(text[chIndex]))
                {
                    occurrences[text[chIndex]] = 0;
                }
                occurrences[text[chIndex]]++;
            }
            foreach (var (character, count) in occurrences)
            {
                Console.WriteLine($"{character}: {count} time/s");
            }
        }
    }
}
