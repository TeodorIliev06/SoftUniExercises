using Composite.Models;

namespace Composite;

public class Program
{
    static void Main(string[] args)
    {
        SingleGift phone = new("Phone", 256);
        phone.CalculateTotalPrice();
        Console.WriteLine();

        CompositeGift rootBox = new("RootBox", 0);
        SingleGift truckToy = new("TruckToy", 289);
        SingleGift plainToy = new("PlainToy", 587);
        rootBox.Add(truckToy);
        rootBox.Add(plainToy);

        CompositeGift childBox = new("ChildBox", 0);
        SingleGift soldierToy = new("SoldierToy", 200);   
        childBox.Add(soldierToy);
        rootBox.Add(childBox);

        Console.WriteLine($"Total price of this composite present is: {rootBox.CalculateTotalPrice()}");
    }
}
