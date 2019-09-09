
using BZM.SCRM.Application;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Domain.Common.ReportModels;
using BZM.SCRM.Domain.Common.Request;
using BZM.SCRM.Domain.Common.Util;
using Newtonsoft.Json;
using SCRM.Application.WeChatPlatform.Contracts;
using SCRM.Application.WeChatPlatform.Dtos;
using SCRM.Domain.WeChatPlatform.Queries;
using SCRM.Domain.WeChatPlatform.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SCRM.Application.WeChatPlatform.Impl
{
    /// <summary>
    /// 粉丝服务
    /// </summary>
    public class SysUsrWctService : SCRMAppServiceBase, ISysUsrWctService {
    
        /// <summary>
        /// 粉丝仓储
        /// </summary>
        private readonly ISysUsrWctRepository _sysUsrWctRepository;
        /// <summary>
        /// 粉丝标签记录服务
        /// </summary>
        private readonly ITagHistService _tagHistService;
        /// <summary>
        /// 微信hepler
        /// </summary>
        private readonly WxHelper _wxHelper;
        /// <summary>
        /// 公共字段helper
        /// </summary>
        private readonly InitHelper _initHelper;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public SysUsrWctService( ISysUsrWctRepository sysUsrWctRepository, ITagHistService tagHistService,
            WxHelper wxHelper, InitHelper initHelper) {
            _sysUsrWctRepository = sysUsrWctRepository;
            _tagHistService = tagHistService;
            _wxHelper = wxHelper;
            _initHelper = initHelper;
        }

        /// <summary>
        /// 粉丝打标签
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ReturnMsg WctMakeTag(SysUsrWctDto dto)
        {
            var rm = new ReturnMsg();
            if (string.IsNullOrEmpty(dto.Id))
            {
                rm.IsSuccess = false;
                rm.msg = "请选择要打标签的粉丝";
                return rm;
            }
            if (string.IsNullOrEmpty(dto.tagIds))
            {
                rm.IsSuccess = false;
                rm.msg = "请选择要打的标签";
                return rm;
            }
            var tag = _tagHistService.UpdateTagHistInfo(dto, rm);
            if (!tag.IsSuccess)
                return rm;
            var entity = dto.ToEntity();
            _sysUsrWctRepository.Update(entity);
            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 更改粉丝黑名单状态
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ReturnMsg UpdateFansBlackStatus(SysUsrWctQuery query)
        {
            var rm = new ReturnMsg();
            if (string.IsNullOrEmpty(query.WCT_ID))
            {
                rm.IsSuccess = false;
                rm.msg = "请先选择粉丝";
                return rm;
            }
            var wct = _sysUsrWctRepository.FirstOrDefault(c => c.Id == query.WCT_ID&&c.DEL_FLAG==1);
            if (wct == null)
            {
                rm.IsSuccess = false;
                rm.msg = "该粉丝不存在";
                return rm;
            }
            var paInfo = _wxHelper.GetPaInfo(1, c => c.PA_ID_NO == AbpSession.ORG_NO, AbpSession.BG_NO);
            if (paInfo == null)
            {
                rm.IsSuccess = false;
                rm.msg = "公众号信息不存在";
                return rm;
            }
            var requestToken = _wxHelper.GetAccessToken(paInfo, wct.BG_NO);
            if (!requestToken.IsSuccess)
                return rm;
            if (query.IsBlack)
            {
                rm = BlackFans(wct.OPEN_ID, requestToken.result, rm);
            }
            else
            {
                rm = UnBlackFans(wct.OPEN_ID, requestToken.result, rm);
            }
            if (!rm.IsSuccess)
                return rm;
            _initHelper.InitUpdate(wct, AbpSession.USR_ID);
            wct.UDF4 = query.IsBlack.ToString();
            _sysUsrWctRepository.Update(wct);
            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 拉黑粉丝
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="token"></param>
        /// <param name="rm"></param>
        /// <returns></returns>
        public ReturnMsg BlackFans(string openId, string token, ReturnMsg rm)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("openid_list", openId);
            string jsonStr = JsonConvert.SerializeObject(dic);
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/tags/members/batchblacklist?access_token={0}", token);
            var blackPost = HttpRequest.Post(url, jsonStr);
            var result = JsonConvert.DeserializeObject<TagObj>(blackPost);
            if (result.errcode != "0")
            {
                rm.IsSuccess = false;
                rm.msg = "拉黑粉丝失败,错误码" + result.errcode + "," + result.errmsg + "";
                return rm;
            }
            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 拉黑粉丝
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="token"></param>
        /// <param name="rm"></param>
        /// <returns></returns>
        public ReturnMsg UnBlackFans(string openId, string token, ReturnMsg rm)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("openid_list", openId);
            string jsonStr = JsonConvert.SerializeObject(dic);
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/tags/members/batchunblacklist?access_token={0}", token);
            var unBlackPost = HttpRequest.Post(url, jsonStr);
            var result = JsonConvert.DeserializeObject<TagObj>(unBlackPost);
            if (result.errcode != "0")
            {
                rm.IsSuccess = false;
                rm.msg = "取消粉丝黑名单失败,错误码" + result.errcode + "," + result.errmsg + "";
                return rm;
            }
            rm.IsSuccess = true;

            return rm;
        }
    }
}
