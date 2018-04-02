using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreUI.Controllers
{
    public class VueController : Controller
    {
        public IActionResult VueIndex()
        {
            return View();
        }
        public IActionResult ZuJianIndex()
        {
            return View();

        }
        [HttpGet]
        public IActionResult GetData()
        {
            var list = new List<VueModel>()
            {
                new VueModel{text="123"},
                new VueModel{ text="456"},
                new VueModel{text="789" }
            };

            return Json(list);
        }
    }
    public class VueModel
    {
       public string text { get; set; }
    }
}