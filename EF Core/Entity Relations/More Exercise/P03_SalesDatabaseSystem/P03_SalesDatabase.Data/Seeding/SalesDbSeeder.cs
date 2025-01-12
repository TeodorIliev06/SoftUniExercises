using Microsoft.EntityFrameworkCore;

namespace P03_SalesDatabase.Data.Seeding
{
    public static class SalesDbSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            ProductSeeder.Seed(modelBuilder);
            CustomerSeeder.Seed(modelBuilder);
            StoreSeeder.Seed(modelBuilder);
            SaleSeeder.Seed(modelBuilder);
        }
    }
}