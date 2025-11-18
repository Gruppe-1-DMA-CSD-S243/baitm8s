using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.SQLServer
{
    public class TimeSlotDAO : BaseDAO, ITimeSlotsDAO
    {
        public TimeSlotDAO(string connectionString) : base(connectionString)
        {
        }

        public int Create(TimeSlot putAndTakePond)
        {
            throw new NotImplementedException();
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
