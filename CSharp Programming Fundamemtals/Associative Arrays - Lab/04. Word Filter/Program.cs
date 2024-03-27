namespace Word_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split()
                .Where(item => item.Length % 2 == 0)
                .ToArray();
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}