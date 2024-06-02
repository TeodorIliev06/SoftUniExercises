using System.Text.RegularExpressions;
namespace _01._Furniture
{
    /*
     * >>Sofa<<312.23!3
>>TV<<300!5
>Invalid<<!5
Purchase
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<name>[A-Za-z]+)<<(?<price>\d+\.\d+|\d+)!(?<quantity>\d+)";
            string input;

            List<Furniture> furnitures = new List<Furniture>();

            while ((input = Console.ReadLine()) != "Purchase")
            {
                foreach (Match match in Regex.Matches(input, pattern))
                {
                    string name = match.Groups["name"].Value;
                    decimal price = decimal.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);

                    Furniture furniture = new Furniture(name, price, quantity);
                    furnitures.Add(furniture);
                }
            }

            Console.WriteLine("Bought furniture:");

            decimal spentMoney = 0;
            foreach (Furniture furniture in furnitures)
            {
                Console.WriteLine(furniture.Name);
                spentMoney += furniture.TotalPrice;
            }

            Console.WriteLine($"Total money spend: {spentMoney:f2}");
        }
    }

    class Furniture
    {
        public Furniture(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => Price * Quantity;
    }
}