using BaitM8s.APIClient.Clients;
using BaitM8s.APIClient.Interfaces;
using BaitM8s.DAL.DTO;
using BaitM8s.DAL.Model;
using Humanizer.Localisation.TimeToClockNotation;
using Microsoft.AspNetCore.Mvc;

namespace BaitM8s.MVC.Controllers
{
    public class FishingSpotController : Controller
    {
        private readonly IFishingSpotAPIClient _fishingSpotApiClient;
        //TODO: id currently decides if it is an angler(0) or owner(1-n) index that is returned, change hardcode later
        private readonly int userType = 0;

        public FishingSpotController(IFishingSpotAPIClient fishingSpotApiClient)
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

        public async Task<IActionResult> Map()
        {
            try
            {
                IEnumerable<FishingSpotDTO> fishingSpots = await _fishingSpotApiClient.GetAllFishingSpotsAsync();

                foreach (var fishingSpot in fishingSpots)
                {
                    fishingSpot.Longitude = (float)Math.Round(fishingSpot.Longitude, 2); //TODO: TEMP LØSNING!
                    fishingSpot.Latitude = (float)Math.Round(fishingSpot.Latitude, 2); //TODO: TEMP LØSNING!
                }

                return View(fishingSpots);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] FishingSpotDTO fishingSpot)
        {
            try
            {
                fishingSpot.IsAwaitingApproval = true;
                fishingSpot.FishSpecies = new List<string>(); //TODO: Dette er en temp løsning!

                int newId = await _fishingSpotApiClient.CreateFishingSpotAsync(fishingSpot);

                return RedirectToAction("Details", new { id = newId });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }
    }
}