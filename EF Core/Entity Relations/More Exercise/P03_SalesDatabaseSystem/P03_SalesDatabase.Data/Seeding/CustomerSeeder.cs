using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data.Seeding
{
    public static class CustomerSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            var random = new Random();
            var customers = new List<Customer>();

            for (int i = 1; i <= 20; i++)
            {
                customers.Add(new Customer
                {
                    CustomerId = i,
                    Name = $"Customer{i}",
                    Email = $"customer{i}@example.com",
                    CreditCardNumber = random.Next(1000, 9999).ToString("0000 0000 0000 0000")
                });
            }

            builder.Entity<Customer>().HasData(customers);
        }
    }
}