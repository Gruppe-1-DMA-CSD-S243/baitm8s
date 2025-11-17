
using BaitM8s.DAL.DAO;
using BaitM8s.DAL.Interfaces;

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

            //builder.Services.AddScoped<IBookingDAO>(bookingDAO =>
            //new BookingDAO(configuration["CONNECTION_STRING"]));
            builder.Services.AddScoped<IBookingDAO>(bookingDAO =>
            new InMemoryBookingDAO("connectionString"));

            builder.Services.AddScoped<ITimeSlotDAO>(timeSlotDAO =>
            new InMemoryTimeSlotDAO("connectionString"));

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
