namespace _01._Old_Books
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int br = 0;
            string book;

            while ((book = Console.ReadLine()) != "No More Books")
            {
                if (book == name)
                {
                    Console.WriteLine($"You checked {br} books and found it.");
                    break;
                }
                br++;
                book = Console.ReadLine();
            }
            if (book != name)
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {br} books.");
            }
        }
    }
}