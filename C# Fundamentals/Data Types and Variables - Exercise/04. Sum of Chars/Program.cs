namespace _04._Sum_of_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < N; i++)
            {
                char Character = char.Parse(Console.ReadLine());
                sum += Character;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}