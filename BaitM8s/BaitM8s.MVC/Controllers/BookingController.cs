
using BaitM8s.APIClient.Interfaces;
using BaitM8s.DAL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BaitM8s.MVC.Controllers
{
    public class BookingController : Controller
    {
        private readonly IAPIClient<BookingDTO> _bookingApiClient;

        public BookingController(IAPIClient<BookingDTO> bookingApiClient)
        {
            _bookingApiClient = bookingApiClient;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var bookings = await _bookingApiClient.GetAllAsync();

        //    var calendarEvents = bookings
        //        .SelectMany(booking => booking.TimeSlots.Select(ts => new
        //        {
        //            title = $"Booking #{booking.BookingNumber} ({booking.Pond})",

        //            start = ts.StartTime.ToString("o"),
        //            end = ts.EndTime.ToString("o"),

        //            id = $"{booking.Id}-{ts.Id}",

        //            extendedProps = new
        //            {
        //                bookingNumber = booking.BookingNumber,
        //                pond = booking.Pond,
        //                people = booking.NumberOfPeople,
        //                timeSlotNumber = ts.TimeSlotNumber,
        //                capacity = ts.Capacity
        //            }
        //        }));

        //    ViewBag.BookingJson = System.Text.Json.JsonSerializer.Serialize(calendarEvents);
        //    return View();
        //}

        public async Task<IActionResult> Calendar()
        {
            var bookings = await _bookingApiClient.GetAllAsync();

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
        public async Task<ActionResult<BookingDTO>> Delete(int id)
        {
            try
            {
                return View(await _bookingApiClient.GetOneAsync(id));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, BookingDTO booking)
        {
            try
            {
                bool deleted = await _bookingApiClient.DeleteAsync(id);

                if (deleted)
                {
                    return RedirectToAction("Index", "Booking");
                }

                return RedirectToAction("Delete", new { id = id });
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

        //TODO: Få kigget på det her.Der er to index actions!
        public async Task<IActionResult> Index()
        {
            return View(await _bookingApiClient.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? Id)
        {
            if (!Id.HasValue)
            {
                return View();
            }

            var booking = await _bookingApiClient.GetOneAsync(Id.Value);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }
    }
}
