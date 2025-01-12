using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data.Seeding
{
    public static class ProductSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            var random = new Random();

            // Generate sample data for Products
            var products = new List<Product>();
            for (int i = 1; i <= 20; i++)
            {
                products.Add(new Product
                {
                    ProductId = i,
                    Name = $"Product{i}",
                    Quantity = random.Next(1, 100),
                    Price = (decimal)(random.NextDouble() * 1000)
                });
            }

            builder.Entity<Product>().HasData(products);
        }
    }
}
