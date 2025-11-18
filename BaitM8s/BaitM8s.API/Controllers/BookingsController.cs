using BaitM8s.DAL.DTO;
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
        public async Task<ActionResult<IEnumerable<BookingDTO>>> GetAsync()
        {
            try
            {
                return Ok(await _bookingDAO.GetAllBookingsAsync());
            }
            catch (Exception ex)
            {
                // This line is used for debugging.
                return StatusCode(500, $"Error: {ex.Message}");

                //return StatusCode(500, $"An error occurred trying to retrieve all bookings posts.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDTO>> GetAsync(int id)
        {
            try
            {
                return Ok(await _bookingDAO.GetBookingAsync(id));
            }
            catch (Exception ex)
            {
                // This line is used for debugging.
                return StatusCode(500, $"Error: {ex.Message}");

                //return StatusCode(500, $"An error occurred trying to retrieve the blog post with id {id}.");
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteBookingAsync(int id)
        {
            try
            {
                return Ok(await _bookingDAO.DeleteBookingAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500);
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

                return Ok(newId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating booking: {ex.Message}");
            }
        }
    }
}
