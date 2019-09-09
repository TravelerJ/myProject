using Abp.AspNetCore;
using Abp.AutoMapper;
using Abp.Modules;
using BZM.SCRM.Api.Application;
using BZM.SCRM.Domain;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BZM.SCRM.IdentityServer
{
    [DependsOn(typeof(SCRMDataModule),
        typeof(SCRMApiApplicationModule),      
         typeof(AbpAspNetCoreModule),
        typeof(AbpAutoMapperModule))]
    public class IdentityServerModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;
        public IdentityServerModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
