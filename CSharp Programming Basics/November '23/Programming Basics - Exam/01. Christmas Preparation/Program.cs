namespace _01._Christmas_Preparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wrap = int.Parse(Console.ReadLine());
            int fabric = int.Parse(Console.ReadLine());
            double glue = double.Parse(Console.ReadLine());
            int disc = int.Parse(Console.ReadLine());

            double moneyForWrap = wrap * 5.80;
            double moneyForFabric = fabric * 7.20;
            double moneyForGlue = glue * 1.20;
            double totalWithoutDisc = (moneyForFabric + moneyForGlue + moneyForWrap) * disc / 100;
            double total = moneyForWrap + moneyForFabric + moneyForGlue - totalWithoutDisc;

            Console.WriteLine($"{total:f3}");
        }
    }
}