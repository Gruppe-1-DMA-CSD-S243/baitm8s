using BaitM8s.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.DTO
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public string BookingNumber { get; set; }
        public string Pond { get; set; }
        public List<TimeSlot> TimeSlots { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int NumberOfPeople { get; set; }
    }
}
