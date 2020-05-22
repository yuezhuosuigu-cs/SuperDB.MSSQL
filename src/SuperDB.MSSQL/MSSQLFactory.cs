using SuperDB.Config;
using System.Data;
using System.Data.SqlClient;

namespace SuperDB.MSSQL
{
    public class MSSQLFactory : DBFactory
    {
        private IDbConnection _Connection;

        public static MSSQLFactory Create()
        {
            return new MSSQLFactory();
        }

        public override IDbConnection Connection
        {
            get
            {
                if (_Connection == default)
                {
                    _Connection = new SqlConnection(DBConfig.ConnectionString);
                }
                if (_Connection.State != ConnectionState.Open)
                {
                    _Connection.Open();
                }
                return _Connection;
            }
        }
    }
}
