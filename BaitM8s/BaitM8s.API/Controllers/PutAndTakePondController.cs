using BaitM8s.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BaitM8s.DAL.Model;

namespace BaitM8s.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PutAndTakePondController : ControllerBase
    {
        private readonly IPutAndTakePondDao _putAndTakePondDao;

        public PutAndTakePondController(IPutAndTakePondDao dataAccessLayer)
        {
            _putAndTakePondDao = dataAccessLayer;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PutAndTakePond>>> Get()
        {
            try
            {
                var ponds = await _putAndTakePondDao.GetAllPutAndTakePondsAsync();
                return Ok(ponds);
            }
            catch (Exception ex)
            {
                // This line is used for debugging.
                return StatusCode(500, $"Error: {ex.Message}");
                //return StatusCode(500, $"An error occurred trying to retrieve all put and take ponds.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PutAndTakePond>> Get(int id)
        {
            try
            {
                var pond = await _putAndTakePondDao.GetPutAndTakePondByIdAsync(id);
                if (pond == null)
                {
                    return NoContent();
                }
                return Ok(pond);
            }
            catch (Exception ex)
            {
                // This line is used for debugging.
                return StatusCode(500, $"Error: {ex.Message}");
                //return StatusCode(500, $"An error occurred trying to retrieve the put and take pond with id {id}.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] PutAndTakePond pond)
        {
            try
            {
                var createdPondId = await _putAndTakePondDao.CreatePutAndTakePondAsync(pond);
                return CreatedAtAction(nameof(Get), new { id = createdPondId }, createdPondId);
            }
            catch (Exception ex)
            {
                // This line is used for debugging.
                return StatusCode(500, $"Error:{id} {ex.Message}");
                //return StatusCode(500, $"An error occurred trying to create a new put and take pond.");
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _putAndTakePondDao.DeletePutAndTakePondAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // This line is used for debugging.
                return StatusCode(500, $"Error: {ex.Message}");
                //return StatusCode(500, $"An error occurred trying to delete the put and take pond with id {id}.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PutAndTakePond pond)
        {
            try
            {
                if (id != pond.FishingSpotNumber)
                {
                    return BadRequest("Pond ID mismatch.");
                }
                await _putAndTakePondDao.UpdatePutAndTakePondAsync(pond);
                return NoContent();
            }
            catch (Exception ex)
            {
                // This line is used for debugging.
                return StatusCode(500, $"Error: {ex.Message}");
                //return StatusCode(500, $"An error occurred trying to update the put and take pond with id {id}.");
            }
        }
    }

}
