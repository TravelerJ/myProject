
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
using System.Collections.Generic;

namespace SCRM.Application.WeChatPlatform.Impl
{
    /// <summary>
    /// 标签服务
    /// </summary>
    public class TagMstrService : SCRMAppServiceBase, ITagMstrService {
    
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
        public TagMstrService( ITagMstrRepository tagMstrRepository, WxHelper wxHelper,
           InitHelper initHelper) {
            _tagMstrRepository = tagMstrRepository;
            _wxHelper = wxHelper;
            _initHelper = initHelper;
        }

        /// <summary>
        /// 保存标签信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ReturnMsg SaveTagInfo(TagMstrDto dto)
        {
            var rm = new ReturnMsg();
            var entity = new TagMstr();
            var isOk = CheckTagInfo(dto, rm);
            if (!isOk.IsSuccess)
                return rm;
            if (string.IsNullOrEmpty(dto.Id))
            {
                var requestTag = CreateWxTag(dto.TAG_NAME, rm);
                if (!requestTag.IsSuccess)
                    return rm;
                dto.TAG_REF_DB_ID = "SCRM";
                dto.TAG_REF_TABLE_ID = "WCT";
                dto.TAG_STATUS = 1;
                dto.TAG_REF_FIELD_ID = requestTag.result;
                _initHelper.InitAdd(dto, AbpSession.USR_ID, AbpSession.ORG_NO, AbpSession.BG_NO);
                entity = dto.ToEntity();
                _tagMstrRepository.Insert(entity);
            }
            else
            {
                _initHelper.InitUpdate(dto, AbpSession.USR_ID);
                entity = dto.ToEntity();
                _tagMstrRepository.Update(entity);
            }
            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 调用微信接口创建标签
        /// </summary>
        /// <param name="tagName"></param>
        /// <param name="rm"></param>
        /// <returns></returns>
        public ReturnMsg CreateWxTag(string tagName,ReturnMsg rm)
        {
            var paInfo = _wxHelper.GetPaInfo(1, c => c.PA_ID_NO == AbpSession.ORG_NO, AbpSession.BG_NO);
            if (paInfo == null)
            {
                rm.IsSuccess = false;
                rm.msg = "公众号信息不存在";
                return rm;
            }
            var requestToken = _wxHelper.GetAccessToken(paInfo, AbpSession.BG_NO);
            if (!requestToken.IsSuccess)
                return rm;
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/tags/create?access_token={0}", requestToken.result);
            var tagMoel = new CreateTag { name = tagName };
            var dic = new Dictionary<string, object>();
            dic.Add("tag", tagMoel);
            var json = JsonConvert.SerializeObject(dic);
            var tagPost = HttpRequest.Post(url, json);
            var result = JsonConvert.DeserializeObject<TagObj>(tagPost);
            if (result.tag == null)
            {
                rm.IsSuccess = false;
                rm.msg = "创建标签失败,错误码" + result.errcode + "," + result.errmsg + "";
            }
            rm.IsSuccess = true;
            rm.result = result.tag.id;
            return rm;
        }

        /// <summary>
        /// 调用微信接口创建标签
        /// </summary>
        /// <param name="fileId">微信标签id</param>
        /// <param name="rm"></param>
        /// <returns></returns>
        public ReturnMsg DelWxTag(string fileId, ReturnMsg rm)
        {
            var paInfo = _wxHelper.GetPaInfo(1, c => c.PA_ID_NO == AbpSession.ORG_NO, AbpSession.BG_NO);
            if (paInfo == null)
            {
                rm.IsSuccess = false;
                rm.msg = "公众号信息不存在";
                return rm;
            }
            var requestToken = _wxHelper.GetAccessToken(paInfo, AbpSession.BG_NO);
            if (!requestToken.IsSuccess)
                return rm;
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/tags/delete?access_token={0}", requestToken.result);
            var tagMoel = new CreateTag { id = fileId };
            var dic = new Dictionary<string, object>();
            dic.Add("tag", tagMoel);
            var json = JsonConvert.SerializeObject(dic);
            var tagPost = HttpRequest.Post(url, json);
            var result = JsonConvert.DeserializeObject<TagObj>(tagPost);
            if (result.errcode != "0")
            {
                rm.IsSuccess = false;
                rm.msg = "删除标签失败,错误码" + result.errcode + "," + result.errmsg + "";
            }
            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 校验标签信息
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="rm"></param>
        /// <returns></returns>
        public ReturnMsg CheckTagInfo(TagMstrDto dto, ReturnMsg rm)
        {
            if (string.IsNullOrEmpty(dto.TAG_NAME))
            {
                rm.IsSuccess = false;
                rm.msg = "请填写标签名称";
                return rm;
            }
            if (string.IsNullOrEmpty(dto.TAG_TYPE))
            {
                rm.IsSuccess = false;
                rm.msg = "请选择标签分类";
                return rm;
            }
            var result = string.IsNullOrEmpty(dto.Id) ? _tagMstrRepository.GetAllList(c => c.TAG_NAME == dto.TAG_NAME && c.DEL_FLAG == 1 && c.CREATE_ORG_NO == AbpSession.ORG_NO) :
                _tagMstrRepository.GetAllList(c => c.Id != dto.Id && c.TAG_NAME == dto.TAG_NAME && c.DEL_FLAG == 1 && c.CREATE_ORG_NO == AbpSession.ORG_NO);
            if (result.Count > 0)
            {
                rm.IsSuccess = false;
                rm.msg = "该标签名称已存在";
                return rm;
            }

            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 批量删除标签信息
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public ReturnMsg DelTagInfo(string tagId)
        {
            var rm = new ReturnMsg();
            if (string.IsNullOrEmpty(tagId))
            {
                rm.IsSuccess = false;
                rm.msg = "请选择要删除的标签信息";
                return rm;
            }
            var tagInfo = _tagMstrRepository.Single(c => c.Id == tagId);
            var requestag = DelWxTag(tagInfo.TAG_REF_FIELD_ID, rm);
            if (!requestag.IsSuccess)
                return rm;
            tagInfo.DEL_FLAG = 0;
            _tagMstrRepository.Update(tagInfo);
            rm.IsSuccess = true;

            return rm;

        }
    }
}
