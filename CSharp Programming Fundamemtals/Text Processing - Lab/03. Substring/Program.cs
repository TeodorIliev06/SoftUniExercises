namespace substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstString = Console.ReadLine();
            string secondString = Console.ReadLine();

            while (secondString.Contains(firstString))
            {
                secondString = secondString.Replace(firstString, String.Empty);
            }

            Console.WriteLine(secondString);
        }
    }
}