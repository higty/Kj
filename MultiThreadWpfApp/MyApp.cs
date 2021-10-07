using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using ThreadService;

namespace MultiThreadWpfApp
{
    public class MyApp
    {
        public static MyApp Current { get; set; } = new MyApp();

        private String _ConnectionString = "";

        public DatabaseSetting DatabaseSetting { get; set; }
        public NetworkSetting NetworkSetting { get; set; }

        public void Initialize()
        {
            _ConnectionString = "";//Load from file
            this.DatabaseSetting = DatabaseSetting.LoadSetting("C:\\MySetting.json");
        }
        public SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_ConnectionString);
        }
    }
}
