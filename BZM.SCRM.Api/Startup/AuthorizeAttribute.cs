using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BZM.SCRM.Api.Startup
{
    /// <summary>
    /// 授权认证属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuthorizeAttribute : Microsoft.AspNetCore.Authorization.AuthorizeAttribute
    {
        public string Permission { get; set; }
        public AuthorizeAttribute(string permission)
        {
            Permission = permission;
        }
    }
}
