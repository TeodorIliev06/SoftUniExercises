namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();

            string input;
            while((input = Console.ReadLine()) != "Revision")
            {
                string[] inputInfo = input.Split(", ");
                string shop = inputInfo[0];
                string product = inputInfo[1];
                double price = double.Parse(inputInfo[2]);

                if(!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }

                if (!shops[shop].ContainsKey(product))                    
                { 
                    shops[shop].Add(product, 0); 
                }

                shops[shop][product] = price;
            }

            shops = shops.OrderBy(s => s.Key).ToDictionary(s => s.Key, s => s.Value);
            foreach (var shopPair in shops)
            {
                Console.WriteLine($"{shopPair.Key}->");
                foreach (var productPair in shopPair.Value)
                {
                    Console.WriteLine($"Product: {productPair.Key}, Price: {productPair.Value}");
                }
            }
        }
    }
}
