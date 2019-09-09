using Abp.AspNetCore;
using Abp.AutoMapper;
using Abp.Modules;
using BZM.SCRM.Domain;
using System;
using System.Reflection;

namespace BZM.SCRM.Api.Application
{
    [DependsOn (typeof(AbpAutoMapperModule),
        typeof(SCRMCoreModule),
        typeof(AbpAspNetCoreModule))]
    public class SCRMApiApplicationModule: AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
