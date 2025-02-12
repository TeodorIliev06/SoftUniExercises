namespace EventMiWorkshopMVC.Web
{
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Services.Data;
    using Services.Data.Contracts;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services
                .AddDbContext<EventMiDbContext>(cfg =>
                    cfg.UseSqlServer(connectionString));
            builder.Services
                .AddScoped<IEventService, EventService>();

            WebApplication? app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //Every new migration will be applied on app start
            using IServiceScope scope = app.Services.CreateScope();

            EventMiDbContext db = scope.ServiceProvider
                .GetRequiredService<EventMiDbContext>();
            await db.Database.MigrateAsync();


            await app.RunAsync();
        }
    }
}