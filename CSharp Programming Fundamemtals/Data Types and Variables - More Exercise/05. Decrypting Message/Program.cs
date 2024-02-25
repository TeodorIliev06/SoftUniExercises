using System;
using System.Linq;
using System.Text;
namespace _05._Decrypting_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());
            StringBuilder decrypted = new StringBuilder();
            for (int i = 0; i < lines; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                char decryptedLetter = (char)((int)letter + key);
                decrypted.Append(decryptedLetter);
            }
            Console.WriteLine(decrypted);
        }
    }
}