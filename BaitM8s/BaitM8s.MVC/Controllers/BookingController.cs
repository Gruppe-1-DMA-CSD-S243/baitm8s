
using BaitM8s.APIClient.Clients;
using BaitM8s.APIClient.Interfaces;
using BaitM8s.DAL.DTO;
using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.Model;
using Microsoft.AspNetCore.Mvc;

namespace BaitM8s.MVC.Controllers
{
    public class BookingController : Controller
    {
        private readonly IAPIClient<BookingDTO> _bookingApiClient;
        private readonly IFishingSpotDAO _fishingSpotApiClient;

        public BookingController(IAPIClient<BookingDTO> bookingApiClient, IFishingSpotDAO fishingSpotApiClient)
        {
            _fishingSpotApiClient = fishingSpotApiClient;
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
            //TODO: Få lige fixet det her hack!
            booking = new BookingDTO
            {
                Id = 99,
                BookingNumber = "BK-NEWNUMB",
                Pond = "NewPond",
                TimeSlots = new List<BaitM8s.DAL.Model.TimeSlot>(),
                //Date = DateTime.Now,
                StartTime = TimeSpan.FromMinutes(80),
                EndTime = TimeSpan.FromMinutes(100),
                NumberOfPeople = 3,
                FK_AnglerId = 1
            };
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

        [HttpGet]
        public async Task<IActionResult> AvailableTimes(int id)
        {
            var fishingSpot = await _fishingSpotApiClient.GetFishingSpotAsync(id);
            return View(fishingSpot);
        }

        [HttpGet]
        public async Task<IActionResult> BookAvailableTime(string day, TimeSpan startTime, TimeSpan endTime)
        {
            BookingDTO booking = new BookingDTO { Day = day, StartTime = startTime, EndTime = endTime, Month = "November", Year = 2020, WeekNumber = 10, FK_AnglerId = 1, FK_FishingSpotId = 1 };
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
