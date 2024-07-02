namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<List<string>> knights = EnnoblePeople(names);
        }

        private static Action<List<string>> EnnoblePeople(List<string> names)
        {
            if (names.Any())
            {
                names.ForEach(n => Console.WriteLine($"Sir {n}"));
            }

            return null;
        }
    }
}
