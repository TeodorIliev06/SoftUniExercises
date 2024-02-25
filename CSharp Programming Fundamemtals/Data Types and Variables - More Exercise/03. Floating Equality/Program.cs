namespace _03._Floating_Equality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double eps = 0.000001;
            double number1 = double.Parse(Console.ReadLine());
            double number2 = double.Parse(Console.ReadLine());

            if (Math.Abs(number1 - number2) < eps)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}