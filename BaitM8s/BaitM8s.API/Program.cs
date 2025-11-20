
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

            //builder.Services.AddScoped<IAnglerDAO>(AnglerDAO => 
            //new AnglerDAO(configuration["env var"] ?? "Data Source=localhost;Database=BaitM8s;Persist Security Info=True;User ID=sa;Password=@12tf56so;Trust Server Certificate=True"));

            //builder.Services.AddScoped<IBookingDAO>(bookingDAO => 
            //new BookingDAO(configuration["CONNECTION_STRING"] ?? "Data Source=localhost;Database=BaitM8s;Persist Security Info=True;User ID=sa;Password=@12tf56so;Trust Server Certificate=True"));

            builder.Services.AddScoped<IAnglerDAO>(anglerDAO =>
            new AnglerDAO("Data Source = localhost; Database = BaitM8s; Persist Security Info = True; User ID = sa; Password =@12tf56so; Trust Server Certificate = True"));

            builder.Services.AddScoped<IBookingDAO>(bookingDAO =>
            new BookingDAO("Data Source = localhost; Database = BaitM8s; Persist Security Info = True; User ID = sa; Password =@12tf56so; Trust Server Certificate = True"));

            builder.Services.AddScoped<INotificationService>(service =>
            new TelegramNotificationService("https://api.telegram.org", "8230947150:AAHn8ZkyVU4DLGMvtGY06u0ZDz1lnVtHpKY", "-1003297586522"));

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
