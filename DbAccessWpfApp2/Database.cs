using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DbAccessWpfApp2
{
    public class Database
    {
        public String ConnectionString { get; set; }

        public void ExecuteNonQuery(String query)
        {
            using (var cn = new SqlConnection(this.ConnectionString))
            {
                var cm = new SqlCommand(query);
                cm.Connection = cn;
                cn.Open();
                var o = cm.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}
