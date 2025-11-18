using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.Model
{
    public class TimeSlot
    {
        //TODO: Change variable name for timeslot number
        public string TimeSlotNumber { get; set; }
        public int WeekNumber { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAvaliable { get; set; }
        public int Capacity { get; set; }
    }
}
