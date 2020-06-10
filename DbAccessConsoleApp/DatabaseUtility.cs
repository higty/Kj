using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;//MSのSQLサーバーへのアクセス

namespace DbAccessConsoleApp
{
    public class DatabaseUtility
    {
        public static void ExecuteNonQuery(String connectionString, String query)
        {
            using (var cn = new SqlConnection(connectionString))
            {
                //SQLを設定するSqlCommandクラスを作成
                var cm = new SqlCommand(query);
                //SQLを実行する先のDBを設定する
                cm.Connection = cn;
                //接続を開く
                cn.Open();
                //実際にSQLを実行する
                var insertCount = cm.ExecuteNonQuery();
                //接続を閉じる
                cn.Close();
            }
        }
    }
}
