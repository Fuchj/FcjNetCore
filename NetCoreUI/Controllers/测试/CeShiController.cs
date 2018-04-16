using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using NetCoreHelp;
using NetCoreIservice;
using NetCoreModel;
using Newtonsoft.Json;

namespace NetCoreUI.Controllers
{
    public class CeShiController :Controller
    {
        readonly string RequestUrl = "http://localhost:10111";
        //readonly string RequestUrl = "http://localhost:32451"; 

        ICeShi _ceshi;
        APIHelper _apihelper = new APIHelper();
        public CeShiController(ICeShi ceshi)
        {
           
            _ceshi = ceshi;
        }
        public IActionResult Index()
        {
           
           ViewData["ss"]= _ceshi.Show();
          
            return  View();
        }
    


        public IActionResult ReactCeShi()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }
        public IActionResult WebSocketCeShi()
        {
            return View();
        }
        #region Api Test
        public async Task<IActionResult> Show()
        {
            // var result = await _apihelper.JsonHttpGet($"{RequestUrl}/api/Values/GetUserData");
            var result = await _apihelper.ModelListHttpGet<CeShiUser>($"{RequestUrl}/api/Values/GetUserData");
            return Json(new { result });
        }
        public async Task<IActionResult> GetShow(int id,int PageNumber,int PageSize)
        {
            string postData = JsonHelper.SerializeObject(new { PageNumber, PageSize });
           // var result = await _apihelper.ModelListHttpPost<CeShiUser>($"{RequestUrl}/api/Values/Paging", postData);
            var result1 = await _apihelper.JsonPost($"{RequestUrl}/api/Values/Paging", new { PageNumber,PageSize });        
            return Json(new { result1});
        }
        #endregion
    }
}