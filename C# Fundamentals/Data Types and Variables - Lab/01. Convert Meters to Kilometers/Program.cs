namespace _01._Convert_Meters_to_Kilometers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int meter = int.Parse(Console.ReadLine());
            double km = (double)meter / 1000;
            Console.WriteLine($"{km:f2}");
        }
    }
}