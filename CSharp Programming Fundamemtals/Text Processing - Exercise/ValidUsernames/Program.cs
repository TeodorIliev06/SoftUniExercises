namespace ValidUsernames;

internal class Program
{
    static void Main(string[] args)
    {
        string[] words = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            if (word.Length < 3 || word.Length > 16)
            {
                continue;
            }

            if (word.All(ch => char.IsLetterOrDigit(ch) || ch == '_' || ch == '-'))
            {
                Console.WriteLine(word);
            }

        }
    }
}