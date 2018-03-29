using log4net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreUI.MyMiddleware
{
    /// <summary>
    /// 自定义异常处理中间件
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var statusCode = context.Response.StatusCode;
                await HandleExceptionAsync(context, ex.ToString());            
            }
            //await context.Response.WriteAsync("Hello World! (Use in Class)\n");

        }
        private Task HandleExceptionAsync(HttpContext context,  string msg)
        {          
            HandleExceptionHelper hannd = new HandleExceptionHelper();
            hannd.log.Error(msg);
            return context.Response.WriteAsync("ERROR");
        }
    }
    public class HandleExceptionHelper
    {
        public ILog log = LogManager.GetLogger(Startup.Repository.Name, typeof(Exception));//实例化log4net

    }

}
