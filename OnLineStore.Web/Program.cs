using Microsoft.EntityFrameworkCore;
using OnLineStore.Infrastructure.Data;
using OnLineStore.Application.Feature.Product.Queries;
using OnLineStore.Application.Feature.User.Commands;
using Microsoft.AspNetCore.Identity;
using OnLineStore.Domain.Entities;

namespace OnLineStore.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<OnlineStoreDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                ));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
             .AddEntityFrameworkStores<OnlineStoreDbContext>()
             .AddDefaultTokenProviders();


            builder.Services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(GetAllProductsQueryHandler).Assembly));

            builder.Services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(typeof(GetAllUsersQueryHandler).Assembly));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseAuthentication();  
            app.UseAuthorization();

            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
