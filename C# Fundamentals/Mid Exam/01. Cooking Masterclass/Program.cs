namespace _01._Cooking_Masterclass;

internal class Program
{
    static void Main(string[] args)
    {
        double budget = double.Parse(Console.ReadLine());
        int students = int.Parse(Console.ReadLine());
        double priceFlour = double.Parse(Console.ReadLine());
        double priceEgg = double.Parse(Console.ReadLine());
        double priceApron = double.Parse(Console.ReadLine());

        double freePackages = students / 5;

        double totalPriceAprons = priceApron * Math.Ceiling(students * 1.2);
        double totalPriceEggs = priceEgg * students * 10;
        double totalPriceFlour = priceFlour * (students - freePackages);
        double totalPrice = totalPriceAprons + totalPriceEggs + totalPriceFlour;
        
        if(totalPrice <= budget)
        {
            Console.WriteLine($"Items purchased for {totalPrice:f2}$.");
        }
        else
        {
            Console.WriteLine($"{(totalPrice-budget):f2}$ more needed.");
        }
    }
}
