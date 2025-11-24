using BaitM8s.DAL.DAO;
using BaitM8s.DAL.DTO;
using BaitM8s.DAL.Interfaces;
using BaitM8s.Services.Notifications.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BaitM8s.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FishingSpotsController : Controller
    {
        private readonly IFishingSpotDAO _fishingSpotDAO;
        public FishingSpotsController(IFishingSpotDAO fishingSpotDAO)
        {
            _fishingSpotDAO = fishingSpotDAO;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FishingSpotDTO>>> GetAsync()
        {
            try
            {
                return Ok(await _fishingSpotDAO.GetAllFishingSpotsAsync());
            }
            catch (Exception ex)
            {
                // This line is used for debugging.
                return StatusCode(500, $"Error: {ex.Message}");

                //return StatusCode(500, $"An error occurred trying to retrieve all fishing spots.");
            }
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<FishingSpotDTO>> GetAsync(int id)
        {
            try
            {
                return Ok(await _fishingSpotDAO.GetFishingSpotAsync(id));
            }
            catch (Exception ex)
            {
                // This line is used for debugging.
                return StatusCode(500, $"Error: {ex.Message}");

                //return StatusCode(500, $"An error occurred trying to retrieve the fishing spot with id {id}.");
            }
        }

        [HttpGet("by-owner/{id}")]
        public async Task<ActionResult<IEnumerable<FishingSpotDTO>>> GetAllByOwnerAsync(int id)
        {
            try
            {
                return Ok(await _fishingSpotDAO.GetFishingSpotsByPondOwnerAsync(id));
            }
            catch (Exception ex)
            {
                // This line is used for debugging.
                return StatusCode(500, $"Error: {ex.Message}");

                //return StatusCode(500, $"An error occurred trying to retrieve the fishing spots from owner id {id}.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> ManageFishingSpotAsync(int id, FishingSpotDTO fishingSpot)
        {
            try
            {
                return Ok(await _fishingSpotDAO.ManageFishingSpotAsync(fishingSpot));
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}