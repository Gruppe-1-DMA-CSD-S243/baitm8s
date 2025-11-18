using BaitM8s.DAL.Interface;
using BaitM8s.DAL.Model;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaitM8s.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AnglersController : ControllerBase
    {
        private readonly IAnglerDAO _anglerDAO;

        public AnglersController(IAnglerDAO anglerDAO)
        {
            _anglerDAO = anglerDAO;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Angler>>> GetAsync()
        {
            try
            {
                var anglers = await _anglerDAO.GetAnglersAsync();
                return  Ok(anglers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<Angler>> GetAsync(int Id)
        {
            try
            {
                var angler = await _anglerDAO.GetAnglerAsync(Id);
                if (angler == null)
                {
                    return NoContent();
                }

                return Ok(angler);
            }
            catch (Exception ex)
            {
                // This line is used for debugging.
                return StatusCode(500, $"Error: {ex.Message}");

                //return StatusCode(500, $"An error occurred trying to retrieve the angler with id {id}.");
            }
        }

    }
}