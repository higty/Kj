using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.IO;

namespace CSharpDatabase 
{
    class Program
    {
        public static readonly String ConnectionString = File.ReadAllText("C:\\GitHub\\ConnectionString.txt");

        static void Main(string[] args)
        {
            ExecuteInsertCommand();

            Console.WriteLine("Press enter exit...");
            Console.ReadLine();
        }
        private static void ExecuteInsertQuery()
        {
            var db = new Database(Program.ConnectionString);
            db.ExecuteNonQuery("insert into Payment values(NEWID(), '雪見大福', '2021-08-30', 160)");
        }
        private static void ExecuteInsertCommand()
        {
            var db = new Database(Program.ConnectionString);
            var cm = CreateInsertCommand();
            db.ExecuteNonQuery(cm);
        }
        private static SqlCommand CreateInsertCommand()
        {
            var cm = new SqlCommand("insert into Payment(PaymentCD,Title,Date,Price) values(NEWID(), @Title, @Date, @Price)");

            cm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100) { Value = "チョコポッキー" });
            cm.Parameters.Add(new SqlParameter("@Date", SqlDbType.Date) { Value = "2021-08-30" });
            cm.Parameters.Add(new SqlParameter("@Price", SqlDbType.Int) { Value = "210" });

            return cm;
        }

        public async void Button1_Click(object sender, EventArgs e)
        {
            var db = new Database(Program.ConnectionString);
            var cm = CreateInsertCommand();
            var x = await db.ExecuteNonQueryAsync(cm);

            //MessageBox.Show("");
        }
    }
}
