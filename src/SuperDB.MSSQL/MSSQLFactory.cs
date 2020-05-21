using SuperDB.Config;
using System.Data;
using System.Data.SqlClient;

namespace SuperDB.MSSQL
{
    public class MSSQLFactory : IDBFactory
    {
        private IDbConnection _Connection;
        private IDbTransaction _Transaction;

        public static MSSQLFactory Create()
        {
            return new MSSQLFactory();
        }

        public IDbConnection Connection
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

        public IDbTransaction Transaction
        {
            get
            {
                if (_Transaction == default)
                {
                    _Transaction = Connection.BeginTransaction();
                }
                return _Transaction;
            }
        }

        public bool Commit()
        {
            Transaction.Commit();
            return true;
        }

        public void Dispose()
        {
            _Connection?.Dispose();
            _Connection = default;
            _Transaction = default;
        }

        public bool Rollback()
        {
            Transaction.Rollback();
            return false;
        }
    }
}
