namespace Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var numbersAndOccurences = new SortedDictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (!numbersAndOccurences.ContainsKey(numbers[i]))
                {
                    numbersAndOccurences[numbers[i]] = 0;
                }
                numbersAndOccurences[numbers[i]]++;
            }

            foreach (var item in numbersAndOccurences)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}