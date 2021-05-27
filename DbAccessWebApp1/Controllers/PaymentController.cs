using DbAccessDatabase;
using DbAccessWebApp1.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            foreach (var item in paymentList.OrderByDescending(el => el.Date))
            {
                model.PaymentList.Add(item);
            }
            return View(model);
        }
        
        public class PaymentPage
        {
            public PageEditMode EditMode { get; set; } = PageEditMode.Add;
            public PaymentRecord PaymentRecord { get; set; }
        }
        [HttpGet("/Payment/Add")]
        public IActionResult Add()
        {
            var page = new PaymentPage();
            page.EditMode = PageEditMode.Add;
            page.PaymentRecord = new PaymentRecord();
            return this.View("Edit", page);
        }
        [HttpPost("/Api/Payment/Add")]
        public async Task<Object> Api_Payment_Add()
        {
            var json = await this.GetRequestBodyText();
            var r = JsonConvert.DeserializeObject<PaymentRecord>(json);
            if (r.Title == "")
            {
                return new BadRequestResult();
            }

            var db = new Database();
            db.ConnectionString = System.IO.File.ReadAllText("C:\\GitHub\\ConnectionString.txt");
            db.Insert(r);

            return new { Message = "正常終了！" };
        }

        [HttpGet("/Payment/{paymentCD}/Edit")]
        public IActionResult Edit(Guid paymentCD)
        {
            var page = new PaymentPage();
            page.EditMode = PageEditMode.Edit;

            var db = new Database();
            db.ConnectionString = System.IO.File.ReadAllText("C:\\GitHub\\ConnectionString.txt");
            page.PaymentRecord = db.SelectByPrimaryKey(paymentCD);

            return this.View(page);
        }
        [HttpPost("/Api/Payment/Edit")]
        public async Task<Object> Api_Payment_Edit()
        {
            var json = await this.GetRequestBodyText();
            var r = JsonConvert.DeserializeObject<PaymentRecord>(json);
            if (r.Title == "")
            {
                return new BadRequestResult();
            }

            var db = new Database();
            db.ConnectionString = System.IO.File.ReadAllText("C:\\GitHub\\ConnectionString.txt");
            db.Update(r);

            return new { Message = "正常終了！" };
        }
        [HttpPost("/Api/Payment/Delete")]
        public async Task<Object> Api_Payment_Delete()
        {
            var json = await this.GetRequestBodyText();
            var r = JsonConvert.DeserializeObject<PaymentRecord>(json);

            var db = new Database();
            db.ConnectionString = System.IO.File.ReadAllText("C:\\GitHub\\ConnectionString.txt");
            db.Delete(r.PaymentCD);

            return new { Message = "正常終了！" };
        }

        private async Task<String> GetRequestBodyText()
        {
            Request.EnableBuffering();
            Request.Body.Position = 0;
            var m = new MemoryStream();
            await Request.Body.CopyToAsync(m);
            var bb = m.ToArray();
            var text = Encoding.UTF8.GetString(bb);
            return text;
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
