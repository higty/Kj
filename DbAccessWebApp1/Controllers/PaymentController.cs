using DbAccessDatabase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbAccessWebApp1.Controllers
{
    public class PaymentController : Controller
    {
        public class ListPage
        {
            public String Text { get; set; }
            public List<PaymentRecord> PaymentList { get; set; } = new List<PaymentRecord>();
        }
        public IActionResult List()
        {
            var model = new ListPage();
            model.Text = "今年もあと10日！";

            for (int i = 0; i < 10; i++)
            {
                var r = new PaymentRecord();
                r.Title = "商品" + i;
                r.Price = i * 100;
                model.PaymentList.Add(r);
            }
            return View(model);
        }
    }
}
