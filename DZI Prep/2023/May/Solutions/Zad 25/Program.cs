namespace Zad_25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());

                int temp, currentDigit;
                while (number != 0)
                {
                    temp = number;
                    currentDigit = number % 10;
                    if (temp % currentDigit != 0)
                    {
                        Console.WriteLine("No");
                        return;
                    }

                    number /= 10;
                }

                Console.WriteLine("Yes");
            }
            catch
            {
                Console.WriteLine("Something went wrong!");
                throw;
            }
            
        }
    }
}
