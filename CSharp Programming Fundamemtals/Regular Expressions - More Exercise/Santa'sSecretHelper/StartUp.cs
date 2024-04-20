using System.Text;
using System.Text.RegularExpressions;
namespace Santa_sSecretHelper;

public class StartUp
{
    static void Main(string[] args)
    {
        int key = int.Parse(Console.ReadLine());
        string pattern = @"@(?<name>[A-Za-z]+)[^@\-!:>]+!(?<type>[G])!";

        string encryptedMes;
        while ((encryptedMes = Console.ReadLine()) != "end")
        {

            StringBuilder decryptedMesBuilder = new();
            foreach (char ch in encryptedMes)
            {
                decryptedMesBuilder.Append((char)(ch - key));
            }

            string decryptedMes = decryptedMesBuilder.ToString();
            foreach (Match match in Regex.Matches(decryptedMes, pattern))
            {
                Console.WriteLine(match.Groups["name"].Value);
            }
        }
    }
}