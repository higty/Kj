using System;
using System.Collections.Generic;
using System.Text;
using ThreadService;

namespace MultiThreadWpfApp
{
    public class MyApp
    {
        public static MyApp Current { get; set; } = new MyApp();

        public DatabaseSetting DatabaseSetting { get; set; }
        public NetworkSetting NetworkSetting { get; set; }

        public void Initialize()
        {
            this.DatabaseSetting = DatabaseSetting.LoadSetting("C:\\MySetting.json");
        }
    }
}
