using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double time = double.Parse(Console.ReadLine());
            double resistance = 0;

            if (distance >= 15)
            {
                resistance = (Math.Floor(distance / 15) * 12.5);
            }
            double IvanRecord = distance * time + resistance;
            if (IvanRecord < record)
            {
                Console.WriteLine($" Yes, he succeeded! The new world record is {IvanRecord:F2} seconds.");
            }
            else { Console.WriteLine($"No, he failed! He was {(IvanRecord - record):F2} seconds slower."); }
        }
    }
}
