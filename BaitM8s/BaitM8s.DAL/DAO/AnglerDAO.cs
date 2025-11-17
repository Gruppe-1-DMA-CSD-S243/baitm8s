using BaitM8s.DAL.Interface;
using BaitM8s.DAL.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.DAO
{
    public class AnglerDAO : BaseDAO, IAnglerDAO
    {
        public AnglerDAO(string connectionString) : base(connectionString) { }

        public IEnumerable<Angler> GetAnglers()
        {
            var query = "SELECT * FROM Angler";
            using var connection = CreateConnection();
            return connection.Query<Angler>(query);
        }

        public Angler? GetAngler(int id)
        {
            var query = "SELECT * FROM Angler WHERE id = @id";
            using var connection = CreateConnection();
            return connection.QuerySingleOrDefault<Angler>(query, new { Id = id });
        }
    }
}
