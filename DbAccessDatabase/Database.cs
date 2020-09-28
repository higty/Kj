using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DbAccessDatabase
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
        public List<PaymentRecord> SelectPaymentRecords()
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
                    r.Price = (Int32)dr["Price"];
                    l.Add(r);
                }
                cn.Close();
            }
            return l;
        }

        public Boolean Insert(PaymentRecord record)
        {
            //DBにレコードをInsertする処理を書く
            using (var cn = new SqlConnection(this.ConnectionString))
            {
                var sql = String.Format("insert into Payment values(NEWID(), '{0}', '{1}', {2})"
                    , record.Title, record.Date, record.Price);
                var cm = new SqlCommand(sql);
                cm.Connection = cn;
                cn.Open();

                cm.ExecuteNonQuery();
                cn.Close();
            }

            return true;
        }
    }
}
