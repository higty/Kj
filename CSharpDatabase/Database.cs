using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CSharpDatabase
{
    public class Database
    {
        public String ConnectionString { get; init; } = "";

        public Database(String connectionString)
        {
            this.ConnectionString = connectionString;
        }
   
        public Int32 ExecuteNonQuery(String query)
        {
            using (var cn = new SqlConnection(this.ConnectionString))
            {
                var cm = new SqlCommand(query);
                cm.Connection = cn;
                cn.Open();
                var affectedRecordCount = cm.ExecuteNonQuery();
                cn.Close();
                return affectedRecordCount;
            }
        }
        public Int32 ExecuteNonQuery(SqlCommand command)
        {
            var cm = command;

            using (var cn = new SqlConnection(this.ConnectionString))
            {
                cm.Connection = cn;
                cn.Open();
                var affectedRecordCount = cm.ExecuteNonQuery();
                cn.Close();
                return affectedRecordCount;
            }
        }
        public async Task<Int32> ExecuteNonQueryAsync(String query)
        {
            using (var cn = new SqlConnection(this.ConnectionString))
            {
                var cm = new SqlCommand(query);
                cm.Connection = cn;
                cn.Open();
                var affectedRecordCount = await cm.ExecuteNonQueryAsync();
                cn.Close();
                return affectedRecordCount;
            }
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
