using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\+359( |-)2\1\d{3}\1\d{4}";
            string input = Console.ReadLine();

            MatchCollection phoneCollection = Regex.Matches(input, pattern);
            List<string> phoneList = new List<string>();

            foreach (var phone in phoneCollection)
            {
                phoneList.Add(phone.ToString());
            }

            Console.WriteLine(string.Join(", ", phoneList));
        }
    }
}