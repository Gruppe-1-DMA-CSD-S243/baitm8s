using BaitM8s.APIClient.Clients;
using BaitM8s.APIClient.Interfaces;
using BaitM8s.DAL.DTO;
using BaitM8s.DAL.Interfaces;
using System.CodeDom;

namespace BaitM8s.MVC
{
    public class Program
    {
        private const string _apiBaseUri = "https://localhost:8888/api";
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .AddUserSecrets<Program>()
            .AddEnvironmentVariables()
            .Build();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IBookingAPIClient>(apiClient => 
            new BookingAPIClient(configuration["API_BASE_URI"] ?? _apiBaseUri));

            builder.Services.AddScoped<IAnglerAPIClient>(angler => 
            new AnglerAPIClient(configuration["API_BASE_URI"] ?? _apiBaseUri));

            builder.Services.AddScoped<IFishingSpotAPIClient>(fishingSpot =>
            new FishingSpotAPIClient(configuration["API_BASE_URI"] ?? _apiBaseUri));

            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
