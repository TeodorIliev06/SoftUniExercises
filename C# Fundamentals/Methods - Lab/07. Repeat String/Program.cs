using System.Text;

namespace String_Repeater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int num = int.Parse(Console.ReadLine());
            string repeated = RepeatString(str, num);
            Console.WriteLine(repeated);
        }
        static string RepeatString(string str, int num)
        {
            StringBuilder repeatedStr = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                repeatedStr.Append(str);
            }
            return repeatedStr.ToString();
        }
    }
}