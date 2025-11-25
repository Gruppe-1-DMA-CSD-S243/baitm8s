using BaitM8s.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BaitM8s.DAL.Model;

namespace BaitM8s.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FishingSpotsController : ControllerBase
    {
        private readonly IFishingSpotDAO _fishingSpotDAO;

        public FishingSpotsController(IFishingSpotDAO dataAccessLayer)
        {
            _fishingSpotDAO = dataAccessLayer;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FishingSpot>> Get(int id)
        {
            try
            {
                var fishingSpot = await _fishingSpotDAO.GetFishingSpotAsync(id);
                if (fishingSpot == null)
                {
                    return NotFound();
                }
                return Ok(fishingSpot);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FishingSpot>>> GetAll()
        {
            try
            {
                var fishingSpots = await _fishingSpotDAO.GetAllFishingSpotsAsync();
                return Ok(fishingSpots);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] FishingSpot fishingSpot)
        {
            try
            {
                var newId = await _fishingSpotDAO.CreateFishingSpotAsync(fishingSpot);
                return CreatedAtAction(nameof(Get), new { id = newId }, newId);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(500, "Internal server error");
            }
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] FishingSpot fishingSpot)
        {
            if (id != fishingSpot.Id)
                return BadRequest("Id mismatch");

            int updated = await _fishingSpotDAO.UpdateFishingSpotAsync(fishingSpot);

            if (updated==null)
                return NotFound("Fishing spot not found");

            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var success = await _fishingSpotDAO.DeleteFishingSpotAsync(id);
                if (!success)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
