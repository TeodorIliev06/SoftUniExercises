namespace Sign_of_integer_numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            CheckNumber(num);
        }
        static void CheckNumber(int num)
        {
            if (num == 0)
            {
                Console.WriteLine($"The number {num} is zero.");
            }
            else if (num > 0)
            {
                Console.WriteLine($"The number {num} is positive.");
            }
            else
            {
                Console.WriteLine($"The number {num} is negative.");
            }
        }
    }
}