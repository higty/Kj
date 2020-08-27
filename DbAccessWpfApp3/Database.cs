using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DbAccessWpfApp3
{
    public class Database
    {
        public String ConnectionString { get; set; }

        public List<String> SelectTitleList()
        {
            var l = new List<String>();

            using (var cn = new SqlConnection(this.ConnectionString))
            {
                var cm = new SqlCommand("select * from Payment");
                cm.Connection = cn;
                cn.Open();

                var dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    l.Add(dr["Title"].ToString());
                }
                cn.Close();
            }
            return l;
        }
        public List<PaymentRecord> SelectPaymentRecordList()
        {
            var l = new List<PaymentRecord>();

            using (var cn = new SqlConnection(this.ConnectionString))
            {
                var cm = new SqlCommand("select * from Payment");
                cm.Connection = cn;
                cn.Open();

                var dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    var r = new PaymentRecord();
                    r.Title = dr["Title"].ToString();
                    r.Date = (DateTime)dr["Date"];
                    l.Add(r);
                }
                cn.Close();
            }
            return l;
        }
    }
}
