using BaitM8s.APIClient.Clients;
using BaitM8s.APIClient.Interfaces;
using BaitM8s.DAL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BaitM8s.MVC.Controllers
{
    public class TimeSlotController : Controller
    {
        private readonly IAPIClient<TimeSlotDTO> _apiClient;

        public TimeSlotController(IAPIClient<TimeSlotDTO> apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var timeSlots = await _apiClient.GetAllAsync();

                var calendarEvents = timeSlots.Select(timeSlot => new
                {
                    title = $"TimeSlot {timeSlot.TimeSlotNumber}",
                    start = timeSlot.StartTime.ToString("o"),   
                    end = timeSlot.EndTime.ToString("o"),     
                    id = timeSlot.Id,

                    extendedProps = new
                    {
                        timeSlotId = timeSlot.Id,
                        date = timeSlot.Date,
                        timeSlotNumber = timeSlot.TimeSlotNumber,
                        capacity = timeSlot.Capacity,
                        isAvailable = timeSlot.IsAvailable,
                        pondId = timeSlot.FK_PutAndTakePondId
                    }
                });

                ViewBag.BookingJson = System.Text.Json.JsonSerializer.Serialize(calendarEvents);
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }
    }
}
