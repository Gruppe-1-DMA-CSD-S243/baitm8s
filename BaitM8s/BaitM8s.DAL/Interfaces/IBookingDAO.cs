using BaitM8s.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.Interfaces
{
    public interface IBookingDAO
    {
        Task<Booking?> GetBookingAsync(int id);
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task<bool> DeleteBookingAsync(int id);
        Task<int> CreateBookingAsync(Booking booking);
    }
}
