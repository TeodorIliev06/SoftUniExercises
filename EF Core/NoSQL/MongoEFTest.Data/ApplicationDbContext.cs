namespace MongoEFTest.Data
{
	using Microsoft.EntityFrameworkCore;
	using MongoDB.EntityFrameworkCore.Extensions;
	using MongoEFTest.Data.Models;

	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext()
		{
		}

		public ApplicationDbContext(DbContextOptions options)
			: base(options)
		{
		}

		public DbSet<Article> Articles { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Article>().ToCollection("articles");
		}
	}
}