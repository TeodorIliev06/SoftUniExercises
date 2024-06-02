namespace _03._Rounding_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                double[] array = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

                foreach (double number in array)
                {
                    int rounded = (int)Math.Round(number, MidpointRounding.AwayFromZero);
                    Console.WriteLine("{0} => {1}", number, rounded);
                }
            }
        }
    }
}