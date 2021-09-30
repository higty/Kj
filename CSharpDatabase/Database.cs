using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CSharpDatabase
{
    public class Database
    {
        private SqlConnection _Connection = null;

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

            if (isOpen == false)
            {
                this.Open();
            }
            cm.Connection = _Connection;
            var affectedRecordCount = cm.ExecuteNonQuery();

            if (isOpen == false)
            {
                this.Close();
            }
            return affectedRecordCount;
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
    }
}
