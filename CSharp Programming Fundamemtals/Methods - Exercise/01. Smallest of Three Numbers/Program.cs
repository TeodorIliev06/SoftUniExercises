namespace _01._Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());
            GetMin (n1, n2, n3);
        }
        static void GetMin (int n1, int n2, int n3)
        {
            Console.WriteLine(Math.Min((Math.Min(n1,n2)),n3));
        }
    }
}