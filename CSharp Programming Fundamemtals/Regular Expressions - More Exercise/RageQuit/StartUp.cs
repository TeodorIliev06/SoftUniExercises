using System.Text;
using System.Text.RegularExpressions;

namespace RageQuit;

public class StartUp
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string pattern = @"(?<string>[^\d]+)(?<count>[\d]+)";

        StringBuilder output = new();
        foreach (Match match in Regex.Matches(input, pattern))
        {
            string str = match.Groups["string"].Value;
            int repeatCount = int.Parse(match.Groups["count"].Value);

            for (int i = 0; i < repeatCount; i++)
            {
                output.Append(str.ToUpper());
            }
        }

        int uniqueSymbols = output.ToString().Distinct().Count(); //Using distinct to count even if the symbol does not reoccur
        Console.WriteLine($"Unique symbols used: {uniqueSymbols}");
        Console.WriteLine(output.ToString());
    }
}