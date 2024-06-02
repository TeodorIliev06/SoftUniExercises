namespace _04._Reverse_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string reverseWord = "";
            for (int i = word.Length - 1; i >= 0; i--)
            {
                reverseWord += word[i];
            }
            Console.WriteLine(reverseWord);
        }
    }
}