using Abp.AspNetCore.Mvc.Controllers;
using Abp.AspNetCore.Mvc.Extensions;
using Abp.Auditing;
using Abp.Collections.Extensions;
using Abp.Runtime.Security;
using Abp.UI;
using BZM.SCRM.Api.Startup;
using BZM.SCRM.Domain;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Domain.Common.FileLogHelper;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Spring.ApplicationServices;
using Spring.Domains.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BZM.SCRM.Api.Controllers
{
    [WebApiExceptionFilter]
    public abstract class SCRMControllerBase:AbpController
    {
        /// <summary>
        /// 客户主机信息
        /// </summary>
        public IClientInfoProvider ClientInfoProvider { get; set; }

        /// <summary>
        /// 当前会话
        /// </summary>
        public new IAbpSessionExtensions AbpSession { get; set; }
        /// <summary>
        /// 控制器基础类构造函数
        /// </summary>
        protected SCRMControllerBase()
        {
            ClientInfoProvider = NullClientInfoProvider.Instance;
        }

        /// <summary>
        /// 执行前
        /// </summary>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Thread.CurrentPrincipal = HttpContext?.User;
            base.OnActionExecuting(filterContext);
        }
        /// <summary>
        /// 生成当前方法（action）路由的日志
        /// </summary>
        protected FileLog FileLog
        {
            
            get => new FileLog(RouteData.Values["controller"].ToString()+"/"+ RouteData.Values["action"].ToString());
        }

        protected WebApiBaseInfo GetBaseInfo => new WebApiBaseInfo()
        {
            Log = FileLog
        };

        /// <summary>
        /// 数据字典转为Json格式字符串
        /// </summary>
        /// <param name="arguments">字典参数</param>
        /// <returns></returns>
        private string ConvertArgumentsToJson(IDictionary<string, object> arguments)
        {
            try
            {
                if (arguments.IsNullOrEmpty())
                {
                    return "{}";
                }
                var dictionary = new Dictionary<string, object>();
                foreach (var argument in arguments)
                {
                    dictionary[argument.Key] = JsonConvert.SerializeObject(argument.Value);
                }

                return JsonConvert.SerializeObject(dictionary);
            }
            catch (Exception ex)
            {
                Logger.Warn(ex.ToString(), ex);
                return "{}";
            }
        }

        /// <summary>
        /// 验证模型状态
        /// </summary>
        protected virtual void CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                throw new UserFriendlyException(L("FormIsNotValidMessage"));
            }
        }

        /// <summary>
        /// 返回原始内容结果
        /// </summary>
        /// <param name="content">数据</param>
        /// <param name="contentType">内容类型</param>
        protected virtual ActionResult ContentResult(string content, string contentType = "application/json; charset=utf-8")
        {
            return new ContentResult
            {
                Content = content,
                ContentType = contentType
            };
        }

        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="data">数据</param>
        /// <param name="contentType">内容类型</param>
        protected virtual ActionResult Success(string message = "操作成功", object data = null, string contentType = "application/json; charset=utf-8")
        {
            return new ContentResult
            {
                Content = Spring.Helpers.Json.ToJson(new
                {
                    code = StateCode.Ok,
                    message,
                    data,
                    timestamp = DateTimeOffset.Now.ToUnixTimeSeconds()
                }),
                ContentType = contentType
            };
        }

        /// <summary>
        /// 返回分页消息
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="page">分页对象</param>
        /// <param name="message">消息</param>
        /// <param name="contentType">内容类型</param>
        protected virtual ActionResult Page(object data, Page page, string message = "获取分页列表数据成功", string contentType = "application/json; charset=utf-8")
        {
            return new ContentResult
            {
                Content = Spring.Helpers.Json.ToJson(new
                {
                    code = StateCode.Ok,
                    message,
                    data = new { result = data, page = page },
                    timestamp = DateTimeOffset.Now.ToUnixTimeSeconds()
                }),
                ContentType = contentType
            };
        }

        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="description">详细描述</param>
        /// <param name="contentType">内容类型</param>
        protected ActionResult Fail(string message, string description = "", string contentType = "application/json; charset=utf-8")
        {
            return new ContentResult
            {
                Content = Spring.Helpers.Json.ToJson(new
                {
                    code = StateCode.SystemError,
                    message,
                    description,
                    timestamp = DateTimeOffset.Now.ToUnixTimeSeconds()
                }),
                ContentType = contentType
            };
        }

        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="description">详细描述</param>
        /// <param name="errors">错误信息数组</param>
        /// <param name="contentType">内容类型</param>
        protected ActionResult Fail(string message, string description, List<ErrorMessage> errors, string contentType = "application/json; charset=utf-8")
        {
            return new ContentResult
            {
                Content = Spring.Helpers.Json.ToJson(new
                {
                    code = StateCode.SystemError,
                    message,
                    description,
                    errors,
                    timestamp = DateTimeOffset.Now.ToUnixTimeSeconds()
                }),
                ContentType = contentType
            };
        }

        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="stateCode">状态码</param>
        /// <param name="errors">错误信息数组</param>
        /// <param name="contentType">内容类型</param>
        protected ActionResult Fail(string message, StateCode stateCode, List<ErrorMessage> errors = null, string contentType = "application/json; charset=utf-8")
        {
            return new ContentResult
            {
                Content = Spring.Helpers.Json.ToJson(new
                {
                    code = stateCode,
                    message,
                    description = "",
                    errors,
                    timestamp = DateTimeOffset.Now.ToUnixTimeSeconds()
                }),
                ContentType = contentType
            };
        }

        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="description">详细描述</param>
        /// <param name="stateCode">状态码</param>
        /// <param name="errors">错误信息数组</param>
        /// <param name="contentType">内容类型</param>
        protected ActionResult Fail(string message, string description, StateCode stateCode, List<ErrorMessage> errors = null, string contentType = "application/json; charset=utf-8")
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
