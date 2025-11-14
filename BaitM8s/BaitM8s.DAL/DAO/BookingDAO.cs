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
        public IEnumerable<Booking> GetAllBookings()
        {
            var query = "SELECT * FROM Booking";
            using var connection = CreateConnection();
            return connection.Query<Booking>(query).ToList();
        }

        public Booking? GetBooking(int id)
        {
            var query = "SELECT * FROM Booking WHERE id = @id";
            using var connection = CreateConnection();
            return connection.QuerySingleOrDefault<Booking>(query, new { Id = id });
        }
    }
}
