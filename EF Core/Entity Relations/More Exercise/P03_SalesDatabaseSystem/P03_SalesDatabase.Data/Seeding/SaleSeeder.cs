using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data.Seeding
{
    public static class SaleSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var random = new Random();
            var sales = new List<Sale>();

            for (int i = 1; i <= 50; i++)
            {
                sales.Add(new Sale
                {
                    SaleId = i,
                    Date = DateTime.Now.AddDays(-random.Next(1, 1000)),
                    ProductId = random.Next(1, 21),
                    CustomerId = random.Next(1, 21),
                    StoreId = random.Next(1, 11)
                });
            }

            modelBuilder.Entity<Sale>().HasData(sales);
        }
    }
}
