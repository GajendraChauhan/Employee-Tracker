using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccess
{
    public class ConnectionManager: IDisposable
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["EmpDB"].ConnectionString;
        private SqlConnection _connection;

        public ConnectionManager()
        {
            this._connection = new SqlConnection(ConnectionString);
            this._connection.Open();
        }

        public SqlConnection GetConnection()
        {
            return this._connection;
        }

        public void Dispose()
        {
            this._connection.Close();
        }
    }
}
