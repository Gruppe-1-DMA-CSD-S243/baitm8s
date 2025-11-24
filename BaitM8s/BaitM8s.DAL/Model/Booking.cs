using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public string? BookingNumber { get; set; }
        public string? Pond { get; set; }
        //TODO: Fucker med den nuværende løsning på View All Bookings i kalenderen!
        public List<TimeSlot>? TimeSlots { get; set; }
        public DateTime Date { get; set; }
        public string Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int NumberOfPeople { get; set; }
        public int FK_AnglerId { get; set; }
        public int FK_FishingSpotId { get; set; }
        public string Month { get; set; }
        public int WeekNumber { get; set; }
        public int Year { get; set; }
    }
}
