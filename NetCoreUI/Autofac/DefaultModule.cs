using Autofac;
using NetCoreIservice;
using NetCoreService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreUI.Autofac
{
    public class DefaultModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //注入测试服务
            builder.RegisterType<CeShi>().As<ICeShi>();
            builder.RegisterType<CeShi1>().As<ICeShi1 >();
        }
    }
}
