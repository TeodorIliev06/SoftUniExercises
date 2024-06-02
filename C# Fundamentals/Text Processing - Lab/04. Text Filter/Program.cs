namespace Text_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] banWord = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            foreach (string item in banWord)
            {
                text = text.Replace(item, new string('*', item.Length));
            }
            Console.WriteLine(text);
        }
    }
}
