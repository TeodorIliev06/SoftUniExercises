namespace Zad_25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var number = uint.Parse(Console.ReadLine());

                if (number <= 1 || number >= 10000000)
                {
                    throw new InvalidOperationException();
                }

                var numberAsString = number.ToString();
                var reversedNumber = new string(numberAsString.Reverse().ToArray());

                if (reversedNumber == numberAsString)
                {
                    Console.WriteLine($"{number} is a palindrome");
                    return;
                }

                Console.WriteLine($"{number} is NOT a palindrome");
            }
            catch (Exception e)
            {
                Console.WriteLine("Incorrectly entered number");
                throw;
            }
        }
    }
}
