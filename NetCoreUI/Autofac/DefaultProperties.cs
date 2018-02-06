using Autofac;
using NetCoreIservice;
using NetCoreService;

namespace NetCoreUI.Autofac
{
    public class DefaultProperties : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //注入测试服务
            builder.RegisterType<DefaultModule>().As<ICeShi>().PropertiesAutowired();
           // builder.RegisterType<CeShi1>().As<ICeShi1>().PropertiesAutowired();
            //builder.RegisterType<CeShi>().As<ICeShi>();
            //builder.RegisterType<CeShi1>().As<ICeShi1>();
        }
      
    }
}
