using System.Text.RegularExpressions;

namespace _06._Extract_Emails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(^|(?<=\s))(?<email>([a-zA-Z0-9]+)([\.\-_]?)([A-Za-z0-9]+)@([a-zA-Z]+([\.\-][A-Za-z]+)+))(\b|(?=\s))"; //backreferences
            List<string> emails = new List<string>();

            foreach (Match match in Regex.Matches(input, pattern))
            {
                emails.Add(match.Groups["email"].Value);
            }

            emails.ForEach(email => Console.WriteLine(email));
        }
    }   
}