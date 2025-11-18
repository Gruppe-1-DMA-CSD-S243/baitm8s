using BaitM8s.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.Interfaces
{
    public interface ITimeSlotsDAO
    {
        TimeSlot? GetOne(string phoneNumber);
        IEnumerable<TimeSlot> GetAll();
        IEnumerable<TimeSlot> GetByPondOwner(int pondOwnerId);
        bool Delete(int id);
        bool Update(TimeSlot putAndTakePond);
        int Create(TimeSlot putAndTakePond);
    }
}
