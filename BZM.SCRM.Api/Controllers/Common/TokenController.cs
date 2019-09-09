using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BZM.SCRM.Application.Common.Contracts;
using BZM.SCRM.Domain.Common.ReportModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Spring.Webs.Clients;

namespace BZM.SCRM.Api.Controllers.Common
{
    /// <summary>
    /// token
    /// </summary>
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}")]
    public class TokenController : SCRMControllerBase
    {
        /// <summary>
        /// 配置管理器
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// 公共服务
        /// </summary>
        private readonly ICommonService _commonService;
        /// <summary>
        /// token
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="commonService"></param>
        public TokenController(IConfiguration configuration, ICommonService commonService)
        {
            Configuration=configuration;
            _commonService = commonService;
        }
        /// <summary>
        /// 请求领牌
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("Token"), MapToApiVersion("1.0")]
        public ActionResult Token([FromBody] IDictionary<string, string> parameters)
        {
            try
            {
                WebClient webClient = new WebClient();
                string baseUrl = Configuration["AppSettings:IdsUrl"];
                string result = webClient.Post(baseUrl + "connect/token").Data(parameters).Result();
                var returnResult = JsonConvert.DeserializeObject<TokenReturn>(result);
                if(string.IsNullOrEmpty(returnResult.access_token))
                {
                    return Fail(result);
                }
                return Success("操作成功", result);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 请求七牛领牌
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("QiNiuToken"), MapToApiVersion("1.0")]
        public ActionResult QiNiuToken()
        {
            try
            {
                var token = _commonService.GetQiNiuToken();
                return Success("操作成功", token);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }
    }
}