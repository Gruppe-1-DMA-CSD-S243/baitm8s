using BaitM8s.API.Mappings.Interfaces;
using BaitM8s.DAL.DTO;
using BaitM8s.DAL.Model;
using System.Globalization;

namespace BaitM8s.API.Mappings
{
    public class BookingMapper : IBookingMapper
    {
        public Booking ToModel(BookingDTO dto)
        {
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            DateTime date = new DateTime(dto.Year, dto.Month, dto.Day);

            Booking booking = new Booking
            {
                Id = dto.Id,
                NumberOfPeople = dto.NumberOfPeople,
                Day = dto.Day,
                Month = dto.Month,
                Year = dto.Year,
                WeekNumber = cultureInfo.Calendar.GetWeekOfYear(date,
                    cultureInfo.DateTimeFormat.CalendarWeekRule,
                    cultureInfo.DateTimeFormat.FirstDayOfWeek),
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                FK_AnglerId = dto.FK_AnglerId,
                FK_FishingSpotId = dto.FK_FishingSpotId
            };

            return booking;
        }
    }
}
