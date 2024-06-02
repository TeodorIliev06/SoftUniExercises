namespace _08._Town_Info
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string ppl = Console.ReadLine();
            string area = Console.ReadLine();

            Console.WriteLine($"Town {name} has population of {ppl} and area {area} square km.");
        }
    }
}