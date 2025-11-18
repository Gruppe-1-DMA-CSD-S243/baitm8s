using BaitM8s.APIClient.Clients;
using BaitM8s.APIClient.Interfaces;
using BaitM8s.DAL.Model;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace BaitM8s.MVC.Controllers
{
    public class BookingController : Controller
    {
        private readonly IAPIClient<Booking> _bookingAPIClient;

        public BookingController(IAPIClient<Booking> bookingAPIClient)
        {
            _bookingAPIClient = bookingAPIClient;
        }

        public IActionResult Calendar()
        {
            var bookings = _bookingAPIClient.GetAll();

            var calendarEvents = bookings.Select(booking => new
            {
                title = $"Booking #{booking.BookingNumber} ({booking.Pond})",
                start = $"{booking.Date:yyyy-MM-dd}T{booking.StartTime}",
                end = $"{booking.Date:yyyy-MM-dd}T{booking.EndTime}",
                id = booking.Id,
                
                anglerId = booking.FK_AnglerId
            });

            ViewBag.BookingJson = System.Text.Json.JsonSerializer.Serialize(calendarEvents);
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                //TODO: try catch
                var newId = await _bookingAPIClient.CreateAsync(booking);

                return RedirectToAction("Details", "Booking", new { id = newId });
            }
            //TODO: giv fejlbesked og  vis formular igen
            return View();
        }

        public IActionResult Index()
        {
            return View(_bookingAPIClient.GetAll());
        }

        [HttpGet]
        public IActionResult Details(int? Id)
        {
            if (!Id.HasValue)
            {
                return View();
            }

            var booking = _bookingAPIClient.GetOne(Id.Value);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

    }
}
