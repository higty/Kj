using System;
using System.Collections.Generic;
using System.Text;

namespace DbAccessWpfApp6
{
    public class Parent
    {
        public String Name { get; set; }
        public Int32 Age { get; set; }

        public String GetName()
        {
            return "私の名前は" + this.Name;
        }
    }
}
