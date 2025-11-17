using BaitM8s.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.Interfaces
{
    public interface ITimeSlotDAO
    {
        Task<IEnumerable<TimeSlot>> GetAllTimeSlotsAsync();
        Task<IEnumerable<TimeSlot>> GetAllTimeSlotsForPutAndTakePondAsync(int putAndTakePondId);
    }
}
