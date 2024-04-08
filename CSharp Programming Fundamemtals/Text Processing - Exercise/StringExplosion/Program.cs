using System.Text;

namespace StringExplosion;

internal class Program
{
    static void Main(string[] args)
    {
        string text = Console.ReadLine();
        Console.WriteLine(Explosion(text));
    }

    private static string Explosion(string text)
    {
        int strength = 0;
        StringBuilder sb = new();

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == '>')
            {
                sb.Append(text[i]);
                strength += int.Parse(text[i + 1].ToString());
            }
            else if (strength == 0)
            {
                sb.Append(text[i]);
            }
            else
            {
                strength--;
            }
        }

        return sb.ToString();
    }
}