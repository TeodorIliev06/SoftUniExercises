namespace _05._Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());
            AddAndSustract(n1, n2, n3);
        }
        static void AddAndSustract (int n1, int n2, int n3)
        {
            Console.WriteLine(n1 + n2 - n3);
        }
    }
}