using DbAccessDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbAccessWebApp1
{
    public class PaymentListViewModel
    {
        public String Text { get; set; }
        public List<PaymentRecord> PaymentList { get; set; } = new List<PaymentRecord>();
    }
}
