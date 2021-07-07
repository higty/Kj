using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace AdvancedConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            CallStoredProcedure();
        }
        static void CallParameterizeQuery()
        {
            var cn = new SqlConnection("Connection String....");
            var sql = "update GpsTable set DisplayName = '@DisplayName' where CD = '@CD'";
            var cm = new SqlCommand(sql);

            cm.Parameters.Add(CreateParameter(cm, "@DisplayName", SqlDbType.NChar
                , ParameterDirection.Input, "GPS Marker1"));
            cm.Parameters.Add(CreateParameter(cm, "@CD", SqlDbType.UniqueIdentifier
                , ParameterDirection.Input, Guid.NewGuid()));

            //{
            //    SqlParameter p = cm.CreateParameter();
            //    p.ParameterName = "@DisplayName";
            //    p.SqlDbType = SqlDbType.NChar;
            //    p.Direction = ParameterDirection.Input;
            //    p.Value = "GPS marker1";
            //    cm.Parameters.Add(p);
            //}
            //{
            //    SqlParameter p = cm.CreateParameter();
            //    p.ParameterName = "@DisplayName";
            //    p.SqlDbType = SqlDbType.NChar;
            //    p.Direction = ParameterDirection.Input;
            //    p.Value = "GPS marker1";
            //    cm.Parameters.Add(p);

            //}

        }
        static SqlParameter CreateParameter(SqlCommand command, String  name
            , SqlDbType type, ParameterDirection direction, object value)
        {
            SqlParameter p = command.CreateParameter();
            p.ParameterName = name;
            p.SqlDbType = type;
            p.Direction = direction;
            p.Value = value;
            return p;
        }
        static void CallStoredProcedure()
        {
            var connectionString = System.IO.File.ReadAllText("C:\\GitHub\\ConnectionString.txt");
            var cn = new SqlConnection(connectionString);
            var cm = new SqlCommand("Kj_Payment_SelectBy_Date");
            cm.CommandText = "Kj_Payment_SelectBy_Date";
            cm.CommandType = System.Data.CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@Date", new DateTime(2021, 6, 30));
            cm.Connection = cn;
            cn.Open();
            var dr = cm.ExecuteReader();
            while (dr.Read())
            {
                var title = dr["Title"].ToString();
                Console.WriteLine(title);
            }
            Console.ReadLine();
        }
        static void SampleSqlInjection()
        {
            var sql = String.Format("update GpsTable set DisplayName = '{0}' where CD = '{1}'"
                , "DummyName';Drop Table GpsTable;--;", "123");
            Console.WriteLine(sql);
            Console.ReadLine();
        }
    }
}
