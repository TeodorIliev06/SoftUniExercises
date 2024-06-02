namespace Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split()
                .Select(x => x.ToLower())
                .ToArray();

            Dictionary<string, int> wordOccurences = new Dictionary<string, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (!wordOccurences.ContainsKey(numbers[i]))
                {
                    wordOccurences[numbers[i]] = 0;
                }
                wordOccurences[numbers[i]]++;
            }

            foreach (KeyValuePair<string, int> itemPair in wordOccurences)
            {
                if (itemPair.Value % 2 == 1)
                {
                    Console.Write(itemPair.Key + " ");
                }
            }
        }
    }
}