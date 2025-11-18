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
        public ActionResult<IEnumerable<Booking>> GetAllBookings()
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

        [HttpGet("{Id}")]
        public ActionResult<Booking> GetBookingById(int Id)
        {
            try
            {
                var booking = _bookingDAO.GetBooking(Id);
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

        [HttpPost]
        public async Task<ActionResult<int>> CreateBookingAsync([FromBody] Booking booking)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                int newId = await _bookingDAO.CreateBookingAsync(booking);

                // Returnerer HTTP 201 + Location header
                return CreatedAtAction(nameof(GetBookingById), new { Id = newId }, newId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating booking: {ex.Message}");
            }
        }

    }
}
