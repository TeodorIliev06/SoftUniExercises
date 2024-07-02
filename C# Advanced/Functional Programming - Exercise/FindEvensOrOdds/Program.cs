namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int lowerBound = range[0];
            int upperBound = range[1];

            string command = Console.ReadLine();

            List<int> nums = new List<int>();
            for (int i = lowerBound; i <= upperBound; i++)
            {
                nums.Add(i);
            }

            Predicate<int> filter = i => true;
            if (command == "even")
            {
                filter = i => i % 2 == 0;
            }
            else if (command == "odd")
            {
                filter = i => i % 2 != 0;
            }

            var filteredNums = nums.FindAll(filter);
            Console.WriteLine(string.Join(" ", filteredNums));

        }
    }
}
