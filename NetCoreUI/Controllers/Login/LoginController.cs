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
        #region 常规登录
        public IActionResult Index()
        {
            return View(new UserInfo());
        }
        [HttpPost]
        public IActionResult Index([FromForm]UserInfo Model)
        {
            if (ModelState.IsValid)
            {             
                HttpContext.Session.Set("CurrentUser", SessionConvert.Object2Bytes(Model));
                //return Json(new { IsSuccess = 0, Message = "成功" });
                //跳转到首页
                return RedirectToAction("Index", "Home");
            }
            string Error = "";
            foreach (var item in ModelState)
            {
                if (item.Value.Errors.Count > 0)
                {
                    Error += item.Value.Errors.First().ErrorMessage;
                }
            }       
            Model.Message = Error;
            return View(Model);
            //return Json(new { IsSuccess = 0, Message = $"请求失败，{Error}" });
        }
        #endregion
        #region 使用Vue
        public IActionResult VueLoginIndex()
        {
            return View();
        }
        [HttpPost]
        public IActionResult VueLoginIndex([FromForm]UserInfo Model)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.Set("CurrentUser", SessionConvert.Object2Bytes(Model));
                return Json(new {IsSuccess = 1, Message = "成功"});
                //跳转到首页
                //return RedirectToAction("Index", "Home");
            }
            string Error = "";
            foreach (var item in ModelState)
            {
                if (item.Value.Errors.Count > 0)
                {
                    Error += item.Value.Errors.First().ErrorMessage;
                }
            }
            Model.Message = Error;
            return Json(new {IsSuccess = 0, Message = Error });           
        }
        #endregion
    }
}