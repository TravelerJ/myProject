using Abp.Application.Services;
using BZM.SCRM.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Application
{
   public abstract class SCRMAppServiceBase:ApplicationService
    {
        /// <summary>
        /// 当前会话
        /// </summary>
        public new IAbpSessionExtensions AbpSession { get; set; }
    }
}
