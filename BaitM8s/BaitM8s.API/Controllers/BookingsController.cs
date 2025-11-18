using BaitM8s.DAL.DTO;
using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.Model;
using BaitM8s.Services.Notifications.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaitM8s.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingDAO _bookingDAO;
        private readonly INotificationService _notificationService;
        public BookingsController(IBookingDAO bookingDAO, INotificationService notificationService)
        {
            _bookingDAO = bookingDAO;
            _notificationService = notificationService;
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
        public async Task<ActionResult<int>> CreateBookingAsync([FromBody] BookingDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                //TODO: Lav en hjælpemetode!!!
                Booking booking = new Booking
                {
                    Id = dto.Id,
                    BookingNumber = dto.BookingNumber,
                    Pond = dto.Pond,
                    TimeSlots = dto.TimeSlots,
                    Date = dto.Date,
                    StartTime = dto.StartTime,
                    EndTime = dto.EndTime,
                    NumberOfPeople = dto.NumberOfPeople,
                    FK_AnglerId = dto.FK_AnglerId
                };

                int newId = await _bookingDAO.CreateBookingAsync(booking);

                await _notificationService.SendNotificationAsync("hej");

                return Ok(newId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating booking: {ex.Message}");
            }
        }
    }
}
