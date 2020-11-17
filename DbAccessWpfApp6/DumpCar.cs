using System;
using System.Collections.Generic;
using System.Text;

namespace DbAccessWpfApp6
{
    public class DumpCar : Car
    {
        public DumpCar(String name)
        {
            this.Name = name;
        }
        public override String GetPicture()
        {
            return @"
  
だんぷです
        ";
        }
    }
}
