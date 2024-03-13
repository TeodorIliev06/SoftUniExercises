namespace _06._Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(GetMiddleCharacter(input));
        }
        static string GetMiddleCharacter(string input)
        {
            int len = input.Length;
            string result;

            if (len % 2 == 1)
            {
                result = input[len / 2].ToString();
            }
            else
            {
                result = input[len / 2 - 1].ToString() + input[len / 2].ToString();
            }
            return result;
        }
    }
}