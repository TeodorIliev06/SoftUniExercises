using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            string pattern = @"%(?<customerName>[A-Z][a-z]+)\%[^|$%.]*\<(?<product>\w+)\>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>\d+([.]\d+)?)\$";

            List<Customer> customers = new List<Customer>();

            while ((input = Console.ReadLine()) != "end of shift")
            {
                foreach (Match match in Regex.Matches(input, pattern))
                {
                    string customerName = match.Groups["customerName"].Value;
                    string product = match.Groups["product"].Value;
                    int count = int.Parse(match.Groups["count"].Value);
                    decimal price = decimal.Parse(match.Groups["price"].Value);

                    customers.Add(new Customer(customerName, product, count, price));
                }
            }

            decimal totalIncome = 0;
            foreach (Customer customer in customers)
            {
                Console.WriteLine($"{customer.Name}: {customer.Product} - {customer.TotalPrice:F2}");
                totalIncome += customer.TotalPrice;
            }

            Console.WriteLine($"Total income: {totalIncome:F2}");
        }

        class Customer
        {
            public Customer(string name, string product, int count, decimal price)
            {
                Name = name;
                Product = product;
                Count = count;
                Price = price;
            }

            public string Name { get; set; }
            public string Product { get; set; }
            public int Count { get; set; }
            public decimal Price { get; set; }
            public decimal TotalPrice => Price * Count;
        }
    }
}