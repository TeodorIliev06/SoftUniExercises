namespace Composite.Models;

public class SingleGift : BaseGift
{
    public SingleGift(string name, int price)
        : base(name, price)
    {
    }

    public override int CalculateTotalPrice()
    {
        Console.WriteLine($"{Name} with the price {Price}");

        return Price;
    }
}
