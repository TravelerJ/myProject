using Abp.Dependency;
using Abp.EntityFrameworkCore;
using Abp.Modules;
using BZM.SCRM.Domain;
using Spring.Datas.Sql.Queries;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Transactions;

namespace BZM.SCRM.Infrastructure
{
    [DependsOn(typeof(AbpEntityFrameworkCoreModule), typeof(SCRMCoreModule))]
    public class SCRMDataModule: AbpModule
    {
        public override void PreInitialize()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Configuration.UnitOfWork.IsolationLevel = IsolationLevel.ReadCommitted;//事物隔离级别
            IocManager.RegisterIfNot<ISqlQuery, OracleQuery>(DependencyLifeStyle.Transient);
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
