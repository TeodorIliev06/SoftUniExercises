using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int episode = int.Parse(Console.ReadLine());
            int rest = int.Parse(Console.ReadLine());

            double available = (double)rest - ((double)rest / 8 + (double)rest / 4);

            if (available >= episode)
            {
                Console.WriteLine($"You have enough time to watch {name} and left with {Math.Ceiling(available - episode)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {name}, you need {Math.Ceiling(episode - available)} more minutes.");

            }
        }
    }
}
