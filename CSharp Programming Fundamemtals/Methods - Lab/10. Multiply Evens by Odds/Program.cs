namespace Multiply_evens_by_odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = Math.Abs(int.Parse(Console.ReadLine()));
            Console.WriteLine(MultiplyEvensByOdds(input));
        }
        static int MultiplyEvensByOdds(int num)
        {
            int even = 0, odd = 0, result = 0;
            while (num > 0)
            {
                int lastDigit = num % 10;
                if (lastDigit % 2 == 0)
                {
                    even += lastDigit;
                }
                else
                {
                    odd += lastDigit;
                }
                num /= 10;
            }
            result = even * odd;
            return result;
        }
    }
}