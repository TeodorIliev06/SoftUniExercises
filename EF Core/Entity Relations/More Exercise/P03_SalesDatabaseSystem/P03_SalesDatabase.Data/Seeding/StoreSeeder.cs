using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data.Seeding
{
    public static class StoreSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            var random = new Random();
            var stores = new List<Store>();

            for (int i = 1; i <= 10; i++)
            {
                stores.Add(new Store
                {
                    StoreId = i,
                    Name = $"Store{i}"
                });
            }

            builder.Entity<Store>().HasData(stores);
        }
    }
}