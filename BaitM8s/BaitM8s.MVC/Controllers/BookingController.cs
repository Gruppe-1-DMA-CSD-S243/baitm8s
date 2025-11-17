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

        public async Task<IActionResult> Index()
        {
            var bookings = await _bookingApiClient.GetAllAsync();

            var calendarEvents = bookings
                .SelectMany(booking => booking.TimeSlots.Select(ts => new
                {
                    title = $"Booking #{booking.BookingNumber} ({booking.Pond})",

                    // FullCalendar expects ISO 8601
                    start = ts.StartTime.ToString("o"),
                    end = ts.EndTime.ToString("o"),

                    id = $"{booking.Id}-{ts.Id}",

                    extendedProps = new
                    {
                        bookingNumber = booking.BookingNumber,
                        pond = booking.Pond,
                        people = booking.NumberOfPeople,
                        timeSlotNumber = ts.TimeSlotNumber,
                        capacity = ts.Capacity
                    }
                }));

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
    }
}
