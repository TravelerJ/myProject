
using Abp.Specifications;
using BZM.SCRM.Application;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Domain.Common.ReportModels;
using SCRM.Application.System.Contracts;
using SCRM.Application.System.Dtos;
using SCRM.Domain.System.Entitys;
using SCRM.Domain.System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SCRM.Application.WctPaMstrs {
    /// <summary>
    /// 公众号服务
    /// </summary>
    public class WctPaMstrService : SCRMAppServiceBase, IWctPaMstrService {

        /// <summary>
        /// 公众号仓储
        /// </summary>
        private readonly IWctPaMstrRepository _wctPaMstrRepository;
        /// <summary>
        /// 公共字段helper
        /// </summary>
        private readonly InitHelper _initHelper;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public WctPaMstrService( IWctPaMstrRepository wctPaMstrRepository,
            InitHelper initHelper) {
            _wctPaMstrRepository = wctPaMstrRepository;
            _initHelper = initHelper;
        }


        /// <summary>
        /// 保存公众号信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ReturnMsg SavePaInfo(WctPaMstrDto dto)
        {
            var rm = new ReturnMsg();
            var entity = new WctPaMstr();
            var isOk = CheckPaInfo(dto, rm);
            if (!isOk.IsSuccess)
                return rm;
            if (string.IsNullOrEmpty(dto.Id))
            {
                dto.Id = Guid.NewGuid().ToString("N");
                _initHelper.InitAdd(dto, AbpSession.USR_ID, dto.PA_ID_NO, AbpSession.BG_NO);
                entity = dto.ToEntity();
                _wctPaMstrRepository.Insert(entity);
            }
            else
            {
                _initHelper.InitUpdate(dto, AbpSession.USR_ID);
                entity = dto.ToEntity();
                _wctPaMstrRepository.Update(entity);
            }
            rm.IsSuccess = true;

            return rm;            
        }

        /// <summary>
        /// 校验公众号信息
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="rm"></param>
        /// <returns></returns>
        public ReturnMsg CheckPaInfo(WctPaMstrDto dto, ReturnMsg rm)
        {
            if (string.IsNullOrEmpty(dto.PA_NAME))
            {
                rm.IsSuccess = false;
                rm.msg = "请输入公众号名称";
                return rm;
            }
            if (string.IsNullOrEmpty(dto.PA_ORIGINAL_ID))
            {
                rm.IsSuccess = false;
                rm.msg = "请输入公众号原始ID";
                return rm;
            }
            if (string.IsNullOrEmpty(dto.PA_APPID))
            {
                rm.IsSuccess = false;
                rm.msg = "请输入appId";
                return rm;
            }
            if (string.IsNullOrEmpty(dto.PA_APPID))
            {
                rm.IsSuccess = false;
                rm.msg = "请输入appSecret";
                return rm;
            }
            if (string.IsNullOrEmpty(dto.PA_ID_NO))
            {
                rm.IsSuccess = false;
                rm.msg = "请选择绑定账号";
                return rm;
            }
            if (dto.PA_TYPE_ID==0)
            {
                rm.IsSuccess = false;
                rm.msg = "请选择微信账号类型";
                return rm;
            }
            var result = new List<WctPaMstr>();
            result = GetExpressionResult(dto.Id, c => c.PA_APPID == dto.PA_APPID && c.PA_TYPE_ID == dto.PA_TYPE_ID);
            if (result.Count > 0)
            {
                rm.IsSuccess = false;
                rm.msg = "appId已存在,请重新输入";
                return rm;
            }
            result = GetExpressionResult(dto.Id, c => c.PA_ORIGINAL_ID == dto.PA_ORIGINAL_ID && c.PA_TYPE_ID == dto.PA_TYPE_ID);
            if (result.Count > 0)
            {
                rm.IsSuccess = false;
                rm.msg = "公众号原始ID已存在,请重新输入";
                return rm;
            }
            result = GetExpressionResult(dto.Id, c => c.PA_ID_NO == dto.PA_ID_NO && c.PA_TYPE_ID == dto.PA_TYPE_ID); ;
            if (result.Count > 0)
            {
                var msg = "";
                switch (dto.PA_TYPE_ID)
                {
                    case 1:
                        msg = "服务号";
                        break;
                    case 2:
                        msg = "订阅号";
                        break;
                    case 3:
                        msg = "企业号";
                        break;
                    case 4:
                        msg = "小程序";
                        break;
                }
                rm.IsSuccess = false;
                rm.msg = "该机构已绑定" + msg + ",请重新选择";
                return rm;
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
        public List<WctPaMstr> GetExpressionResult(string Id, Expression<Func<WctPaMstr, bool>> expression1)
        {
            Expression<Func<WctPaMstr, bool>> expression = c => string.IsNullOrEmpty(Id) ? c.DEL_FLAG == 1 :
               c.Id != Id & c.DEL_FLAG == 1;
            return _wctPaMstrRepository.GetAllList(expression.And(expression1));
        }

        /// <summary>
        /// 批量删除公众号信息
        /// </summary>
        /// <param name="paIds"></param>
        /// <returns></returns>
        public ReturnMsg DelPaInfo(string paIds)
        {
            var rm = new ReturnMsg();
            if (string.IsNullOrEmpty(paIds))
            {
                rm.IsSuccess = false;
                rm.msg = "请选择要删除的公众信息";
                return rm;
            }
            var sqlStr = "'" + paIds.Trim(new char[] { ',' }).Replace(",", "','") + "'";
            _wctPaMstrRepository.BatchDelPaInfo(sqlStr);

            rm.IsSuccess = true;
            return rm;
            
        }
    }
}
