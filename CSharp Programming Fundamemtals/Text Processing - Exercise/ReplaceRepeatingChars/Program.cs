using System.Text;

namespace Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new(Console.ReadLine());

            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] == text[i + 1] && i + 1 < text.Length)
                {
                    text.Remove(i, 1);
                    i = -1;
                }
            }
            Console.WriteLine(text.ToString());
        }
    }
}