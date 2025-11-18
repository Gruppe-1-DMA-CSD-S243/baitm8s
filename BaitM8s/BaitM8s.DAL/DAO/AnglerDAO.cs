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

        public async Task<IEnumerable<Angler>> GetAnglersAsync()
        {
            var query = "SELECT * FROM Angler";
            using var connection = CreateConnection();
            return await connection.QueryAsync<Angler>(query);
        }

        public async Task<Angler?> GetAnglerAsync(int id)
        {
            var query = "SELECT * FROM Angler WHERE id = @id";
            using var connection = CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<Angler>(query, new { Id = id });
        }
    }
}
