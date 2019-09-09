using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using BZM.SCRM.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Infrastructure.EntityFramework
{
   public abstract class SCRMRespositoryBase<TEentity,TPrimaryKey>: EfCoreRepositoryBase<SCRMDbContext, TEentity, TPrimaryKey>
         where TEentity:class,IEntity<TPrimaryKey>
    {
        /// <summary>
        /// 当前会话
        /// </summary>
        public new IAbpSessionExtensions AbpSession { get; set; }

        protected SCRMRespositoryBase(IDbContextProvider<SCRMDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

    }
}
