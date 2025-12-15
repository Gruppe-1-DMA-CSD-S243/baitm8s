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
        //TODO: UserType bestemmer om brugeren er Angler eller Pondowner og bruges til at styre hvilket View, der skal returneres. Dette er en midlertidig løsning!
        private int UserType =>
            HttpContext.Session.GetInt32("UserType") ?? 0;

        public FishingSpotController(IFishingSpotAPIClient fishingSpotApiClient)
        {
            _fishingSpotApiClient = fishingSpotApiClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            if (UserType == 0)
            {
                var fishingSpots = await _fishingSpotApiClient.GetAllFishingSpotsAsync();
                return View("Angler/Index", fishingSpots);
            }
            else
            {
                var fishingSpots = await _fishingSpotApiClient.GetFishingSpotsByPondOwnerAsync(UserType);
                return View("Owner/Index", fishingSpots);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var fishingSpot = await _fishingSpotApiClient.GetFishingSpotAsync(id);

            if (UserType == 0)
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
                    // Leaflet kan ikke læse float værdier med for mange decimaler.
                    fishingSpot.Longitude = (float)Math.Round(fishingSpot.Longitude, 2); 
                    fishingSpot.Latitude = (float)Math.Round(fishingSpot.Latitude, 2); 
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
                fishingSpot.FishSpecies = new List<string>(); //TODO: Midlertidig løsning til at tilføjge FishSpecies på nyoprettet FishingSpot!

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