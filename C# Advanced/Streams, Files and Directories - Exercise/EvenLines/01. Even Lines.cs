namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            char[] charactersToReplace = new[] { '-', ',', '.', '!', '?' };
            StringBuilder output = new StringBuilder();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                int lineNums = 0;

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (lineNums % 2 == 0)
                    {
                        line = ReplaceAll(charactersToReplace, '@', line);
                        line = ReverseWords(line);

                        output.AppendLine(line);
                    }

                    lineNums++;
                }
            }

            return output.ToString();
        }

        static string ReplaceAll(char[] replace, char replacement, string line)
        {
            return new string(line.Select(c => replace.Contains(c) ? replacement : c).ToArray());
        }

        public static string ReverseWords(string s)
        {
            return string.Join(" ", s.Split().Reverse());
        }
    }
}
