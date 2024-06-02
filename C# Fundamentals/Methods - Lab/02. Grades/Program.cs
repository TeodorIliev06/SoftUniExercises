namespace Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            GetGrade(number);
        }
        static void GetGrade(double number)
        {
            if (number >= 2.00 && number <= 2.99)
            {
                Console.WriteLine("Fail");
            }
            if (number >= 3.00 && number <= 3.49)
            {
                Console.WriteLine("Poor");
            }
            if (number > 3.49 && number <= 4.49)
            {
                Console.WriteLine("Good");
            }
            if (number > 4.49 && number <= 5.49)
            {
                Console.WriteLine("Very good");
            }
            if (number > 5.49 && number <= 6)
            {
                Console.WriteLine("Excellent");
            }
        }
    }
}