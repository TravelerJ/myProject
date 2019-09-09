using AutoMapper.Configuration;
using BZM.SCRM.Api.Startup;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Spring.ApplicationServices;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace BZM.SCRM.Api.filter
{
    public class AuthorizationFilter: IAuthorizationFilter
    {
        public AuthorizationFilter(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //判断是否是初始路由
            if (Convert.ToString(context.RouteData.Values["routeOrigin"]) == "default")
            {
                return;
            }

            //验证头部信息
            //ValidateHeader(context);

            if (context.Filters.Any(item => item is IAllowAnonymousFilter))
            {
                return;
            }
            if (!(context.ActionDescriptor is ControllerActionDescriptor))
            {
                return;
            }
            if (context.HttpContext.User == null || !context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            //验证用户权限
            //var attributeList = new List<object>();
            //attributeList.AddRange((context.ActionDescriptor as ControllerActionDescriptor).MethodInfo.GetCustomAttributes(true));
            //attributeList.AddRange((context.ActionDescriptor as ControllerActionDescriptor).MethodInfo.DeclaringType.GetCustomAttributes(true));
            //var authorizeAttributes = attributeList.OfType<AuthorizeAttribute>().ToList();
            //var claims = context.HttpContext.User?.Claims;
            // 从claims取出用户相关信息，到数据库中取得用户具备的权限码，与当前Controller或Action标识的权限码做比较
            //var userPermissions = "User_Edit";
            //if (!authorizeAttributes.Any(s => s.Permission.Equals(userPermissions)))
            //{
            //    context.Result = new JsonResult("没有权限");
            //}
            return;
        }

        /// <summary>
        /// 验证头部信息
        /// </summary>
        private void ValidateHeader(AuthorizationFilterContext context)
        {
            //验证头部信息的完整性
            IHeaderDictionary headers = context.HttpContext.Request.Headers;
            string authorization = headers["Authorization"];
            string appKey = Configuration["AppSettings:AppKey"];
            string timestamp = headers["Timestamp"];
            string sign = headers["Sign"];
            if (string.IsNullOrWhiteSpace(timestamp) || string.IsNullOrWhiteSpace(sign))
            {
                context.Result = Fail("非法的请求", "", StateCode.IllegalRequest);
                return;
            }

            //验证时间戳
            TimeSpan timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            int timestampNow = (int)timeSpan.TotalSeconds;
            int timestampSetting = Spring.Helpers.Convert.ToInt(Configuration["AppSettings:Timestamp"]);
            if (Math.Abs(Spring.Helpers.Convert.ToInt(timestamp) - timestampNow) > timestampSetting)
            {
                context.Result = Fail("该请求已经失效", "", StateCode.IllegalRequest);
                return;
            }

            //验证数字签名
            string requestParameterString = "";
            switch (context.HttpContext.Request.Method)
            {
                case "GET":
                    IDictionary<string, string> parameters = new Dictionary<string, string>();
                    foreach (var query in context.HttpContext.Request.Query)
                    {
                        parameters.Add(query.Key, query.Value);
                    }
                    requestParameterString = Spring.Helpers.Json.ToJson(parameters);
                    break;
                default:
                    var request = context.HttpContext.Request;
                    request.EnableRewind();
                    using (StreamReader reader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true))
                    {
                        requestParameterString = reader.ReadToEnd();
                    }
                    request.Body.Position = 0;
                    break;
            }
            StringBuilder signStringBuilder = new StringBuilder();
            string hashBefore = requestParameterString + appKey + timestamp + authorization;
            byte[] bytes = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(hashBefore));
            for (int i = 0; i < bytes.Length; i++)
            {
                string hex = bytes[i].ToString("X2");
                if (hex.Length == 1)
                {
                    signStringBuilder.Append("0");
                }
                signStringBuilder.Append(hex);
            }
            if (sign != signStringBuilder.ToString())
            {
                context.Result = Fail("无效的签名", "", StateCode.IllegalRequest);
                return;
            }
        }

        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="description">详细描述</param>
        /// <param name="stateCode">状态码</param>
        /// <param name="errors">错误信息数组</param>
        /// <param name="contentType">内容类型</param>
        private ActionResult Fail(string message, string description, StateCode stateCode, List<ErrorMessage> errors = null, string contentType = "application/json; charset=utf-8")
        {
            return new ContentResult
            {
                Content = Spring.Helpers.Json.ToJson(new
                {
                    code = stateCode,
                    message,
                    description,
                    errors,
                    timestamp = DateTimeOffset.Now.ToUnixTimeSeconds()
                }),
                ContentType = contentType
            };
        }
    }
}
