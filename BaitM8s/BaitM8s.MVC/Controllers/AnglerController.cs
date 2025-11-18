using BaitM8s.APIClient.Clients;
using BaitM8s.APIClient.Interfaces;
using BaitM8s.DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaitM8s.MVC.Controllers
{
    public class AnglerController : Controller
    {
        private readonly IAPIClient<Angler> _anglerApiClient;
        public AnglerController(IAPIClient<Angler> anglerApiClient)
        {
            _anglerApiClient = anglerApiClient;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var anglers = _anglerApiClient.GetAll();
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


        [HttpGet]
        public IActionResult Details(int? anglerId)
        {
            if (!anglerId.HasValue)
            {
                return View();
            }

            var angler = _anglerApiClient.GetOne(anglerId.Value);
            if (angler == null)
            {
                return NotFound();
            }

            return View(angler);
        }
    }
}
