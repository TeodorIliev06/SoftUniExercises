namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int divisor = int.Parse(Console.ReadLine());

            Func<int, bool> filter = n => n % divisor != 0;           
            int[] remainingNums = nums.Reverse().Where(filter).ToArray();

            Console.WriteLine(string.Join(" ", remainingNums));
        }
    }
}
