namespace MiniORM.App
{
    using MiniORM.App.Models;

    internal class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new SoftUniDbContext("Server=example;Database=exampleDb;Integrated Security=True;TrustServerCertificate=True");

            var departments = new List<Department>
            {
                new Department { Id = 1, Name = "First" },
                new Department { Id = 2, Name = "Second" }
            };
            var changeTracker = new ChangeTracker<Department>(departments);

            foreach (var (original, copy) in departments.Zip(changeTracker.AllEntities))
            {
                original.Id = 1;
                Console.WriteLine(ReferenceEquals(original, copy));
            }
        }
    }
}
