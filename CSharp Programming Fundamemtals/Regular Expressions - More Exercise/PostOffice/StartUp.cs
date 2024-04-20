using System.Text.RegularExpressions;

namespace PostOffice;

public class StartUp
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

        string firstPart = input[0];
        string secondPart = input[1];
        string thirdPart = input[2];

        string firstPattern = @"([#$%*&])(?<capitals>[A-Z]+)(\1)";
        Match firstMatch = Regex.Match(firstPart, firstPattern);
        string capitals = firstMatch.Groups["capitals"].Value;

        for (int i = 0; i < capitals.Length; i++)
        {
            char startLetter = capitals[i];
            int ASCIIcode = startLetter;

            string secondPattern = $@"{ASCIIcode}:(?<length>[0-9][0-9])";
            Match secondMatch = Regex.Match(secondPart, secondPattern);
            int length = int.Parse(secondMatch.Groups["length"].Value);

            string thirdPattern = $@"(?<=\s|^){startLetter}[^\s]{{{length}}}(?=\s|$)"; // Optimised regex to do most of the work
            Match thirdMatch = Regex.Match(thirdPart, thirdPattern);
            string word = thirdMatch.ToString();

            Console.WriteLine(word);
        }
    }
}