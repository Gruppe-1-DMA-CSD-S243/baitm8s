using BaitM8s.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.APIClient.Interfaces
{
    public interface IBookingAPIClient
    {
        Task<IEnumerable<BookingDTO>> GetAllAsync();
        Task<BookingDTO?> GetOneAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<int> CreateAsync(BookingDTO bookingDTO);
        Task<IDictionary<string, int>> GetBookedPeopleCountAsync(int fishingSpotId, int weekNumber, int year);
    }
}
