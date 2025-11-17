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
            var query = @"SELECT * FROM Booking WHERE Id = @Id";
            using var connection = CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<Booking>(query, new { Id = id });
        }

        public async Task<bool> DeleteBookingAsync(int id)
        {
            var sql = @"DELETE FROM Booking WHERE Id = @Id";

            using (var connection = CreateConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        await connection.ExecuteAsync(sql,
                            new
                            {
                                Id = id
                            },
                            transaction);

                        transaction.Commit();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        throw new Exception($"Error deleting booking with id {id}. Message was {ex.Message}");
                    }
                }
            }
        }
    }
}
