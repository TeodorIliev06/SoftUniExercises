namespace _05._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> evens = new Queue<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    evens.Enqueue(numbers[i]);
                }
                else
                {
                    continue;
                }
            }
            
            Console.WriteLine(string.Join(", ", evens));
        }
    }
}
