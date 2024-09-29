namespace CommandPattern.Models;

public class Product
{
    private string _name;
    private int _price;

    public Product(string name, int price)
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

    public void IncreasePrice(int amount)
    {
        Price += amount;
        Console.WriteLine($"The price for the {Name} has been increased by {amount}$.");
    }

    public void DecreasePrice(int amount)
    {
        if (amount < Price)
        {
            Price -= amount;
            Console.WriteLine($"The price for the {Name} has been increased by {amount}$.");
        }
    }

    public override string ToString() => $"Current price for the {Name} product is {Price}$.";
}
