using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreUI.Controllers.Show
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}