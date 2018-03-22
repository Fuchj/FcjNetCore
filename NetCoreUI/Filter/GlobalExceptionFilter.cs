using log4net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NetCoreUI.Filter
{
    /// <summary>
    /// 自定义全局异常过滤器
    /// </summary>
    public class GlobalExceptionFilter : IExceptionFilter
    {
       
        readonly ILoggerFactory _loggerFactory;//采用内置日志记录
        readonly IHostingEnvironment _env;//环境变量
        public GlobalExceptionFilter(ILoggerFactory loggerFactory, IHostingEnvironment env)
        {
            _loggerFactory = loggerFactory;
            _env = env;
        }

        public void OnException(ExceptionContext context)
        {
            var controller = context.ActionDescriptor;          
            ILog log = LogManager.GetLogger(Startup.Repository.Name, controller.ToString());
            #region 记录到内置日志
            //var logger = _loggerFactory.CreateLogger(context.Exception.TargetSite.ReflectedType);
            //logger.LogError(new EventId(context.Exception.HResult),
            //context.Exception,
            //context.Exception.Message);
            #endregion
            if (_env.IsDevelopment())
            {
                log.Error(context.Exception.ToString());
                //var JsonMessage = new ErrorResponse("未知错误,请重试");
                //JsonMessage.DeveloperMessage = context.Exception;
                //context.Result = new ApplicationErrorResult(JsonMessage);
                //context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                //context.ExceptionHandled = true;
            }
            else
            {
                log.Error(context.Exception.ToString());
                context.ExceptionHandled = true;
                context.Result=new RedirectResult("/home/Error");
            }
        }
        public class ApplicationErrorResult : ObjectResult
        {
            public ApplicationErrorResult(object value) : base(value)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }
        public class ErrorResponse
        {
            public ErrorResponse(string msg)
            {
                Message = msg;
            }
            public string Message { get; set; }
            public object DeveloperMessage { get; set; }
        }
    }
}
