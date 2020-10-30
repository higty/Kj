using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DbAccessDatabase
{
    public class PaymentRecord 
    {
        public Guid PaymentCD { get; set; }
        public DateTime Date { get; set; }
        public String Title { get; set; }
        public Int32 Price { get; set; }

        public override string ToString()
        {
            return this.Date.ToString("yyyy/MM/dd") + " " + this.Price + "円 " + this.Title;
        }
    }
}
