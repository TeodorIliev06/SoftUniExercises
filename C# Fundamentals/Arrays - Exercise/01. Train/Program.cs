namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int passengers = 0;
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{arr[i]} ");
                passengers += arr[i];
            }
            Console.WriteLine();
            Console.WriteLine(passengers);
        }
    }
}