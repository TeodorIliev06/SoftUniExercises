using System.Text;
namespace _02._Repeat_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            StringBuilder resultBuilder = new StringBuilder();
            int len = 0;

            foreach (string word in words)
            {
                len = word.Length;
                for (int i = 0; i < len; i++)
                {
                    resultBuilder.Append(word);
                }
            }
            Console.WriteLine(resultBuilder.ToString());
        }
    }
}