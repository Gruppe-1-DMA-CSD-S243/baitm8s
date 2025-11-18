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
    public class TimeSlotDAO : BaseDAO, ITimeSlotsDAO
    {
        public TimeSlotDAO(string connectionString) : base(connectionString)
        {
        }

        public int Create(TimeSlot timeSlot)
        {
            //TODO: move to database with default value for CreationDate
            
            var query = @"INSERT INTO Timeslots (timeslot_number, address, FK_pond_id, StartTime, EndTime)
                      OUTPUT INSERTED.id
                      VALUES (@TimeSlotNumber, @Address, @FK_pond_id, @StartTime, @EndTime);";
            using var connection = CreateConnection();
            return connection.QuerySingle<int>(query, new { timeSlot.TimeSlotNumber, timeSlot.Address, timeSlot.FK_pond_id, timeSlot.StartTime, timeSlot.EndTime });
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TimeSlot> GetAll()
        {
            //TODO: update query, this is just temp for testing
            var query = "SELECT *, timeslot_number AS TimeSlotNumber FROM Timeslots";
            using var connection = CreateConnection();
            return connection.Query<TimeSlot>(query).ToList();
        }

        public IEnumerable<TimeSlot> GetByPondOwner(int pondOwnerId)
        {
            throw new NotImplementedException();
        }

        public TimeSlot? GetOne(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public bool Update(TimeSlot putAndTakePond)
        {
            throw new NotImplementedException();
        }
    }
}
