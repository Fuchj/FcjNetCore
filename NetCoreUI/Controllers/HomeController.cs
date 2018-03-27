using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreUI.Models;

namespace NetCoreUI.Controllers
{
    public class HomeController : Controller
    {
        private ILog log = LogManager.GetLogger(Startup.Repository.Name, typeof(HomeController));
        private readonly ILogger _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            //_logger.LogError("logger记录错误");
            //log.Error("log4net记录错误");
            throw new Exception();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error(string id="500")
        {
           // return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            return View(new ErrorViewModel { RequestId = id ?? HttpContext.TraceIdentifier });
        }
    }
}
