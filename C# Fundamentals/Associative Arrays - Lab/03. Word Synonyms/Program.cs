namespace Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> wordAndSyn = new Dictionary<string, string>();
            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!wordAndSyn.ContainsKey(word))
                {
                    wordAndSyn[word] = synonym;
                }
                else
                {
                    wordAndSyn[word] += ", " + synonym;
                }
            }

            foreach (KeyValuePair<string, string> itemPair in wordAndSyn)
            {
                Console.WriteLine($"{itemPair.Key} - {itemPair.Value}");
            }
        }
    }
}