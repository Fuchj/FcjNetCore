using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NetCoreUI.Controllers
{
    public class BaseController : Controller
    {    
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            byte[] result;
            filterContext.HttpContext.Session.TryGetValue("CurrentUser", out result);
            if (result == null)
            {
                filterContext.Result = new RedirectResult("/Login/Index");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
        /// <summary>
        /// 登录验证用户Session是否过期
        /// </summary>
        /// <param name="filterContext"></param>
        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    #region 登录用户验证
        //    if (this.CurrentUser == null)
        //    {
        //        if (filterContext.HttpContext.Request.IsAjaxRequest())
        //        {
        //            filterContext.HttpContext.Response.AddHeader("SessionTimeout", "true");
        //            filterContext.Result = new HttpStatusCodeResult(403, "您没有该权限，请登录！");
        //            return;
        //        }
        //        else
        //        {
        //            filterContext.HttpContext.Response.Write(
        //           " <script type='text/javascript'> alert('由于您长时间未操作，系统已自动关闭。请重新登录');window.top.location='/Login/LoginPage'; </script>");
        //            filterContext.RequestContext.HttpContext.Response.End();
        //            filterContext.Result = new EmptyResult();
        //            return;
        //        }
        //    }
        //    base.OnActionExecuting(filterContext);
        //    #endregion
        //}
    }
}