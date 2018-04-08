using Autofac;
using Autofac.Extensions.DependencyInjection;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreUI.Autofac;
using NetCoreUI.Filter;
using NetCoreUI.MyMiddleware;
using NetCoreUI.WebSocketServer;
using System;
using System.IO;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreUI
{
    public class Startup
    {
        public static ILoggerRepository Repository;//log4net
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            #region 配置log4net
            Repository = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(Repository, new FileInfo("log4net.config"));
            #endregion
        }
        public IConfiguration Configuration { get; }      
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            #region 添加使用MVC中间件
            //替换控制器所有者
            //services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());       
            // services.AddMvc();
            services.AddMvc(options =>
            {
                options.Filters.Add<GlobalExceptionFilter>();
            });
            #endregion
            //services.AddDbContext<BloggingContext>();
            //services.AddDirectoryBrowser();       
            services.AddSession(); //添加Session中间件
            #region  添加AutoFac中间件
            var builder = new ContainerBuilder();//实例化 AutoFac 容器
            //模块注入
            builder.RegisterModule<DefaultModule>();
            //属性注入控制器
            //builder.RegisterType<ChartController>().PropertiesAutowired();
            builder.Populate(services);
            var ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(ApplicationContainer);//第三方IOC接管 core内置DI容器  
            #endregion
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseErrorHandling();//自定义异常
            #region 自定义中间件越过其他组件
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Custom middleware over the other components!");
            //});
            //app.Use(async (context, next) =>
            //{
            //    throw new Exception();
            //    // Do work that doesn't write to the Response.
            //    await next.Invoke();
            //    // Do logging or other work that doesn't write to the Response.
            //});
            #endregion
            #region 开发环境选择
            if (env.IsDevelopment())
            {
                //开发环境异常处理
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
              
            }
            else
            {
                //生产环境异常处理
                app.UseErrorHandling();
                app.UseExceptionHandler("/Home/Error");
            }
            #endregion
            #region 使用HTTP错误代码页
            app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");
            //app.UseStatusCodePagesWithRedirects("/Home/Error/{0}");
            //app.UseStatusCodePages("text/plain", "Status code page, status code: {0}");
            #endregion
            #region 使用静态文件
            app.UseStaticFiles();
            #endregion
            #region  使用session
            app.UseSession();
            #endregion
            #region 路由配置
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Vue}/{action=Index}/{id?}");
            //template: "{controller=Vue}/{action=ZuJianIndex}/{id?}");
                    //template: "{controller=Login}/{action=Index}/{id?}");
                //template: "{controller=Login}/{action=ZuJianIndex}/{id?}");
            });
            #endregion
            #region 使用WebSocket
            //绑定WebSocket  
            app.Map("/CeShi/Connect", (con) =>
            {
                con.UseWebSockets();
                WSHanleTwo _two = new WSHanleTwo();
                //Func<HttpContext, Func<Task>, Task> middleware
                con.Use(_two.Connect);//添加自定义中间件
            });
            #endregion
        }
    }
}
