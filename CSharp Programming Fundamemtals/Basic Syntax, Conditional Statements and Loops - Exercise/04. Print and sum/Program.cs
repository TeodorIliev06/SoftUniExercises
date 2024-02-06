namespace _04._Print_and_sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int first = Convert.ToInt32(Console.ReadLine());
            int second = Convert.ToInt32(Console.ReadLine());
            for (int i = first; i <= second; i++)
            {
                sum += i;
                Console.Write($"{i} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}