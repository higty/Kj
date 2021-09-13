using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace CSharpDatabase 
{
    class Program
    {
        public static readonly String ConnectionString = File.ReadAllText("C:\\GitHub\\ConnectionString.txt");

        static void Main(string[] args)
        {
            var personList = CreatePersonList();

            var footballPlayerList = FilterPerson(personList, IsSportsFootball);
            var over30List = FilterPerson(personList, IsAgeOver30);

            Console.WriteLine("Press enter exit...");
            Console.ReadLine();
        }
        private static List<Person> CreatePersonList()
        {
            var l = new List<Person>();

            l.Add(new Person("Messi", 34, Gender.Man, "サッカー"));
            l.Add(new Person("C.Ronald", 38, Gender.Man, "サッカー"));
            l.Add(new Person("久保", 19, Gender.Man, "サッカー"));
            l.Add(new Person("R.Federer", 34, Gender.Man, "テニス"));
            l.Add(new Person("Nadal", 35, Gender.Man, "テニス"));
            l.Add(new Person("錦織", 32, Gender.Man, "テニス"));
            l.Add(new Person("ズベレフ", 23, Gender.Man, "テニス"));

            return l;
        }
        private static List<Person> FilterPerson(List<Person> personList, Func<Person, Boolean> filterFunc)
        {
            var newPersonList = new List<Person>();

            foreach (var item in personList)
            {
                if (filterFunc(item) == true)
                {
                    newPersonList.Add(item);
                }
            }
            return newPersonList;

        }
        private static Boolean IsSportsFootball(Person person)
        {
            return person.Sports == "サッカー";
        }
        private static Boolean IsAgeOver30(Person person)
        {
            return person.Age > 30;
        }


        private static void ExecuteInsertQuery()
        {
            var db = new Database(Program.ConnectionString);
            db.ExecuteNonQuery("insert into Payment values(NEWID(), '雪見大福', '2021-08-30', 160)", 120);
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
        private static SqlCommand CreateInsertCommand1()
        {
            var cm = new SqlCommand("insert into Payment(PaymentCD,Title,Date,Price) values(NEWID(), @Title, @Date, @Price)");

            {
                var p = new SqlParameter();
                p.ParameterName = "@Title";
                p.SqlDbType = SqlDbType.NVarChar;
                p.Size = 100;
                p.Value = "マヌカ蜜";
                cm.Parameters.Add(p);
            }
            {
                var p = new SqlParameter();
                p.ParameterName = "@Date";
                p.SqlDbType = SqlDbType.Date;
                p.Value = "2021-09-07";
                cm.Parameters.Add(p);
            }
            {
                var p = new SqlParameter();
                p.ParameterName = "@Price";
                p.SqlDbType = SqlDbType.Int;
                p.Value = "4000";
                cm.Parameters.Add(p);
            }

            return cm;
        }
        private static SqlCommand CreateInsertCommand2()
        {
            var cm = new SqlCommand("insert into Payment(PaymentCD,Title,Date,Price) values(NEWID(), @Title, @Date, @Price)");

            {
                var p = cm.Parameters.Add("@Title", SqlDbType.NVarChar, 100);
                p.Value = "レーズンパン（3斤）";
            }
            {
                var p = cm.Parameters.Add("@Date", SqlDbType.Date);
                p.Value = "2021-09-07";
            }
            {
                var p = cm.Parameters.Add("@Title", SqlDbType.Int);
                p.Value = "200";
            }
            return cm;
        }
        private static SqlCommand CreateInsertCommand3()
        {
            var cm = new SqlCommand("insert into Payment(PaymentCD,Title,Date,Price) values(NEWID(), @Title, @Date, @Price)");

            cm.AddParameter("@Title", SqlDbType.NVarChar, 100, "チョコポッキー");
            cm.AddParameter("@Date", SqlDbType.Date, "2021-08-30");
            cm.AddParameter("@Price", SqlDbType.Int, "210");

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
