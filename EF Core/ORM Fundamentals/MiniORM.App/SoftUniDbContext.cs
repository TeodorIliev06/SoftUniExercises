namespace MiniORM.App
{
    using MiniORM.App.Models;

    public class SoftUniDbContext(
        string connectionString) : DbContext(connectionString)
    {
        public DbSet<Department> Departments { get; } = null!;
        public DbSet<Employee> Employees { get; } = null!;
        public DbSet<Project> Projects { get; } = null!;
        public DbSet<Project> EmployeesProjects { get; } = null!;
    }
}
