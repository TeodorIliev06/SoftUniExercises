namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .OrderByDescending(n => n).Take(3)
                .ToList();

            Console.WriteLine(string.Join(" ", integers));
        }
    }
}
