namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxLen = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<int, string[]> printAllInRange = (max, strings) =>
            {
                foreach (var name in strings)
                {
                    if (name.Length <= max)
                    {
                        Console.WriteLine(name);
                    }
                }
            };
            printAllInRange(maxLen, names);
        }
    }
}
