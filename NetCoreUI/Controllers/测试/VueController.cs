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
        #region 事件
        public IActionResult EventIndex()
        {
            return View();
        }
        #endregion
        #region 组件
        public IActionResult ZuJianIndex()
        {
            return View();

        }
        #endregion
        #region Echart
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetVueData()
        {
            string[] data1 = { "衬衫", "羊毛衫", "雪纺衫", "裤子", "高跟鞋", "袜子" };
            int[] data2 = { 5, 20, 36, 10, 10, 20 };
            return Json(new { data1, data2 });
        }
        #endregion
        #region 插槽
        public IActionResult SlotIndex()
        {
            return View();
        }
        #endregion
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