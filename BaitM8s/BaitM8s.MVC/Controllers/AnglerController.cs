using BaitM8s.APIClient.Clients;
using BaitM8s.APIClient.Interfaces;
using BaitM8s.DAL.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaitM8s.MVC.Controllers
{
    public class AnglerController : Controller
    {
        private readonly IAPIClient<AnglerDTO> _anglerApiClient;

        public AnglerController(IAPIClient<AnglerDTO> anglerApiClient)
        {
            _anglerApiClient = anglerApiClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var anglers = await _anglerApiClient.GetAllAsync();
            return View(anglers);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookingDTO booking)
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Details(int? anglerId)
        {
            if (!anglerId.HasValue)
            {
                return View();
            }

            var angler = await _anglerApiClient.GetOneAsync(anglerId.Value);
            if (angler == null)
            {
                return NotFound();
            }

            return View(angler);
        }
    }
}
