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
            var query = "SELECT * FROM PutAndTakePonds";
            using var connection = CreateConnection();
            return connection.Query<PutAndTakePond>(query).ToList();
        }

        public IEnumerable<PutAndTakePond> GetByPondOwner(int pondOwnerId)
        {
            throw new NotImplementedException();
        }

        public PutAndTakePond? GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(PutAndTakePond putAndTakePond)
        {
            throw new NotImplementedException();
        }
    }
}
