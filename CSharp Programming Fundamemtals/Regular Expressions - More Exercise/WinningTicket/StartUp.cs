using System.Text.RegularExpressions;

namespace WinningTicket;

public class StartUp
{
    static void Main(string[] args)
    {
        string winningPattern = @"(?=.{20}).*?(?=(?<ch>[@#$^]))(?<match>\k<ch>{6,}).*(?<=.{10})\k<match>.*"; //lookahead and lookbehind
        string[] inputArray = Console.ReadLine()
            .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        for (int i = 0; i < inputArray.Length; i++)
        {
            string ticket = inputArray[i];
            Match match = Regex.Match(ticket, winningPattern);

            if (ticket.Length != 20)
            {
                Console.WriteLine("invalid ticket");
                continue;
            }
            else if (match.Groups["match"].Length >= 6 && match.Groups["match"].Length <= 9)
            {
                Console.WriteLine($"ticket \"{ticket}\" - {match.Groups["match"].Length}{match.Groups["ch"].Value}");
            }
            else if (match.Groups["match"].Length == 10)
            {
                Console.WriteLine($"ticket \"{ticket}\" - {match.Groups["match"].Length}{match.Groups["ch"].Value} Jackpot!");
            }
            else
            {
                Console.WriteLine($"ticket \"{ticket}\" - no match");
            }
        }

    }
}
