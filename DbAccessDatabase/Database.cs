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
                    r.PaymentCD = (Guid)dr["PaymentCD"];
                    r.Title = dr["Title"].ToString();
                    r.Date = (DateTime)dr["Date"];
                    r.Price = (Int32)dr["Price"];
                    l.Add(r);
                }
                cn.Close();
            }
            return l;
        }
        public PaymentRecord SelectByPrimaryKey(Guid paymentCD)
        {
            using (var cn = new SqlConnection(this.ConnectionString))
            {
                var sql = String.Format("select * from Payment where PaymentCD = '{0}'", paymentCD);
                var cm = new SqlCommand(sql);
                cm.Connection = cn;
                cn.Open();

                var dr = cm.ExecuteReader();
                PaymentRecord r = null;
                while (dr.Read())
                {
                    r = new PaymentRecord();
                    r.PaymentCD = (Guid)dr["PaymentCD"];
                    r.Title = dr["Title"].ToString();
                    r.Date = (DateTime)dr["Date"];
                    r.Price = (Int32)dr["Price"];
                    break;
                }
                cn.Close();

                return r;
            }
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
        public Boolean Update(PaymentRecord record)
        {
            //DBにレコードをUpdateする処理を書く
            using (var cn = new SqlConnection(this.ConnectionString))
            {
                var sql = String.Format("update Payment set Title='{1}',Date='{2}',Price={3}"
                    + " where PaymentCD='{0}'"
                    , record.PaymentCD, record.Title, record.Date, record.Price);
                var cm = new SqlCommand(sql);
                cm.Connection = cn;
                cn.Open();

                cm.ExecuteNonQuery();
                cn.Close();
            }

            return true;
        }
        public Boolean Delete(Guid paymentCD)
        {
            //DBにレコードをDeleteする処理を書く
            using (var cn = new SqlConnection(this.ConnectionString))
            {
                var sql = String.Format("delete Payment where PaymentCD='{0}'", paymentCD);
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
