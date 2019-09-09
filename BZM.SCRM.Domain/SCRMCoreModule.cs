using Abp.AspNetCore;
using Abp.AutoMapper;
using Abp.Modules;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Domain.Common.Chat;
using BZM.SCRM.Domain.Common.RabbitMq;
using BZM.SCRM.Domain.Common.Redis;
using BZM.SCRM.Domain.Common.Request;
using BZM.SCRM.Domain.Common.Util;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BZM.SCRM.Domain
{
    [DependsOn(typeof(AbpAutoMapperModule),
        typeof(AbpAspNetCoreModule))]
    public class SCRMCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.Register<PermissionHelper>();
            IocManager.Register<InitHelper>();
            IocManager.Register<WxHelper>();
            IocManager.Register<SmsHelper>();
            IocManager.Register<HttpRequest>();
            IocManager.Register<RedisHelper>();
            IocManager.Register<MqHelper>();
            IocManager.Register<ChatHelper>();
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
