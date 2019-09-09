using Abp.Modules;
using BZM.SCRM.Api.Application;
using BZM.SCRM.Application.Common.Job;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BZM.SCRM.Api.Startup
{
    [DependsOn(typeof(SCRMApiApplicationModule),
        typeof(SCRMDataModule),
        typeof(AptJobModule))]
    public class ScrmApiModule: AbpModule//定义
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ScrmApiModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath,env.EnvironmentName);
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            //当前程序集的特定类或接口注册到依赖注入容器中。
        }
    }
}
