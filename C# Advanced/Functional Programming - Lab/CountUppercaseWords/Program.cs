namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> filter = text => Char.IsUpper(text[0]);

            string text = Console.ReadLine();
            string[] words = text.Split(" ",
                StringSplitOptions.RemoveEmptyEntries);

            words = words.Where(filter).ToArray();

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}