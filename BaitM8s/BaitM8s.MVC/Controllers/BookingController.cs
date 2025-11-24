
using BaitM8s.APIClient.Interfaces;
using BaitM8s.DAL.DTO;
using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.Model;
using Microsoft.AspNetCore.Mvc;

namespace BaitM8s.MVC.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingAPIClient _bookingApiClient;
        private readonly IFishingSpotDAO _fishingSpotApiClient;

        public BookingController(IBookingAPIClient bookingApiClient, IFishingSpotDAO fishingSpotApiClient)
        {
            _bookingApiClient = bookingApiClient;
            _fishingSpotApiClient = fishingSpotApiClient;
        }

        public async Task<IActionResult> Calendar(int id)
        {
            //var bookings = await _bookingApiClient.GetAllAsync();
            var fishingSpot = await _fishingSpotApiClient.GetFishingSpotAsync(id);


            var calendarEvents = bookings.Select(booking =>
            {
                var date = DateTime.Parse($"{booking.Day}-{booking.Month}-{booking.Year}");
                var enddate = date.AddDays(1);
                return new
                {
                    id = booking.Id,
                    title = booking.Id,
                    start = date.ToString("yyyy-MM-dd"),
                    end = enddate.ToString("yyyy-MM-dd")
                };
            });

            ViewBag.BookingJson = System.Text.Json.JsonSerializer.Serialize(calendarEvents);
            return View();
        }

        [HttpGet]
        public async Task<ActionResult<BookingDTO>> Delete(int bookingId)
        {
            try
            {
                return View(await _bookingApiClient.GetOneAsync(bookingId));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int bookingId, BookingDTO booking)
        {
            try
            {
                bool deleted = await _bookingApiClient.DeleteAsync(bookingId);

                if (deleted)
                {
                    return RedirectToAction("Index", "Booking");
                }

                return RedirectToAction("Delete", new { id = bookingId });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookingDTO booking)
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

        public async Task<IActionResult> Index()
        {
            return View(await _bookingApiClient.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? bookingId)
        {
            if (!bookingId.HasValue)
            {

                return View();
            }

            var booking = await _bookingApiClient.GetOneAsync(bookingId.Value);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        [HttpGet]
        public async Task<IActionResult> AvailableTimes(int id)
        {
            var fishingSpot = await _fishingSpotApiClient.GetFishingSpotAsync(id);
            return View(fishingSpot);
        }

        [HttpGet]
        public async Task<IActionResult> BookAvailableTime(string day, TimeSpan startTime, TimeSpan endTime)
        {
            BookingDTO booking = new BookingDTO { /*Day = day, StartTime = startTime, EndTime = endTime*/};
            return View(booking);
        }

        [HttpPost]
        public async Task<IActionResult> BookAvailableTime(BookingDTO booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

                //TODO: try catch

            }
            var newId = await _bookingApiClient.CreateAsync(booking);

            return RedirectToAction("AvailableTimes", "Booking", new { id = 1 });
            //TODO: giv fejlbesked og  vis formular igen
            return View();
        }
    }
}
