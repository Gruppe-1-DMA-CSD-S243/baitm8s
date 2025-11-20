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

        public FishingSpotController(IFishingSpotDAO fishingSpotApiClient)
        {
            _fishingSpotApiClient = fishingSpotApiClient;
        }

        [HttpGet]
        public async Task<IActionResult> OwnerOverview(int id)
        {
            var fishingSpots = await _fishingSpotApiClient.GetFishingSpotsByPondOwnerAsync(id);
            return View(fishingSpots);
        }

        [HttpGet]
        public async Task<IActionResult> AllOverview()
        {
            var fishingSpots = await _fishingSpotApiClient.GetAllFishingSpotsAsync();
            return View(fishingSpots);
        }

        [HttpGet]
        public async Task<IActionResult> OwnerDetails()
        {
            var fishingSpots = await _fishingSpotApiClient.GetAllFishingSpotsAsync();
            return View(fishingSpots);
        }

        [HttpGet]
        public async Task<IActionResult> RegisterOwnership()
        {
            var fishingSpots = await _fishingSpotApiClient.GetAllFishingSpotsAsync();
            return View(fishingSpots);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterOwnership(int id)
        {
            var fishingSpots = await _fishingSpotApiClient.GetAllFishingSpotsAsync();
            return View(fishingSpots);
        }

        [HttpGet]
        public async Task<IActionResult> RemoveOwnership()
        {
            var fishingSpots = await _fishingSpotApiClient.GetAllFishingSpotsAsync();
            return View(fishingSpots);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveOwnership(int id)
        {
            var fishingSpots = await _fishingSpotApiClient.GetAllFishingSpotsAsync();
            return View(fishingSpots);
        }
    }
}
