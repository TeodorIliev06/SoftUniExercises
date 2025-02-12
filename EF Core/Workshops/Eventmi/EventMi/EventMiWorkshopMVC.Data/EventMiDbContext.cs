namespace EventMiWorkshopMVC.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class EventMiDbContext : DbContext
    {
        public EventMiDbContext()
        {

        }

        public EventMiDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Event> Events { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .Property(e => e.IsActive)
                .HasDefaultValue(true);
        }
    }
}
