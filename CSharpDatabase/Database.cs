using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CSharpDatabase
{
    public class Database : IDisposable
    {
        private SqlConnection _Connection = null;
        private SqlTransaction _Transaction = null;

        public String ConnectionString { get; init; } = "";

        public Database(String connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public void Open()
        {
            if (_Connection == null)
            {
                _Connection = new SqlConnection(this.ConnectionString);
            }
            _Connection.Open();
        }   
        public void Close()
        {
            if (_Connection != null)
            {
                _Connection.Close();
                _Connection = null;
            }
        }
        private Boolean IsOpen()
        {
            return _Connection != null;
        }

        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            _Transaction = _Connection.BeginTransaction(isolationLevel);
        }
        public void CommitTransaction()
        {
            _Transaction.Commit();
        }
        public void RollbackTransaction()
        {
            _Transaction.Rollback();
        }

        public Int32 ExecuteNonQuery(String query)
        {
            var cm = new SqlCommand(query);
            return this.ExecuteNonQuery(cm);
        }
        public Int32 ExecuteNonQuery(String query, Int32 commandTimeout)
        {
            var cm = new SqlCommand(query);
            cm.CommandTimeout = commandTimeout;
            return this.ExecuteNonQuery(cm);
        }
        public Int32 ExecuteNonQuery(SqlCommand command)
        {
            var cm = command;
            var isOpen = this.IsOpen();

            try
            {
                if (isOpen == false)
                {
                    this.Open();
                }
                cm.Connection = _Connection;
                cm.Transaction = _Transaction;
                var affectedRecordCount = cm.ExecuteNonQuery();

                return affectedRecordCount;
            }
            finally
            {
                if (isOpen == false)
                {
                    this.Close();
                }
            }
        }
        public async Task<Int32> ExecuteNonQueryAsync(String query)
        {
            var cm = new SqlCommand(query);
            return await this.ExecuteNonQueryAsync(cm);
        }
        public async Task<Int32> ExecuteNonQueryAsync(SqlCommand command)
        {
            var cm = command;

            using (var cn = new SqlConnection(this.ConnectionString))
            {
                cm.Connection = cn;
                cn.Open();
                var affectedRecordCount = await cm.ExecuteNonQueryAsync();
                cn.Close();
                return affectedRecordCount;
            }
        }

        public void Dispose()
        {
            this.Close();
        }
    }
}
