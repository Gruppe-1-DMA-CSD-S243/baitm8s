using BaitM8s.DAL.DTO;
using BaitM8s.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaitM8s.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotsController : ControllerBase
    {
        private readonly ITimeSlotDAO _timeSlotDAO;

        public TimeSlotsController(ITimeSlotDAO timeSlotDAO)
        {
            _timeSlotDAO = timeSlotDAO;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeSlotDTO>>> GetAsync()
        {
            try
            {
                return Ok(await _timeSlotDAO.GetAllTimeSlotsAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeSlotDTO>>> GetByPondIdAsync(int pondId)
        {

        }
    }
}
