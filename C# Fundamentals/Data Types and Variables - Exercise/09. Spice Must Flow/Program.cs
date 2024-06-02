namespace _09._Spice_Must_Flow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int daysCount = 0;
            int profit = 0;
            if (yield < 100)
            {
                Console.WriteLine(daysCount);
                Console.WriteLine(profit);
                return;
            }
            while (true)
            {
                if (yield >= 100)
                {
                    daysCount++;
                    profit += yield - 26;
                    yield -= 10;
                }
                else
                {
                    profit -= 26;
                    break;
                }
            }
            Console.WriteLine(daysCount);
            Console.WriteLine(profit);
        }
    }
}