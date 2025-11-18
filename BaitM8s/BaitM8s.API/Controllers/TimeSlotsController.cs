using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.Model;
using BaitM8s.DAL.SQLServer;
using Microsoft.AspNetCore.Mvc;

namespace BaitM8s.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeSlotsController : Controller
    {
        ITimeSlotsDAO _timeSlotsDAO;
        public TimeSlotsController(ITimeSlotsDAO timeSlotsDAO)
        {
            _timeSlotsDAO = timeSlotsDAO;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<TimeSlot>> Get()
        {
            try
            {
                return Ok(_timeSlotsDAO.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred trying to retrieve all blog posts.");
            }
        }
    }
}
