using System;
using System.Text;
namespace Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int firstValue = first;
            int secondValue = second;
            int sum = 0;

            foreach (char letter in input)
            {
                if (letter > first && letter < second)
                {
                    sum += letter;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
