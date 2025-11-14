using BaitM8s.APIClient.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BaitM8s.MVC.Controllers
{
    public class BookingController : Controller
    {
        private readonly IAPIClient _bookingApiClient;

        public BookingController(IAPIClient bookingApiClient)
        {
            _bookingApiClient = bookingApiClient;
        }

        public IActionResult Index()
        {
            var bookings = _bookingApiClient.GetAllBookings();

            var calendarEvents = bookings.Select(booking => new
            {
                title = $"Booking #{booking.BookingNumber} ({booking.Pond})",
                start = $"{booking.Date:yyyy-MM-dd}T{booking.StartTime}",
                end = $"{booking.Date:yyyy-MM-dd}T{booking.EndTime}",
                id = booking.Id
            });

            ViewBag.BookingJson = System.Text.Json.JsonSerializer.Serialize(calendarEvents);
            return View();
        }
    }
}
