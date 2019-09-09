using Abp.Dependency;
using Abp.Modules;
using Abp.Quartz;
using Quartz;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BZM.SCRM.Application.Common.Job
{
    /// <summary>
    /// 预约任务
    /// </summary>
    [DependsOn(typeof(AbpQuartzModule))]
    public class AptJobModule : AbpModule
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// 执行初始化
        /// </summary>
        public override void PostInitialize()
        {
            var cronExpression ="*/10 * * * * ?";//[秒] [分] [小时] [日] [月] [周] [年] 
            using (var _jobManager = IocManager.ResolveAsDisposable<IQuartzScheduleJobManager>())
            {
                _jobManager.Object.ScheduleAsync<AptJob>(
                    job =>
                    {
                        job.WithIdentity("AptJob", "Group1")
                        .WithDescription("AptJob");
                    },
                    trigger =>
                    {
                        trigger.WithCronSchedule(cronExpression).Build();
                    }
                    );
            }
        }
    }
}
