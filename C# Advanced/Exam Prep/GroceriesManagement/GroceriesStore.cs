using System.Text;
namespace GroceriesManagement;

public class GroceriesStore
{
    public GroceriesStore(int capacity)
    {
        Capacity = capacity;
        Turnover = 0;
        Stall = new List<Product>();
    }

    public int Capacity { get; set; }
    public double Turnover  { get; set; }
    public List<Product> Stall { get; set; }

    public void AddProduct(Product product)
    {
        if (Stall.Contains(product) || Stall.Count == Capacity)
        {
            return;
        }
        Stall.Add(product);
    }

    public bool RemoveProduct(string name) => Stall.Remove(Stall.FirstOrDefault(x => x.Name == name));

    public string SellProduct(string name, double quantity)

    {
        if (!Stall.Any(x => x.Name == name))
        {
            return $"Product not found";
        }

        Product product = Stall.First(x => x.Name == name);
        double totalPrice = Math.Round(product.Price * quantity, 2);
        Turnover += totalPrice;

        return $"{product.Name} - {totalPrice:f2}$";
    }

    public string GetMostExpensive() => Stall.OrderByDescending(x => x.Price).FirstOrDefault().ToString();

    public string CashReport() => $"Total Turnover: {Turnover:F2}$";

    public string PriceList()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Groceries Price List:");
        foreach (var item in Stall)
        {
            sb.AppendLine(item.ToString());
        }
        return sb.ToString().TrimEnd();
    }
}
