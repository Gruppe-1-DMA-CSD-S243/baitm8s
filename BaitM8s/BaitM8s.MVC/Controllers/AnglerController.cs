using BaitM8s.APIClient.Clients;
using BaitM8s.APIClient.Interfaces;
using BaitM8s.DAL.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaitM8s.MVC.Controllers
{
    public class AnglerController : Controller
    {
        private readonly IAnglerAPIClient _anglerApiClient;

        public AnglerController(IAnglerAPIClient anglerApiClient)
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
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AnglerDTO booking)
        {
            throw new NotImplementedException();
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
