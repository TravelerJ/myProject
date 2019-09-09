
using BZM.SCRM.Application;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Domain.Common.ReportModels;
using BZM.SCRM.Domain.Common.Request;
using BZM.SCRM.Domain.Common.Util;
using Newtonsoft.Json;
using SCRM.Application.WeChatPlatform.Contracts;
using SCRM.Application.WeChatPlatform.Dtos;
using SCRM.Domain.WeChatPlatform.Entitys;
using SCRM.Domain.WeChatPlatform.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SCRM.Application.WeChatPlatform.Impl
{
    /// <summary>
    /// 粉丝标签记录服务
    /// </summary>
    public class TagHistService : SCRMAppServiceBase, ITagHistService {
    
        /// <summary>
        /// 粉丝标签记录仓储
        /// </summary>
        private readonly ITagHistRepository _tagHistRepository;
        /// <summary>
        /// 标签仓储
        /// </summary>
        private readonly ITagMstrRepository _tagMstrRepository;
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
        public TagHistService( ITagHistRepository tagHistRepository, WxHelper wxHelper,
            InitHelper initHelper, ITagMstrRepository tagMstrRepository) {
            _tagHistRepository = tagHistRepository;
            _wxHelper = wxHelper;
            _initHelper = initHelper;
            _tagMstrRepository = tagMstrRepository;
        }

        /// <summary>
        /// 更新用户标签记录
        /// </summary>
        /// <param name="wct"></param>
        /// <param name="rm"></param>
        /// <returns></returns>
        public ReturnMsg UpdateTagHistInfo(SysUsrWctDto wct, ReturnMsg rm)
        {
            var histList = _tagHistRepository.GetAllList(c => c.TAG_REF_ROW_NO == wct.Id && c.DEL_FLAG == 1);
            var newList = wct.tagIds.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var oldList = histList.Select(c => c.TAG_REF_FIELD_ID).ToList();
            var result = newList.Except<string>(oldList).ToList();
            if (result.Count==0)
            {
                rm.IsSuccess = true;
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
            var tagList = _tagMstrRepository.GetAllList(c => c.CREATE_ORG_NO == wct.BU_NO && c.DEL_FLAG == 1);
            foreach (var item in result)
            {
                var tagHist = new TagHist();
                var tag = new TagMstr();
                tag = tagList.Where(c => c.TAG_REF_FIELD_ID == item).FirstOrDefault();
                var hist = histList.Where(c => c.TAG_REF_ROW_NO == item).FirstOrDefault();
                if (hist == null)
                {
                    rm = AddTag(wct.OPEN_ID, item, requestToken.result, rm);
                    if (!rm.IsSuccess)
                        return rm;

                    tagHist.Id = Guid.NewGuid().ToString();
                    tagHist.TAG_CODE = tag.Id;
                    tagHist.TAG_VALUE =tag.TAG_NAME;
                    tagHist.TAG_REF_ROW_NO = wct.Id;
                    tagHist.TAG_REF_TABLE_ID = "SYS_USR_WCT";
                    tagHist.CREATE_TIME = DateTime.Now;
                    tagHist.TAG_SDATE = DateTime.Now;
                    tagHist.TAG_FROM = "手工";
                    tagHist.TAG_MSTR_ID = "0";
                    tagHist.TAG_VERSION = "0";
                    tagHist.TAG_VALUE_DESC = "0";
                    tagHist.TAG_REF_DB_ID = "0";
                    tagHist.TAG_REF_FIELD_ID = item;
                    tagHist.TAG_RULE_ID = "0";
                    tagHist.TAG_EDATE = DateTime.MaxValue;
                    _initHelper.InitAdd(tagHist, AbpSession.USR_ID, wct.BU_NO, wct.BG_NO);
                }
                else
                {
                    rm = DelTag(wct.OPEN_ID, item, requestToken.result, rm);
                    if(!rm.IsSuccess)
                        return rm;
                    _tagHistRepository.DelTagHistInfo(wct.Id, item);
                }

            }

            return rm;

        }

        /// <summary>
        /// 用户打标签
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="tagId"></param>
        /// <param name="token"></param>
        /// <param name="rm"></param>
        /// <returns></returns>
        public ReturnMsg AddTag(string openId, string tagId, string token,ReturnMsg rm)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("openid_list", openId);
            dic.Add("tagid", tagId);
            string jsonStr = JsonConvert.SerializeObject(dic);
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/tags/members/batchtagging?access_token={0}", token);
            var tagPost = HttpRequest.Post(url, jsonStr);
            var result = JsonConvert.DeserializeObject<TagObj>(tagPost);
            if (result.errcode != "0")
            {
                rm.IsSuccess = false;
                rm.msg= "用户打标签失败,错误码" + result.errcode + "," + result.errmsg + "";
                return rm;
            }
            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 删除用户标签
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="tagId"></param>
        /// <param name="token"></param>
        /// <param name="rm"></param>
        /// <returns></returns>
        public ReturnMsg DelTag(string openId, string tagId, string token, ReturnMsg rm)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("openid_list", openId);
            dic.Add("tagid", tagId);
            string jsonStr = JsonConvert.SerializeObject(dic);
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/tags/members/batchuntagging?access_token={0}", token);
            var tagPost = HttpRequest.Post(url, jsonStr);
            var result = JsonConvert.DeserializeObject<TagObj>(tagPost);
            if (result.errcode != "0")
            {
                rm.IsSuccess = false;
                rm.msg = "删除用户标签失败,错误码" + result.errcode + "," + result.errmsg + "";
                return rm;
            }
            rm.IsSuccess = true;

            return rm;
        }
    }
}
