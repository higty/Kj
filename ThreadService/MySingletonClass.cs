using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadService
{
    public class MySingletonClass
    {
        public static MySingletonClass Current { get; private set; } = new MySingletonClass();

        public String Name { get; set; }

        private MySingletonClass()
        {

        }

        public void Method1()
        {

        }
    }
}
