using BaitM8s.APIClient.Clients;
using BaitM8s.APIClient.Interfaces;
using BaitM8s.DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaitM8s.MVC.Controllers
{
    public class AnglerController : Controller
    {
        private readonly IAnglerAPIClient _anglerAPIClient;
        private readonly IBookingAPIClient _bookingAPIClient;
        public AnglerController(IAnglerAPIClient anglerAPIClient, IBookingAPIClient bookingAPIClient)
        {
            _anglerAPIClient = anglerAPIClient;
            _bookingAPIClient = bookingAPIClient;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var anglers = _anglerAPIClient.GetAllAsync();
            return View(anglers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            return View();
        }


        //[HttpGet]
        //public IActionResult Details(int? anglerId)
        //{
        //    if (!anglerId.HasValue)
        //    {
        //        return View();
        //    }

        //    var angler = _anglerApiClient.GetOne(anglerId.Value);
        //    if (angler == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(angler);
        //}

        [HttpGet]
        public async Task<IActionResult> Details(int? anglerId)
        {
            if (!anglerId.HasValue)
                return View();

            var angler = await _anglerAPIClient.GetOneAsync(anglerId.Value);
            if (angler == null)
                return NotFound();

            var bookings = await _bookingAPIClient.GetBookingsForAnglerAsync(anglerId.Value);

            ViewBag.Bookings = bookings;

            return View(angler);
        }
    }
}
