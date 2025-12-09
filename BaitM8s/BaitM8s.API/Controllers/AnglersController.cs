using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.Model;
using BaitM8s.DAL.DTO;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnglerDTO>>> GetAsync()
        {
            try
            {
                return Ok(await _anglerDAO.GetAnglersAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while trying to retrieve all anglers.");
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<AnglerDTO>> GetAsync(int id)
        {
            try
            {
                Angler angler = await _anglerDAO.GetAnglerAsync(id);
                if (angler == null)
                {
                    return NoContent();
                }

                return Ok(angler);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred trying to retrieve the angler with id {id}.");
            }
        }

    }
}