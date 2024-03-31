namespace Orders;

internal class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Product> productsMap = new();

        string input;
        while ((input = Console.ReadLine()) != "buy")
        {
            string[] productInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = productInfo[0];
            decimal price = decimal.Parse(productInfo[1]);
            decimal quantity = decimal.Parse(productInfo[2]);

            Product product = new(name, price, quantity);

            if (!productsMap.ContainsKey(name))
            {
                productsMap.Add(product.Name, product);
            }
            else
            {
                productsMap[name].Update(product.Price, product.Quantity);
            }
        }

        foreach (var productPair in productsMap)
        {
            Console.WriteLine(productPair.Value);
        }
    }
}
class Product
{
    public Product(string name, decimal price, decimal quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public decimal Quantity { get; set; }

    public decimal TotalPrice => Price * Quantity;

    public void Update(decimal price, decimal quantity)
    {
        Price = price;
        Quantity += quantity;
    }

    public override string ToString() => $"{Name} -> {TotalPrice:F2}";
}