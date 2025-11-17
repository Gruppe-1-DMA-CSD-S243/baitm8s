using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.DAO
{
    public class BookingDAO : BaseDAO, IBookingDAO
    {
        public BookingDAO(string connectionString) : base(connectionString)
        {

        }
        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            var query = "SELECT * FROM Booking";
            using var connection = CreateConnection();
            return await connection.QueryAsync<Booking>(query);
        }

        public async Task<Booking?> GetBookingAsync(int id)
        {
            var query = "SELECT * FROM Booking WHERE id = @id";
            using var connection = CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<Booking>(query, new { Id = id });
        }
    }
}
