namespace Center_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            bool firstToBePrinted = true;

            if (Math.Abs(x1) + Math.Abs(y1) > Math.Abs(x2) + Math.Abs(y2))
            {
                firstToBePrinted = false;
            }
            Output(x1, y1, x2, y2, firstToBePrinted);
        }
        private static void Output(double x1, double y1, double x2, double y2, bool firstToBePrinted)
        {
            if (firstToBePrinted == true)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else if (firstToBePrinted == false)
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }
    }
}