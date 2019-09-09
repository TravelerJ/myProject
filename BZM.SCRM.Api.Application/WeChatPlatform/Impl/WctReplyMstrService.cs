
using Abp.Specifications;
using BZM.SCRM.Application;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Domain.Common.ReportModels;
using SCRM.Application.WeChatPlatform.Contracts;
using SCRM.Application.WeChatPlatform.Dtos;
using SCRM.Domain.WeChatPlatform.Entitys;
using SCRM.Domain.WeChatPlatform.Queries;
using SCRM.Domain.WeChatPlatform.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SCRM.Application.WeChatPlatform.Impl
{
    /// <summary>
    /// 回复服务
    /// </summary>
    public class WctReplyMstrService : SCRMAppServiceBase, IWctReplyMstrService {
    
        /// <summary>
        /// 回复仓储
        /// </summary>
        private readonly IWctReplyMstrRepository _wctReplyMstrRepository;
        /// <summary>
        /// 公共字段helper
        /// </summary>
        private readonly InitHelper _initHelper;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public WctReplyMstrService( IWctReplyMstrRepository wctReplyMstrRepository,
            InitHelper initHelper) {
            _wctReplyMstrRepository = wctReplyMstrRepository;
            _initHelper = initHelper;
        }

        /// <summary>
        /// 保存回复信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ReturnMsg SaveReplyInfo(WctReplyMstrDto dto)
        {
            var rm = new ReturnMsg();
            var entity = new WctReplyMstr();
            var isOk = CheckReplyInfo(dto, rm);
            if (!isOk.IsSuccess)
                return rm;
            if (string.IsNullOrEmpty(dto.Id))
            {
                dto.Id = Guid.NewGuid().ToString("N");
                dto.REPLY_STATUS = "未发布";
                dto.REPLY_ID_NO = AbpSession.ORG_NO;
                _initHelper.InitAdd(dto, AbpSession.USR_ID, AbpSession.ORG_NO, AbpSession.BG_NO);
                entity = dto.ToEntity();
                _wctReplyMstrRepository.Insert(entity);
            }
            else
            {
                _initHelper.InitUpdate(dto, AbpSession.USR_ID);
                entity = dto.ToEntity();
                _wctReplyMstrRepository.Update(entity);
            }
            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 校验回复信息
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="rm"></param>
        /// <returns></returns>
        public ReturnMsg CheckReplyInfo(WctReplyMstrDto dto, ReturnMsg rm)
        {
            if (dto.REPLY_TYPE==0)
            {
                rm.IsSuccess = false;
                rm.msg = "请选择回复类型";
                return rm;
            }
            if (dto.REPLY_TYPE == 3 && (string.IsNullOrEmpty(dto.REPLY_KEYWORD)|| string.IsNullOrEmpty(dto.REPLY_KEYWORD.Trim())))
            {
                rm.IsSuccess = false;
                rm.msg = "请输入关键字";
                return rm;
            }
            if (dto.REPLY_CONTENT_TYPE == 0 &&(string.IsNullOrEmpty(dto.REPLY_TEXT)|| string.IsNullOrEmpty(dto.REPLY_TEXT.Trim())))
            {
                rm.IsSuccess = false;
                rm.msg = "请输入回复内容";
                return rm;
            }
            if (dto.REPLY_CONTENT_TYPE != 0)
            {
                if (string.IsNullOrEmpty(dto.MATERIAL_IDS))
                {
                    rm.IsSuccess = false;
                    rm.msg = "请选择回复的图文信息";
                    return rm;
                }
                var list=dto.MATERIAL_IDS.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (list.Count > 8)
                {
                    rm.IsSuccess = false;
                    rm.msg = "图文消息不可超过8条";
                    return rm;
                }
            }
            var result = new List<WctReplyMstr>();
            if (dto.REPLY_TYPE == 1 || dto.REPLY_TYPE == 2 || dto.REPLY_TYPE == 4)
            {
                result = GetExpressionResult(dto.Id, c => c.REPLY_TYPE == dto.REPLY_TYPE);
                if (result.Count > 0)
                {
                    var msg = dto.REPLY_TYPE == 1 ? "关注" : dto.REPLY_TYPE == 2 ? "默认" : "新用户关注";
                    rm.IsSuccess = false;
                    rm.msg = "" + msg + "回复已存在,请重新输入";
                    return rm;
                }
            }
           else
            {
                result = GetExpressionResult(dto.Id, c => c.REPLY_TYPE == dto.REPLY_TYPE && c.REPLY_KEYWORD == dto.REPLY_KEYWORD);
                if (result.Count > 0)
                {
                   
                    rm.IsSuccess = false;
                    rm.msg = "该关键词已存在,请重新输入";
                    return rm;
                }
            }

            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 统一处理查询
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="expression1"></param>
        /// <returns></returns>
        public List<WctReplyMstr> GetExpressionResult(string Id, Expression<Func<WctReplyMstr, bool>> expression1)
        {
            Expression<Func<WctReplyMstr, bool>> expression = c => string.IsNullOrEmpty(Id) ? c.DEL_FLAG == 1 && c.CREATE_ORG_NO == AbpSession.ORG_NO :
               c.Id != Id & c.DEL_FLAG == 1 && c.CREATE_ORG_NO == AbpSession.ORG_NO;
            return _wctReplyMstrRepository.GetAllList(expression.And(expression1));
        }
        /// <summary>
        /// 批量删除回复信息
        /// </summary>
        /// <param name="replyIds"></param>
        /// <returns></returns>
        public ReturnMsg DelReplyInfo(string replyIds)
        {
            var rm = new ReturnMsg();
            if (string.IsNullOrEmpty(replyIds))
            {
                rm.IsSuccess = false;
                rm.msg = "请选择要删除的回复信息";
                return rm;
            }
            var sqlStr = "'" + replyIds.Trim(new char[] { ','}).Replace(",", "','") + "'";
            _wctReplyMstrRepository.BatchDelReplyInfo(sqlStr);

            rm.IsSuccess = true;
            return rm;

        }

        /// <summary>
        /// 更改回复信息状态
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ReturnMsg UpdateReplyStatus(WctReplyMstrQuery query)
        {
            var rm = new ReturnMsg();
            if (string.IsNullOrEmpty(query.replyIds))
            {
                rm.IsSuccess = false;
                rm.msg = "请选择要操作的回复信息";
                return rm;
            }
            var sqlStr = "'" + query.replyIds.Trim(new char[] { ',' }).Replace(",", "','") + "'";
            _wctReplyMstrRepository.BatchUpdateReplyStatus(sqlStr, query.REPLY_STATUS);

            rm.IsSuccess = true;
            return rm;

        }
    }
}
