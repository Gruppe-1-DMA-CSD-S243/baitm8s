using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

        public Booking? GetBooking(int Id)
        {
            var query = "SELECT * FROM Booking WHERE id = @id";
            using var connection = CreateConnection();
            return connection.QuerySingleOrDefault<Booking>(query, new { Id = Id });
        }

        public async Task<int> CreateBookingAsync(Booking booking)
        {
            var sql = @"INSERT INTO Booking (BookingNumber, Pond, TimeSlots, Date, StartTime, EndTime, NumberOfPeople, FK_AnglerId)
                      OUTPUT INSERTED.Id
                      VALUES (@BookingNumber, @Pond, @TimeSlots, @Date, @StartTime, @EndTime, @NumberOfPeople, @FK_AnglerId);";
            using (var connection = CreateConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var newId = await connection.ExecuteScalarAsync<int>(sql,
                            new
                            {
                                    booking.BookingNumber,
                                    booking.Pond,
                                    booking.TimeSlots,
                                    booking.Date,
                                    booking.StartTime,
                                    booking.EndTime,
                                    booking.NumberOfPeople,
                                    booking.FK_AnglerId
                                },
                                transaction);

                        transaction.Commit();

                        return newId;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Error creating booking with id {booking.Id}. Message was {ex.Message}");
                    }
                }
            }
        }
    }
}
