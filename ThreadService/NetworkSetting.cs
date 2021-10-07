using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadService
{
    public class NetworkSetting
    {
        public static NetworkSetting Current { get; private set; } = new NetworkSetting();

        public Int32 P1 { get; set; }
        public Boolean P2 { get; set; }
    }
}
