using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaitM8s.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingDAO _bookingDAO;

        public BookingsController(IBookingDAO bookingDAO)
        {
            _bookingDAO = bookingDAO;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Booking>> Get()
        {
            try
            {
                return Ok(_bookingDAO.GetAllBookings());
            }
            catch (Exception ex)
            {
                // This line is used for debugging.
                return StatusCode(500, $"Error: {ex.Message}");

                //return StatusCode(500, $"An error occurred trying to retrieve all bookings posts.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Booking> Get(int id)
        {
            try
            {
                var booking = _bookingDAO.GetBooking(id);
                if (booking == null)
                {
                    return NoContent();
                }

                return Ok(booking);
            }
            catch (Exception ex)
            {
                // This line is used for debugging.
                return StatusCode(500, $"Error: {ex.Message}");

                //return StatusCode(500, $"An error occurred trying to retrieve the blog post with id {id}.");
            }
        }
    }
}
