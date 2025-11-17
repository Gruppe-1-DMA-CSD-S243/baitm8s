using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.Model
{
    public class TimeSlot
    {
        public int TimeSlotNumber { get; set; }
        public int WeekNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsAvaliable { get; set; }
        public int Capacity { get; set; }

        public TimeSlot(int timeSlotNumber, int weekNumber, DateTime startDate, DateTime endDate, bool isAvaliable, int capacity)
        {
            TimeSlotNumber = timeSlotNumber;
            WeekNumber = weekNumber;
            StartDate = startDate;
            EndDate = endDate;
            IsAvaliable = isAvaliable;
            Capacity = capacity;
        }

        public TimeSlot()
        {
        }
    }
}
