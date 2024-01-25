using System.Diagnostics.CodeAnalysis;

namespace football_kit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double tshirt = double.Parse(Console.ReadLine());
            double toReachBall = double.Parse(Console.ReadLine());
            double sum = tshirt;

            double shorts = 0.75 * tshirt;
            sum += shorts;

            double socks = 0.2 * shorts;
            sum += socks;

            double krossovki = (tshirt + shorts) * 2;
            sum += krossovki;

            sum = 0.85 * sum;

            if (sum >= toReachBall)
            {
                Console.WriteLine("Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {sum:f2} lv.");
            }
            else
            {
                Console.WriteLine("No, he will not earn the world-cup replica ball.");
                Console.WriteLine($"He needs {toReachBall - sum:f2} lv. more.");
            }
        }
    }
}