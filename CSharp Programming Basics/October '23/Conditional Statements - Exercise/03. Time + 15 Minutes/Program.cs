using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int min = minutes + 15;
            if (min >= 60)
            {
                hours += 1;
                min = min % 60;
            }
            if (hours == 24)
            {
                hours = 0;
            }
            if (min < 10)
            {
                Console.WriteLine($"{hours}:0{min}");
            }
            else
            {
                Console.WriteLine($"{hours}:{min}");
            }
        }
    }
}
