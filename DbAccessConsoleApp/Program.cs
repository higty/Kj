using System;
using System.Reflection.Metadata;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;//MSのSQLサーバーへのアクセス
using System.Net.Sockets;

namespace DbAccessConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        { 
            //クラスを作る
            var s = "test";
            Console.WriteLine(s);
            //フィールドを定義する
            //インスタンスとは？
            //メソッドを定義する
        }
        static void DB_By_Class()
        {
            var s = File.ReadAllText("C:\\GitHub\\ConnectionString.txt");
            Database db = new Database();
            db.ConnectionString = s;
            var taskList = db.SelectAll();
            foreach (var r in taskList)
            {
                Console.WriteLine(r.DueDate?.ToString("yyyy/MM/dd") + " " + r.UserName + " " + r.Title);
            }
            Console.ReadLine();
        }
        static void DB_DTask_Insert_By_Class()
        {
            var s = File.ReadAllText("C:\\GitHub\\ConnectionString.txt");
            Database db = new Database();
            db.ConnectionString = s;
            db.ExecuteNonQuery("insert into DTask values(NEWID(), 'SQLの復習6/10', GETDATE(), '笹木', '2020-6-14', '寺子屋0610')");
            db.ExecuteNonQuery("insert into DTask values(NEWID(), 'SQLの復習6/12', GETDATE(), '田中', '2020-6-22', '寺子屋0617')");
            db.ExecuteNonQuery("insert into DTask values(NEWID(), 'SQLの復習6/14', GETDATE(), '鈴木', '2020-6-24', '寺子屋0617')");
        }
        static void DB_DTask_Insert_By_UtilityClass()
        {
            var s = File.ReadAllText("C:\\GitHub\\ConnectionString.txt");
            DatabaseUtility.ExecuteNonQuery(s, "insert into DTask values(NEWID(), 'SQLの復習6/10', GETDATE(), '笹木', '2020-6-14', '寺子屋0610')");
            DatabaseUtility.ExecuteNonQuery(s, "insert into DTask values(NEWID(), 'SQLの復習6/11', GETDATE(), '田中', '2020-6-14', '寺子屋0610')");
            DatabaseUtility.ExecuteNonQuery(s, "insert into DTask values(NEWID(), 'SQLの復習6/12', GETDATE(), '鈴木', '2020-6-16', '寺子屋0610')");
            DatabaseUtility.ExecuteNonQuery(s, "insert into DTask values(NEWID(), 'SQLの復習6/13', GETDATE(), '高橋', '2020-6-14', '寺子屋0610')");
            DatabaseUtility.ExecuteNonQuery(s, "insert into DTask values(NEWID(), 'SQLの復習6/14', GETDATE(), '松田', '2020-6-18', '寺子屋0610')");
        }
        static void DB_DTask_SelectAll()
        {
            var connectionString = File.ReadAllText("C:\\GitHub\\ConnectionString.txt");
            Console.WriteLine(connectionString);

            using (var cn = new SqlConnection(connectionString))
            {
                //タスクを全件取得するSqlCommandクラスを作成
                var cm = new SqlCommand("select * from DTask");
                cm.Connection = cn;
                cn.Open();

                var dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    var dueDate = (DateTime)dr["DueDate"];
                    var title = dr["Title"].ToString();
                    Console.WriteLine(dueDate.ToString("yyyy/MM/dd") + " " + title);
                }
                cn.Close();
            }
        }
        static void DB_DTask_Insert()
        {
            var connectionString = File.ReadAllText("C:\\GitHub\\ConnectionString.txt");
            Console.WriteLine(connectionString);

            //接続文字列のDBへ接続するためのSqlConnectionクラスを作成してcnで利用。
            using (var cn = new SqlConnection(connectionString))
            {
                //SQLを設定するSqlCommandクラスを作成
                var cm = new SqlCommand("insert into DTask values(NEWID(), 'SQLの復習2', GETDATE(), '松田', '2020-5-24', '寺子屋1')");
                //SQLを実行する先のDBを設定する
                cm.Connection = cn;
                //接続を開く
                cn.Open();
                //実際にSQLを実行する
                var insertCount = cm.ExecuteNonQuery();
                //接続を閉じる
                cn.Close();
            }
            Console.ReadLine();
        }
        static void DB_DTask_RecordCount_Get()
        {
            var connectionString = File.ReadAllText("C:\\GitHub\\ConnectionString.txt");
            Console.WriteLine(connectionString);

            //接続文字列のDBへ接続するためのSqlConnectionクラスを作成してcnで利用。
            using (var cn = new SqlConnection(connectionString))
            {
                //SQLを設定するSqlCommandクラスを作成
                var cm = new SqlCommand("select COUNT(*) from DTask");
                //SQLを実行する先のDBを設定する
                cm.Connection = cn;
                //接続を開く
                cn.Open();
                //実際にSQLを実行する
                var o = cm.ExecuteScalar();
                Console.WriteLine(o);
                //接続を閉じる
                cn.Close();
            }
            Console.ReadLine();

        }
        static void File_Read()
        {
            String filePath = "C:\\Dev\\MyTextFile.txt";
            String body = System.IO.File.ReadAllText(filePath);
            Console.WriteLine(body);
            Console.ReadLine();
        }
        static void File_Write()
        {
            String filePath = "C:\\Dev\\MyTextFile.txt";
            File.WriteAllText(filePath, "中身を変えたよ！");
            Console.ReadLine();
        }
        static void File_Encoding()
        {
            var encoding = CodePagesEncodingProvider.Instance.GetEncoding(932);
            String filePath = "C:\\Dev\\MyTextFile.txt";
            String body = System.IO.File.ReadAllText(filePath, encoding);
            Console.WriteLine(body);
            File.WriteAllText(filePath, "中身を変えたよ！");
            Console.ReadLine();
        }
    }
}

