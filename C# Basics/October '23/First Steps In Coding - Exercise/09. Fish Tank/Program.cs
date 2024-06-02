using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double extra = double.Parse(Console.ReadLine());

            double volume = width * height * length;
            volume = volume - volume * extra / 100;
            Console.WriteLine(volume / 1000);
        }
    }
}
