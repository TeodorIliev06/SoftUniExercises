namespace _10._Rage_Expenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int headsetsBrokenCount = lostGamesCount / 2;
            int mouseBrokenCount = lostGamesCount / 3;
            int keyboardBrokenCount = lostGamesCount / 6;
            int dispayBrokenCount = lostGamesCount / 12;

            double sum = headsetPrice * headsetsBrokenCount + mousePrice * mouseBrokenCount + keyboardPrice * keyboardBrokenCount + displayPrice * dispayBrokenCount;
            Console.WriteLine($"Rage expenses: {sum:F2} lv.");
        }
    }
}