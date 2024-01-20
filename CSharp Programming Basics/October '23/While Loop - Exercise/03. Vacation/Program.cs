namespace _03._Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double MoneyNeeded = double.Parse(Console.ReadLine());
            double OwnedMoney = double.Parse(Console.ReadLine());
            int days = 0;
            int spentcounter = 0;

            while (true)
            {
                string activity = Console.ReadLine();
                double amount = double.Parse(Console.ReadLine());
                days++;
                if (activity == "spend")
                {
                    OwnedMoney -= amount;
                    if (OwnedMoney < 0) { OwnedMoney = 0; }
                    spentcounter++;
                }
                else
                {
                    OwnedMoney += amount;
                    spentcounter = 0;
                }
                if (spentcounter == 5)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine(days);
                    break;
                }
                if (OwnedMoney >= MoneyNeeded)
                {
                    Console.WriteLine($"You saved the money for {days} days.");
                    break;
                }
            }
        }
    }
}