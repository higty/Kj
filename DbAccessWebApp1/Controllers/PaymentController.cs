using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbAccessWebApp1.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
