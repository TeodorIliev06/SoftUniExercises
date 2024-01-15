using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double start = double.Parse(Console.ReadLine());
            double points = 0;
            double wins = 0;

            for (int i = 0; i < n; i++)
            {
                string place = Console.ReadLine();
                if (place == "W") { start += 2000; points += 2000; wins += 1; }
                if (place == "F") { start += 1200; points += 1200; }
                if (place == "SF") { start += 720; points += 720; }
            }
            Console.WriteLine($"Final points: {Math.Floor(start)}");
            Console.WriteLine($"Average points: {Math.Floor(points / n)}");
            Console.WriteLine($"{(wins / n * 100):F2}%");

        }
    }
}