namespace _04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> input = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .Select(n => n * 1.2)
            .ToList();

            input.ForEach(n => Console.WriteLine($"{n:f2}"));

        }
    }
}
