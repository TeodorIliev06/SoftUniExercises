namespace CountCharsInAString;

internal class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        Dictionary<char, int> charOccurences = new();

        for (int i = 0; i < input.Length; i++)
        {
            char ch = input[i];

            if (ch == ' ')
            {
                continue;
            }

            if (!charOccurences.ContainsKey(ch))
            {
                charOccurences.Add(ch, 0);
            }

            charOccurences[ch]++;
        }

        foreach (var itemPair in charOccurences)
        {
            Console.WriteLine($"{itemPair.Key} -> {itemPair.Value}");
        }
    }
}