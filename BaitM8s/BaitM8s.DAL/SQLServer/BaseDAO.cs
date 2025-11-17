using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.SQLServer
{
    public abstract class BaseDAO
    {
        public string ConnectionString { get; private set; }
        protected BaseDAO(string connectionString) => ConnectionString = connectionString;
        public IDbConnection CreateConnection() => new SqlConnection(ConnectionString);
    }
}
