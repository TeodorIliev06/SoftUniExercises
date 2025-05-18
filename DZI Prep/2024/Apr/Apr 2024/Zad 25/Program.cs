namespace Zad_25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                if (IsPrime(number))
                {
                    var reversedNumber = int.Parse(new string(number.ToString().Reverse().ToArray()));
                    if (IsPrime(reversedNumber))
                    {
                        Console.WriteLine($"{number} is a mirror prime");
                    }
                    else
                    {
                        Console.WriteLine($"{number} is NOT a mirror prime");
                    }
                }
                else
                {
                    Console.WriteLine($"{number} is NOT a prime");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Incorrectly entered number");
                throw;
            }
        }

        private static bool IsPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }
            if (number == 2)
            {
                return true;
            }

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
