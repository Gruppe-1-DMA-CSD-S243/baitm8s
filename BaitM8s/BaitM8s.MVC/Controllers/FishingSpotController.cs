using BaitM8s.APIClient.Clients;
using BaitM8s.APIClient.Interfaces;
using BaitM8s.DAL.DTO;
using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.Model;
using Microsoft.AspNetCore.Mvc;

namespace BaitM8s.MVC.Controllers
{
    public class FishingSpotController : Controller
    {
        private readonly IFishingSpotDAO _fishingSpotApiClient;
        //TODO: id currently decides if it is an angler(0) or owner(1-n) index that is returned, change hardcode later
        private readonly int userType = 1;

        public FishingSpotController(IFishingSpotDAO fishingSpotApiClient)
        {
            _fishingSpotApiClient = fishingSpotApiClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {

            //TODO: Change to id 
            if (userType == 0)
            {
                var fishingSpots = await _fishingSpotApiClient.GetAllFishingSpotsAsync();
                return View("Angler/Index", fishingSpots);
            }
            else
            {
                var fishingSpots = await _fishingSpotApiClient.GetFishingSpotsByPondOwnerAsync(userType);
                return View("Owner/Index", fishingSpots);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var fishingSpot = await _fishingSpotApiClient.GetFishingSpotAsync(id);

            if (userType == 0)
            {
                return View("Angler/Details", fishingSpot);
            }
            else
            {
                return View("Owner/Details", fishingSpot);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Manage(int id)
        {
            var fishingSpot = await _fishingSpotApiClient.GetFishingSpotAsync(id);
            return View("Owner/Manage", fishingSpot);
        }

        [HttpPost]
        public async Task<IActionResult> Manage(FishingSpotDTO fishingSpot)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool updated = await _fishingSpotApiClient.ManageFishingSpotAsync(fishingSpot);

            if (updated)
            {
                return View("Owner/Details", fishingSpot);
            }

            return RedirectToAction("Owner/Manage", new { fishingSpot.Id });
        }

        //[HttpGet]
        //public async Task<IActionResult> RegisterOwnership()
        //{
        //    var fishingSpots = await _fishingSpotApiClient.GetAllFishingSpotsAsync();
        //    return View(fishingSpots);
        //}

        //[HttpPost]
        //public async Task<IActionResult> RegisterOwnership(int id)
        //{
        //    var fishingSpots = await _fishingSpotApiClient.GetAllFishingSpotsAsync();
        //    return View(fishingSpots);
        //}

        //[HttpGet]
        //public async Task<IActionResult> RemoveOwnership()
        //{
        //    var fishingSpots = await _fishingSpotApiClient.GetAllFishingSpotsAsync();
        //    return View(fishingSpots);
        //}

        //[HttpPost]
        //public async Task<IActionResult> RemoveOwnership(int id)
        //{
        //    var fishingSpots = await _fishingSpotApiClient.GetAllFishingSpotsAsync();
        //    return View(fishingSpots);
        //}
    }
}