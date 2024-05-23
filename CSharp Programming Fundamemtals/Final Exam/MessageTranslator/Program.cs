using System.Text.RegularExpressions;

namespace MessageTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            string pattern = @"!(?<command>[A-Z]{1}[a-z]{2,})!:\[(?<string>[A-Za-z]{8,})\]";

            string input;
            for (int i = 0; i < lines; i++)
            {
                input = Console.ReadLine();

                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string command = match.Groups["command"].Value;
                    string toTranslate = match.Groups["string"].Value;

                    Console.Write($"{command}:");
                    foreach (char ch in toTranslate)
                    {
                        Console.Write($" {(int)ch}");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}