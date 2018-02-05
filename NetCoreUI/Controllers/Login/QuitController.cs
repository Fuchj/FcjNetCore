using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreUI.Controllers.Login
{
    public class QuitController : Controller
    {
        public IActionResult QulitData()
        {
            //HttpContext.Session.Set("CurrentUser", SessionConvert.Object2Bytes(Model));
            HttpContext.Session.Remove("CurrentUser");
            return RedirectToAction("Index", "Chart");
        }
    }
}