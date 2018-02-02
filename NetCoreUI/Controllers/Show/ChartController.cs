using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreIservice;

namespace NetCoreUI.Controllers.Show
{
    public class ChartController : Controller
    {
        public readonly ICeShi _ceshi;
        public readonly ICeShi1 _ICeShi1;
        public ChartController(ICeShi ceshi, ICeShi1 ceShi1)
        {
            _ceshi = ceshi;
            _ICeShi1 = ceShi1;
        }
        public IActionResult Index()
        {
            var result=_ceshi.Show();
            var result1 = _ICeShi1.Show();
            return View();
        }
    }
}