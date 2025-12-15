using BaitM8s.API.Mappings.Interfaces;
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
        private readonly IBookingMapper _bookingMapper;
        public BookingsController(IBookingDAO bookingDAO, INotificationService notificationService, IBookingMapper bookingMapper)
        {
            _bookingDAO = bookingDAO;
            _notificationService = notificationService;
            _bookingMapper = bookingMapper;
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
                return StatusCode(500, $"An error occurred trying to retrieve all bookings.");
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
                return StatusCode(500, $"An error occurred trying to retrieve the booking with id {id}.");
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
                Booking booking = _bookingMapper.ToModel(dto);

                int newId = await _bookingDAO.CreateBookingAsync(booking);

                await _notificationService.SendNotificationAsync($"Tak for din booking! Du har nu en reserveret tid ved fiskespot {dto.FK_FishingSpotId} den {dto.Day}/{dto.Month} kl. {dto.StartTime}."); 

                return Ok(newId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while trying to create a booking.");
            }
        }

        [HttpGet("booked-people-count")]
        public async Task<ActionResult<IDictionary<string, int>>> GetBookedPeopleCountAsync(int fishingSpotId = 1, int weekNumber = 48, int year = 2025)
        {
            try
            {
                return Ok(await _bookingDAO.GetBookedPeopleCountAsync(fishingSpotId, weekNumber, year));
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
