namespace LettersChangeNumbers;

internal class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        double sum = 0;
        foreach (string word in input)
        {
            double num = double.Parse(word.Substring(1, word.Length - 2));

            char firstLetter = word[0];
            char lastLetter = word[word.Length - 1];
            if (char.IsLower(firstLetter))
            {
                int letterPosition = firstLetter - 'a' + 1;
                num = num * letterPosition;
            }
            else if (char.IsUpper(firstLetter))
            {
                int letterPosition = firstLetter - 'A' + 1;
                num = num / letterPosition;
            }

            if (char.IsLower(lastLetter))
            {
                int letterPosition = lastLetter - 'a' + 1;
                num = num + letterPosition;
            }
            else if (char.IsUpper(lastLetter))
            {
                int letterPosition = lastLetter - 'A' + 1;
                num = num - letterPosition;
            }
            sum += num;
        }
        Console.WriteLine($"{sum:f2}");
    }
}