using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using static Dapper.SqlMapper;

namespace BaitM8s.DAL.SQLServer
{
    public class PutAndTakePondDAO : BaseDAO, IPutAndTakePondDAO
    {
        public PutAndTakePondDAO(string connectionString) : base(connectionString)
        {
        }

        public int Create(PutAndTakePond putAndTakePond)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PutAndTakePond> GetAll()
        {
            //TODO: update query, this is just temp for testing
            var query = "SELECT *, phone_number AS PhoneNumber FROM PutAndTakePonds";
            using var connection = CreateConnection();
            return connection.Query<PutAndTakePond>(query).ToList();
        }

        public IEnumerable<PutAndTakePond> GetByPondOwner(int pondOwnerId)
        {
            throw new NotImplementedException();
        }

        public PutAndTakePond? GetOne(string phoneNumber)
        {
            var query = "SELECT name, address, zipcode, email, phone_number AS PhoneNumber FROM PutAndTakePonds WHERE phone_number = @phone_number";
            using var connection = CreateConnection();
            return connection.QuerySingleOrDefault<PutAndTakePond>(query, new { phone_number = phoneNumber });
        }

        public bool Update(PutAndTakePond putAndTakePond)
        {
            throw new NotImplementedException();
        }
    }
}
