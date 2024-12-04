using System.Collections;

namespace _05.ReverseNumbersStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            int count = numbers.Count;
            for (int i = 0; i < count; i++)
            {
                Console.Write(numbers.Pop() + " ");
            }
        }
    }
}
