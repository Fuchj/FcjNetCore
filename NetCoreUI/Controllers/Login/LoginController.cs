using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreHelp;
using NetCoreModel;

namespace NetCoreUI.Controllers.Login
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index([FromForm]UserInfo Model)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.Set("CurrentUser", SessionConvert.Object2Bytes(Model));
                //return Json(new { IsSuccess = 0, Message = "成功" });
                //跳转到首页
                return RedirectToAction("Index", "Chart");
            }
            string Error = "";
            foreach (var item in ModelState)
            {
                if (item.Value.Errors.Count > 0)
                {
                    Error += item.Value.Errors.First().ErrorMessage;
                }
            }
            return Json(new { IsSuccess = 0, Message = $"请求失败，{Error}" });
        }
    }
}