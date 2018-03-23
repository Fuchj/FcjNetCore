using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreIservice;

namespace NetCoreUI.Controllers
{
    public class CeShiController : Controller
    {
        ICeShi _ceshi;
        public CeShiController(ICeShi ceshi)
        {
            _ceshi = ceshi;
        }
        public IActionResult Index()
        {
            
            ViewData["ss"]= _ceshi.Show();
            return View();
        }
        public IActionResult ReactCeShi()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }
    }
}