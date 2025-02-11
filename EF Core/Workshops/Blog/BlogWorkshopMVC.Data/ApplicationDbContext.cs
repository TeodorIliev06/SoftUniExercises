namespace BlogWorkshopMVC.Data
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

	using BlogWorkshopMVC.Data.Models;

	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Article> Articles { get; set; } = null!;
		public DbSet<ApplicationUser> Users { get; set; } = null!;
	}
}
