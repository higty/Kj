using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadService
{
    public class DatabaseSetting
    {
        public Int32 P1 { get; private set; }
        public String P2 { get; private set; }
        public Boolean P3 { get; private set; }

        public static DatabaseSetting LoadSetting(String filePath)
        {
            return new DatabaseSetting();
        }
    }
}
