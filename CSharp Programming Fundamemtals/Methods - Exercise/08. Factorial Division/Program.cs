namespace _08._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNum = double.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());
            Console.WriteLine($"{(GetFactorial(firstNum) / GetFactorial(secondNum)):f2}");
        }
        static double GetFactorial (double num)
        {
            if (num == 1)
                return 1;
            else
                return num * GetFactorial(num - 1);
        }
    }
}