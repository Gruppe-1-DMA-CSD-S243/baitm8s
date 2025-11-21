using BaitM8s.API.Mappings.Interfaces;
using BaitM8s.DAL.DTO;
using BaitM8s.DAL.Model;

namespace BaitM8s.API.Mappings
{
    public class BookingMapper : IBookingMapper
    {
        public Booking ToModel(BookingDTO dto)
        {
            Booking booking = new Booking
            {
                Id = dto.Id,
                NumberOfPeople = dto.NumberOfPeople,
                Day = dto.Day,
                Month = dto.Month,
                Year = dto.Year,
                WeekNumber = dto.WeekNumber,
                FK_AnglerId = dto.FK_AnglerId,
                FK_FishingSpotId = dto.FK_FishingSpotId
            };

            return booking;
        }
    }
}
