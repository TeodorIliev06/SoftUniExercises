namespace _10._Lower_or_Upper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] upper = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char input = char.Parse(Console.ReadLine());
            if (upper.Contains(input))
                Console.WriteLine($"upper-case");
            else
                Console.WriteLine($"lower-case");
        }
    }
}