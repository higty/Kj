using DbAccessWebApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DbAccessWebApp1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new IndexPage();
            model.Now = DateTime.Now;
            model.SomeValue = "何か値";
            model.TaskList.Add("郵便を送る");

            return View("Index", model);
        }
        public class IndexPage
        {
            public DateTime Now { get; set; }
            public String SomeValue { get; set; }
            public List<string> TaskList { get; set; } = new List<string>();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
