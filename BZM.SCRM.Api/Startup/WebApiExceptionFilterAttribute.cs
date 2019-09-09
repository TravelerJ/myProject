using Abp.Runtime.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Spring;
using Spring.ApplicationServices;
using Spring.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BZM.SCRM.Api.Startup
{
    /// <summary>
    /// 异常处理
    /// </summary>
    public class WebApiExceptionFilterAttribute:ExceptionFilterAttribute
    {
        /// <summary>
        /// 重写基类的异常处理方法
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            context.ExceptionHandled = true;
            string errorMsg = "";
            AbpValidationException abpValidationException = context.Exception as AbpValidationException;
            if (abpValidationException?.ValidationErrors?.Count > 0)
            {
                foreach (var validationError in abpValidationException.ValidationErrors)
                {
                    errorMsg += validationError.ErrorMessage + ",";
                }
            }
            else
            {
                Warning warning = context.Exception as Warning;
                if (warning != null)
                {
                    errorMsg = "500-" + warning.Message;
                }
                else
                {
                    errorMsg = "500-" + ExceptionPrompt.Instance.GetPrompt(context.Exception);
                }
            }
            context.Result = new ContentResult
            {
                Content = Spring.Helpers.Json.ToJson(new
                {
                    code = StateCode.SystemError.Value(),
                    message = errorMsg,
                    timestamp = DateTimeOffset.Now.ToUnixTimeSeconds()
                })
            };
        }
    }
}
