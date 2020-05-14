using System;
using System.Reflection.Metadata;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;//MSのSQLサーバーへのアクセス

namespace DbAccessConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
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
