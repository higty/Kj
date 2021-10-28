using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace CSharpDatabase 
{
    public delegate void NoReturnValueMethodDelegate(string name, Int32 age);
    public delegate Boolean Method1Delegate(string name);

    class Program
    {
        public static readonly String ConnectionString = File.ReadAllText("C:\\GitHub\\ConnectionString.txt");
        private static Func<Person, Boolean> myFilter1;

        static void Main(string[] args)
        {
            ListPersonNameList();

        }

        private static void Action_Func()
        {
            Action md1 = ExecuteInsertQuery;
            Func<String, Boolean> f1 = Method1;
            Action<String, Int32> md3 = Method2;

            md1();
        }
        private static void DelegateSample()
        {
            Method1Delegate md1 = Method1;
            NoReturnValueMethodDelegate md2 = Method2;
        }
        private static Boolean Method1(string name)
        {
            return true;
        }
        private static void Method2(string name, Int32 age)
        {
        }
        private static void FilterPersonTest()
        {
            var personList = CreatePersonList();

            var footballPlayerList = FilterPerson(personList, IsSportsFootball);
            var over30List = FilterPerson(personList, IsAgeOver30);
            var over25List = FilterPerson(personList, IsAgeOver25);

            //ラムダ式。名前が不要。定義した場所で使用されるので別でメソッドを定義するよりも可読性が高い。
            //使い捨て用途。
            var over27List = FilterPerson(personList, p =>
            {
                return p.Age > 27;
            });
            var over27List0 = FilterPerson(personList, (Person p) =>
            {
                return p.Age > 27;
            });
            var over27List1 = FilterPerson(personList, p => p.Age > 27);
            var over22List = FilterPerson(personList, p => p.Age > 22);

            Program.myFilter1 = p => p.Age > 21 && (p.Sports == "サッカー" || p.Sports == "テニス");

            //パフォーマンスはほぼ同じ。
            var list1 = FilterPerson(personList, p => p.Age > 20 && p.Sports == "サッカー");
            var list2 = FilterPerson(personList, myFilter1);
            var list3 = FilterPerson(personList, IsAgeOver21_Soccer_Tennis);

            //変数束縛で裏でクラスが生成されているのでほんの少しメモリを消費する。
            var age = 25;
            var list4 = FilterPerson(personList, p => p.Age > age);
        }
        private static void ListPersonNameList()
        {
            var personList = CreatePersonList();

            var filterPersonList = FilterPerson(personList, p => p.Age > 22);
            {
                var l = Select(filterPersonList, p =>
                {
                    var r = new PersonName();
                    r.Name = p.Name;
                    return r;
                });
                var json = JsonConvert.SerializeObject(l, Formatting.Indented);
                Console.WriteLine(json);
            }
            {
                var l = Select(filterPersonList, p =>
                {
                    var r = new PersonNameAge();
                    r.Name = p.Name;
                    r.Age = p.Age;
                    return r;
                });
                var json = JsonConvert.SerializeObject(l, Formatting.Indented);
                Console.WriteLine(json);
            }
            {
                var l = Select(filterPersonList, p =>
                {
                    var r = new PersonNameAddress();
                    r.Name = p.Name;
                    r.Address = p.Address;
                    return r;
                });
                var json = JsonConvert.SerializeObject(l, Formatting.Indented);
                Console.WriteLine(json);
            }
            Console.WriteLine(JsonConvert.SerializeObject(filterPersonList, Formatting.Indented));

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

        private static List<T> Select<T>(List<Person> personList, Func<Person, T> selectFunc)
            where T: new()
        {
            var l = new List<T>();
            foreach (var item in personList)
            {
                var r = selectFunc(item);
                l.Add(r);
            }
            return l;
        }
        private static List<PersonName> ConvertToPersonName(List<Person> personList)
        {
            var l = new List<PersonName>();
            foreach (var item in personList)
            {
                var r = new PersonName();
                r.Name = item.Name;
                l.Add(r);
            }
            return l;
        }
        private static List<PersonNameAge> ConvertToPersonNameAge(List<Person> personList)
        {
            var l = new List<PersonNameAge>();
            foreach (var item in personList)
            {
                var r = new PersonNameAge();
                r.Name = item.Name;
                r.Age = item.Age;
                l.Add(r);
            }
            return l;
        }
        private static List<PersonNameAddress> ConvertToPersonNameAddress(List<Person> personList)
        {
            var l = new List<PersonNameAddress>();
            foreach (var item in personList)
            {
                var r = new PersonNameAddress();
                r.Name = item.Name;
                r.Address = item.Address;
                l.Add(r);
            }
            return l;
        }

        private static Boolean IsSportsFootball(Person person)
        {
            return person.Sports == "サッカー";
        }
        private static Boolean IsAgeOver30(Person person)
        {
            return person.Age > 30;
        }
        private static Boolean IsAgeOver25(Person person)
        {
            return person.Age > 25;
        }
        private static Boolean IsAgeOver21_Soccer_Tennis(Person person)
        {
            return person.Age > 21 && (person.Sports == "サッカー" || person.Sports == "テニス");
        }


        private static void ExecuteInsertQueryWithTransaction()
        {
            using (var db = new Database(Program.ConnectionString))
            {
                try
                {
                    db.Open();
                    db.BeginTransaction(IsolationLevel.ReadCommitted);
                    db.ExecuteNonQuery("insertinto Payment values(NEWID(), 'バターフィナンシェ', '2021-09-30', 560)");
                    db.ExecuteNonQuery("insertinto Payment values(NEWID(), 'がりがり君', '2021-09-30', 100)");

                    db.CommitTransaction();
                }
                catch (Exception ex)
                {
                    //エラーメッセージの表示
                    //エラーログに記録
                    //システム管理者にメールかTeamsでメッセージ送信
                    db.RollbackTransaction();
                }
            }
        }
        private static void ExecuteInsertQueryWithTransaction_()
        {
            var db = new Database(Program.ConnectionString);

            try
            {
                db.Open();
                db.BeginTransaction(IsolationLevel.ReadCommitted);
                db.ExecuteNonQuery("insert into Payment values(NEWID(), 'バターフィナンシェ', '2021-09-30', 560)");
                db.ExecuteNonQuery("insert into Payment values(NEWID(), 'がりがり君', '2021-09-30', 100)");

                db.CommitTransaction();
            }
            catch (Exception ex)
            {
                //エラーメッセージの表示
                //エラーログに記録
                //システム管理者にメールかTeamsでメッセージ送信
                db.RollbackTransaction();
            }
            finally
            {
                db.Dispose();
            }
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

        public static void SearchButton_Click(object sender, EventArgs e)
        {
            var md = CreateLambdaFromUserInput();
            Program.myFilter1 = md;
        }
        private static Func<Person, Boolean> CreateLambdaFromUserInput()
        {
            var age = 22;//←ユーザーの入力
            var text = "サッカー";//←ユーザーの入力
            Func<Person, Boolean> md = p => p.Age > age && p.Sports == text;
            return md;
        }
    }
}
