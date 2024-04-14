using System.Text;

namespace Morse_Code_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, char> morseCodeDictionary = new Dictionary<string, char>()
        {
            { ".-", 'A' },
            { "-...", 'B' },
            { "-.-.", 'C' },
            { "-..", 'D' },
            { ".", 'E' },
            { "..-.", 'F' },
            { "--.", 'G' },
            { "....", 'H' },
            { "..", 'I' },
            { ".---", 'J' },
            { "-.-", 'K' },
            { ".-..", 'L' },
            { "--", 'M' },
            { "-.", 'N' },
            { "---", 'O' },
            { ".--.", 'P' },
            { "--.-", 'Q' },
            { ".-.", 'R' },
            { "...", 'S' },
            { "-", 'T' },
            { "..-", 'U' },
            { "...-", 'V' },
            { ".--", 'W' },
            { "-..-", 'X' },
            { "-.--", 'Y' },
            { "--..", 'Z' },
        };
            string morseCode = Console.ReadLine();

            string[] morseCodeWords = morseCode.Split(' ');

            StringBuilder sb = new StringBuilder();

            foreach (string word in morseCodeWords)
            {
                if (morseCodeDictionary.ContainsKey(word))
                {
                    sb.Append(morseCodeDictionary[word]);
                }

                if (word == "|")
                {
                    sb.Append(' ');
                }
            }
            Console.WriteLine(sb.ToString());
        }
    }
}