
using BaitM8s.API.Mappings;
using BaitM8s.API.Mappings.Interfaces;
using BaitM8s.DAL.DAO;
using BaitM8s.DAL.Interfaces;
using BaitM8s.Services.Notifications;
using BaitM8s.Services.Notifications.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BaitM8s.API
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .AddUserSecrets<Program>()
            .AddEnvironmentVariables()
            .Build();

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped<IAnglerDAO>(anglerDAO =>
            new AnglerDAO(configuration["CONNECTION_STRING"]));

            builder.Services.AddScoped<IBookingDAO>(bookingDAO =>
            new BookingDAO(configuration["CONNECTION_STRING"]));

            builder.Services.AddScoped<IFishingSpotDAO>(fishingSpotDAO =>
            new FishingSpotDAO(configuration["CONNECTION_STRING"]));

            builder.Services.AddScoped<IFishingSpotMapper>(fishingSpotMapper =>
            new FishingSpotMapper());

            builder.Services.AddScoped<INotificationService>(notificationService =>
            new TelegramNotificationService("https://api.telegram.org", configuration["TELEGRAM_API_KEY"], configuration["TELEGRAM_CHAT_ID"]));

            builder.Services.AddScoped<IBookingMapper>(bookingMapper =>
            new BookingMapper());

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
