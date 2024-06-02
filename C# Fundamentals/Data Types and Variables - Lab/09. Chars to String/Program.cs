namespace _09._Chars_to_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            char third = char.Parse(Console.ReadLine());
            string output = string.Concat(first, second, third);
            Console.WriteLine(output);
        }
    }
}