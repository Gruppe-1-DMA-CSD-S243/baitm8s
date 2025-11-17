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
        public string BookingNumber { get; set; }
        public string Pond { get; set; }
        public string TimeSlots { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int NumberOfPeople { get; set; }
        public int AnglerId { get; set; }
    }
}
