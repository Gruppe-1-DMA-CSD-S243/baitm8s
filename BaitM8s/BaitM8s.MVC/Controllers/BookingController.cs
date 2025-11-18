using BaitM8s.APIClient.Clients;
using BaitM8s.APIClient.Interfaces;
using BaitM8s.DAL.Model;
using Microsoft.AspNetCore.Mvc;

namespace BaitM8s.MVC.Controllers
{
    public class BookingController : Controller
    {
        private readonly IAPIClient<Booking> _bookingApiClient;

        public BookingController(IAPIClient<Booking> bookingApiClient)
        {
            _bookingApiClient = bookingApiClient;
        }

        public IActionResult Calendar()
        {
            var bookings = _bookingApiClient.GetAll();

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
                var newId = await _bookingApiClient.CreateAsync(booking);

                return RedirectToAction("Details", "Booking", new { id = newId });
            }
            //TODO: giv fejlbesked og  vis formular igen
            return View();
        }

        public IActionResult Index()
        {
            return View(_bookingApiClient.GetAll());
        }

        [HttpGet]
        public IActionResult Details(int? Id)
        {
            if (!Id.HasValue)
            {
                return View();
            }

            var booking = _bookingApiClient.GetOne(Id.Value);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateAsync(Booking booking)
        //{
        //    if (!ModelState.IsValid)
        //        return View(booking); // vis formular igen

        //    try
        //    {
        //        int newId = await _bookingApiClient.CreateAsync(booking);

        //        return RedirectToAction("Details", "Booking", new { id = newId });
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError(string.Empty, $"Error creating booking: {ex.Message}");
        //        return View(booking);
        //    }
        //}



    }
}
