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

        public async Task<int> CreateBookingAsync(Booking booking)
        {
            var sql = @"INSERT INTO Booking (NumberOfPeople, Day, Month, Year, WeekNumber, StartTime, EndTime, FK_AnglerId, FK_FishingSpotId)
                      OUTPUT INSERTED.Id
                      VALUES (@NumberOfPeople, @Day, @Month, @Year, @WeekNumber, @StartTime, @EndTime, @FK_AnglerId, @FK_FishingSpotId);";
            using (var connection = CreateConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction(System.Data.IsolationLevel.Serializable))
                {
                    try
                    {
                        int capacity = await connection.QuerySingleAsync<int>(@"SELECT Capacity FROM FishingSpot WHERE Id = @FK_FishingSpotId;",
                            new
                            {
                                FK_FishingSpotId = booking.FK_FishingSpotId
                            }, 
                            transaction);

                        int slotsTaken = await connection.ExecuteScalarAsync<int>(@"SELECT SUM(NumberOfPeople) FROM Booking WHERE FK_FishingSpotId = @FK_FishingSpotId AND Day = @Day AND Month = @Month AND Year = @Year AND StartTime = @StartTime AND EndTime = @EndTime;",
                            new
                            {
                                FK_FishingSpotId = booking.FK_FishingSpotId,
                                Day = booking.Day,
                                Month = booking.Month,
                                Year = booking.Year,
                                StartTime = booking.StartTime,
                                EndTime = booking.EndTime
                            },
                            transaction);

                        if (slotsTaken + booking.NumberOfPeople > capacity)
                        {
                            throw new Exception($"Number of people exceeds the fishing spot's capacity!");
                        }

                        var newId = await connection.ExecuteScalarAsync<int>(sql,
                            new
                            {
                                booking.NumberOfPeople,
                                booking.Day,
                                booking.Month,
                                booking.Year,
                                booking.WeekNumber,
                                booking.StartTime,
                                booking.EndTime,
                                booking.FK_AnglerId,
                                booking.FK_FishingSpotId
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
