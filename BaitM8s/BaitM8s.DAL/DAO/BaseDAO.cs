using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.DAO
{
    public abstract class BaseDAO
    {
        protected readonly string _connectionString;
        protected BaseDAO(string connectionString) => _connectionString = connectionString;
        protected IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
