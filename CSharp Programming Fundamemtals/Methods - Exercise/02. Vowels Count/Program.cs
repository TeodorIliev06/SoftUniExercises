namespace _02._Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            GetVowelsCount(word);
        }
        static void GetVowelsCount (string input)
        {
            int ctr = 0;
            char[] vowels = { 'A', 'a', 'E', 'e', 'O', 'o', 'I', 'i', 'U', 'u' };
            foreach (char ch in input)
            {
                if (vowels.Contains(ch))
                {
                    ctr++;
                }
            }
            Console.WriteLine(ctr);
        }
    }
}