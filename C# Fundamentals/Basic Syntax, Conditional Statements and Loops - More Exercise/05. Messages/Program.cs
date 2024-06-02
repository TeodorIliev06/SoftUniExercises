namespace _05._Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            string message = string.Empty;

            for (int i = 0; i < input; i++)
            {
                string digits = Console.ReadLine();
                int digit = digits[0] - '0';
                int offset = (digit - 2) * 3;

                if (digit == 0)
                {
                    message += " ";
                    continue;
                }

                if (digit == 8 || digit == 9)
                {
                    offset++;
                }
                int letterIndex = offset + digits.Length - 1;
                message += (char)(letterIndex + 97);
            }

            Console.WriteLine(message);
        }
    }
}