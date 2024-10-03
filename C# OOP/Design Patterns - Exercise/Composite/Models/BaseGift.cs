namespace Composite.Models;

public abstract class BaseGift
{
    private string _name;
    private int _price;

    protected BaseGift(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }
    public int Price
    {
        get => _price;
        set => _price = value;
    }

    public abstract int CalculateTotalPrice();
}
