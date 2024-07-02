namespace _03._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(n => int.Parse(n))
                .ToArray();

            Func<int[], int> getSmallest = number =>
            {
                return numbers.Min();
            };

            Console.WriteLine(getSmallest(numbers));
        }
    }
}
