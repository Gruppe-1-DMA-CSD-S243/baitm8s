using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.DTO
{
    public class TimeSlotDTO
    {
        public int Id { get; set; }
        public string TimeSlotNumber { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAvailable { get; set; }
        public int Capacity { get; set; }
        public int FK_PutAndTakePondId { get; set; }
    }
}
