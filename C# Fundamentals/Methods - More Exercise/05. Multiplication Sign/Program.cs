namespace Multiplication_Sign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double num3 = double.Parse(Console.ReadLine());
            int negative = 0;

            if (num1 == 0 || num2 == 0 || num3 == 0)
            {
                Console.WriteLine("zero");
                return;
            }
            if (num1 < 0)
            {
                negative++;
            }
            if (num2 < 0)
            {
                negative++;
            }
            if (num3 < 0)
            {
                negative++;
            }
            if (negative % 2 == 0)
            {
                Console.WriteLine("positive");
            }
            else
            {
                Console.WriteLine("negative");
            }
        }
    }
}