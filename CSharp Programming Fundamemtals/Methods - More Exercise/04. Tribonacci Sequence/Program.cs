namespace Tribonacci_Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Tribonacci(n);
        }

        private static void Tribonacci(int n)
        {
            int first = 0;
            int second = 0;
            int third = 0;
            int sum = 1;
            for (int i = 0; i < n; i++)
            {
                Console.Write(sum + " ");
                third = sum;
                sum = first + second + third;
                first = second;
                second = third;
            }
        }
    }
}