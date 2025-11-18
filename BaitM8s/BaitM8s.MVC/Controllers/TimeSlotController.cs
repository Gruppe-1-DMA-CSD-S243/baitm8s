using BaitM8s.APIClient;
using BaitM8s.APIClient.Interfaces;
using BaitM8s.DAL.DTO;
using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.Model;
using Microsoft.AspNetCore.Mvc;

namespace BaitM8s.MVC.Controllers
{
    public class TimeSlotController : Controller
    {
        private readonly IAPIClient<TimeSlotDTO> _apiClient;

        private readonly ITimeSlotsDAO _timeSlotApiClient = new TimeSlotAPIClient("https://localhost:8888");


        [HttpGet]
        public IActionResult Manage()
        {
            return View(_timeSlotApiClient.GetAll());
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TimeSlot timeSlot)
        {

            if (ModelState.IsValid)
            {
                //TODO: try catch
                var newId = _timeSlotApiClient.Create(timeSlot);

                return RedirectToAction("Manage", "TimeSlot", new { /*Id = newId */});
            }
            //TODO: giv fejlbesked og  vis formular igen
            return View();
        }


        //public TimeSlotController(IAPIClient<TimeSlotDTO> apiClient)
        //{
        //    _apiClient = apiClient;
        //}

        //public async Task<IActionResult> Index()
        //{
        //    try
        //    {
        //        var timeSlots = await _apiClient.GetAllAsync();

        //        var calendarEvents = timeSlots.Select(timeSlot => new
        //        {
        //            title = $"TimeSlot {timeSlot.TimeSlotNumber}",
        //            start = timeSlot.StartTime.ToString("o"),   
        //            end = timeSlot.EndTime.ToString("o"),     
        //            id = timeSlot.Id,

        //            extendedProps = new
        //            {
        //                timeSlotId = timeSlot.Id,
        //                date = timeSlot.Date,
        //                timeSlotNumber = timeSlot.TimeSlotNumber,
        //                capacity = timeSlot.Capacity,
        //                isAvailable = timeSlot.IsAvailable,
        //                pondId = timeSlot.FK_PutAndTakePondId
        //            }
        //        });

        //        ViewBag.BookingJson = System.Text.Json.JsonSerializer.Serialize(calendarEvents);
        //        return View();
        //    }
        //    catch (Exception)
        //    {
        //        return RedirectToAction("Error");
        //    }
        //}
    }
}
