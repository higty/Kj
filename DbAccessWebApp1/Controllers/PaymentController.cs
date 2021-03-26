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
            model.Text = "これまでに買ったモノ";

            var db = new Database();
            db.ConnectionString = System.IO.File.ReadAllText("C:\\GitHub\\ConnectionString.txt");
            var paymentList = db.SelectPaymentRecords();
            foreach (var item in paymentList.OrderBy(el => el.Title))
            {
                model.PaymentList.Add(item);
            }
            return View(model);
        }
        [HttpGet("/Payment/Add")]
        public IActionResult Add()
        {
            return this.View();
        }
        [HttpGet("/JavaScriptSample")]
        public IActionResult JavaScriptSample()
        {
            return this.View();
        }
        [HttpGet("/TypeScriptSample")]
        public IActionResult TypeScriptSample()
        {
            return this.View();
        }
    }
}
