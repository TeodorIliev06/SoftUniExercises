using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());
            double musala = 0;
            double monblan = 0;
            double kilimanjaro = 0;
            double k2 = 0;
            double everest = 0;
            int count = 0;
            for (int i = 0; i < groups; i++)
            {
                int people = int.Parse(Console.ReadLine());
                if (people > 0 && people <= 5) { musala += people; }
                if (people > 5 && people <= 12) { monblan += people; }
                if (people > 12 && people <= 25) { kilimanjaro += people; }
                if (people > 25 && people <= 40) { k2 += people; }
                if (people >= 41) { everest += people; }
                count += people;
            }
            Console.WriteLine($"{(musala / count * 100):F2}%");
            Console.WriteLine($"{(monblan / count * 100):F2}%");
            Console.WriteLine($"{(kilimanjaro / count * 100):F2}%");
            Console.WriteLine($"{(k2 / count * 100):F2}%");
            Console.WriteLine($"{(everest / count * 100):F2}%");

        }
    }
}