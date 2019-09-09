using Abp.Configuration.Startup;
using Abp.MultiTenancy;
using Abp.Runtime;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;

namespace BZM.SCRM.Domain
{
   public class AbpSessionExtensions: ClaimsAbpSession, IAbpSessionExtensions
    {
        public AbpSessionExtensions(IPrincipalAccessor principalAccessor, IMultiTenancyConfig multiTenancy, ITenantResolver tenantResolver, 
            IAmbientScopeProvider<SessionOverride> sessionOverrideScopeProvider): base(principalAccessor, multiTenancy, tenantResolver, sessionOverrideScopeProvider)
        {

        }
        public int USR_ID => Convert.ToInt32(GetKeyValue(ClaimTypes.USR_ID));
        public string USR_NAME => GetKeyValue(ClaimTypes.USR_NAME);
        public string USR_REAL_NAME => GetKeyValue(ClaimTypes.USR_REAL_NAME);
        public string USR_MOBILE => GetKeyValue(ClaimTypes.USR_MOBILE);
        public string USR_AVATAR_PATH => GetKeyValue(ClaimTypes.USR_AVATAR_PATH);
        public string ERP_EMP_ID => GetKeyValue(ClaimTypes.ERP_EMP_ID);
        public string USR_TYPE => GetKeyValue(ClaimTypes.USR_TYPE);
        public string ORG_NO => GetKeyValue(ClaimTypes.ORG_NO);
        public string BG_NO => GetKeyValue(ClaimTypes.BG_NO);
        public string OPEN_ID => GetKeyValue(ClaimTypes.OPEN_ID);
        public string ERP_CUS_NO => GetKeyValue(ClaimTypes.ERP_CUS_NO);
        public string ERP_MEMBER_NO => GetKeyValue(ClaimTypes.ERP_MEMBER_NO);
        public string USR_SCOPE=> GetKeyValue(ClaimTypes.USR_SCOPE);
        private string GetKeyValue(string type)        {            var claimsPrincipal = Thread.CurrentPrincipal as ClaimsPrincipal;            if (claimsPrincipal == null)                return "";            var cliam = claimsPrincipal.FindFirst(type);            if (string.IsNullOrEmpty(cliam?.Value))                return "";            return cliam.Value;        }
    }
}
