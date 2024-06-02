namespace _06._Store_Boxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = default;
            List<Box> storage = new List<Box>();

            while ((input = Console.ReadLine()) != "end")
            {
                string[] boxTokens = input.Split(" ");
                string serialNumber = boxTokens[0];
                string item = boxTokens[1];
                double quantity = double.Parse(boxTokens[2]);
                string price = boxTokens[3];

                Item itemObj = new Item
                {
                    Name = item,
                    Price = double.Parse(price)
                };
                Box box = new Box(serialNumber, itemObj, quantity);
                storage.Add(box);
            }

            storage = storage.OrderByDescending(x => x.Price).ToList();

            foreach (Box box in storage)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.Quantity}");
                Console.WriteLine($"-- ${box.Price:f2}");
            }
        }
        public class Item
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }

        public class Box
        {
            public Box()
            {
                Item = new Item();
            }

            public Box(string serialNumber, Item item, double quantity)
            {
                SerialNumber = serialNumber;
                Item = item;
                Quantity = quantity;
            }

            public string SerialNumber { get; set; }
            public Item Item { get; set; }
            public double Quantity { get; set; }
            public double Price
            {
                get
                {
                    return Quantity * Item.Price;
                }
            }
        }
    }
}