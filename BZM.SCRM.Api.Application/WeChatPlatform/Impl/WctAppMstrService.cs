
using Abp.Domain.Uow;
using Abp.Specifications;
using BZM.SCRM.Application;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Domain.Common.Redis;
using BZM.SCRM.Domain.Common.ReportModels;
using BZM.SCRM.Domain.System.ReportModels;
using BZM.SCRM.Domain.WeChatPlatform.ReportModels;
using Newtonsoft.Json;
using SCRM.Application.WeChatPlatform.Contracts;
using SCRM.Application.WeChatPlatform.Dtos;
using SCRM.Domain.System.Entitys;
using SCRM.Domain.System.Repositories;
using SCRM.Domain.WeChatPlatform.Entitys;
using SCRM.Domain.WeChatPlatform.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;

namespace SCRM.Application.WeChatPlatform.Impl
{
    /// <summary>
    /// 微信app服务
    /// </summary>
    public class WctAppMstrService : SCRMAppServiceBase, IWctAppMstrService {

        /// <summary>
        /// 微信app仓储
        /// </summary>
        private readonly IWctAppMstrRepository _wctAppMstrRepository;
        /// <summary>
        /// 微信基础配置仓储
        /// </summary>
        private readonly IWctBasConfigRepository _wctBasConfigRepository;
        /// <summary>
        /// 微信app子应用仓储
        /// </summary>
        private readonly IWctAppItemRepository _wctAppItemRepository;
        /// <summary>
        /// 系统模块仓储
        /// </summary>
        private readonly IWctSysmoduleMstrRepository _wctSysmoduleMstrRepository;
        /// <summary>
        /// 公共字段helper
        /// </summary>
        private readonly InitHelper _initHelper;
        /// <summary>
        /// redis
        /// </summary>
        private readonly RedisHelper _redisHelper;
        /// <summary>
        /// abp自定义事务
        /// </summary>
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        /// <summary> 
        /// 初始化服务
        /// </summary>
        public WctAppMstrService( IWctAppMstrRepository wctAppMstrRepository,
           IWctBasConfigRepository wctBasConfigRepository, IWctAppItemRepository wctAppItemRepository,
           IWctSysmoduleMstrRepository wctSysmoduleMstrRepository, InitHelper initHelper,
           RedisHelper redisHelper, IUnitOfWorkManager unitOfWorkManager) {
            _wctAppMstrRepository = wctAppMstrRepository;
            _wctBasConfigRepository = wctBasConfigRepository;
            _wctAppItemRepository = wctAppItemRepository;
            _wctSysmoduleMstrRepository = wctSysmoduleMstrRepository;
            _initHelper = initHelper;
            _redisHelper = redisHelper;
            _unitOfWorkManager = unitOfWorkManager;
        }

        /// <summary>
        /// 获取功能模块子菜单
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public ReturnMsg GetAppItemInfo(string appId)
        {
            var rm = new ReturnMsg();
            var selectAppInfo = new List<WctSysmoduleMstrModel>();
            var unSelectAppInfo = new List<WctSysmoduleMstrModel>();
            var appList = new List<WctAppMstr>();
            appList = _wctAppMstrRepository.GetAllList(c => c.WCT_MODULE_TYPE == "1" && c.DEL_FLAG == 1 && c.BU_NO == AbpSession.ORG_NO);
            var allSecondMoudle = _wctSysmoduleMstrRepository.GetSysModuleList(new List<string>(), "secondary");
            var allAppIdList = allSecondMoudle.Select(c => c.SYSM_ID).ToList();
            if (!string.IsNullOrEmpty(appId))
            {
                if (appList.Count == 0)
                {
                    rm.IsSuccess = false;
                    rm.msg = "数据检索异常";
                    return rm;
                }
                var appMstr = appList.FirstOrDefault(c => c.Id == appId && c.DEL_FLAG == 1);
                if (appMstr == null)
                {
                    rm.IsSuccess = false;
                    rm.msg = "一级菜单不存在";
                    return rm;
                }
                var childSelectAppIds = appMstr.SYS_MODULE_IDS.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                selectAppInfo = allSecondMoudle.Where(c => childSelectAppIds.Contains(c.SYSM_ID)).ToList();
            }           
            var selectAppIds = string.Join(',', appList.Select(c => c.SYS_MODULE_IDS));
            var selectAppIdList = selectAppIds.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var unSelectAppIds = allAppIdList.Except(selectAppIdList).ToList();
            if (unSelectAppIds.Count > 0)
            {
                unSelectAppInfo = allSecondMoudle.Where(c => unSelectAppIds.Contains(c.SYSM_ID)).ToList();
            }
           
            var dic = new Dictionary<string, object>();
            dic.Add("SelectAppInfo", selectAppInfo);
            dic.Add("UnSelectAppInfo", unSelectAppInfo);

            rm.IsSuccess = true;
            rm.result = JsonConvert.SerializeObject(dic);

            return rm;

        }

        /// <summary>
        /// 校验app应用信息
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="rm"></param>
        /// <returns></returns>
        public ReturnMsg CheckAppInfo(WctAppMstrDto dto, ReturnMsg rm)
        {
            var basConfig = _wctBasConfigRepository.FirstOrDefault(c => c.BG_NO == AbpSession.BG_NO);
            if (basConfig == null)
            {
                rm.IsSuccess = false;
                rm.msg = "请先维护微信基础配置";
                return rm;
            }
            if (dto.APP_SORT == null)
            {
                rm.IsSuccess = false;
                rm.msg = "请填写序号";
                return rm;
            }
            if (dto.APP_SORT < 0)
            {
                rm.IsSuccess = false;
                rm.msg = "序号必须大于0";
                return rm;
            }
            if (string.IsNullOrEmpty(dto.UDF2))
            {
                rm.IsSuccess = false;
                rm.msg = "模块KEY不可为空";
                return rm;
            }
            if (string.IsNullOrEmpty(dto.UDF3))
            {
                rm.IsSuccess = false;
                rm.msg = "模块图标不可为空";
                return rm;
            }
            if (string.IsNullOrEmpty(dto.WCT_MODULE_TYPE))
            {
                rm.IsSuccess = false;
                rm.msg = "模块类型不可为空";
                return rm;
            }
            if (dto.WCT_MODULE_TYPE == "1")
            {
                if (string.IsNullOrEmpty(dto.SYS_MODULE_IDS))
                {
                    rm.IsSuccess = false;
                    rm.msg = "请选择子模块";
                    return rm;
                }
                if (dto.appItemList == null || dto.appItemList.Count == 0)
                {
                    rm.IsSuccess = false;
                    rm.msg = "请选择子模块";
                    return rm;
                }
            }
            var result = new List<WctAppMstr>();
            result = GetExpressionResult(dto.Id, c => c.APP_SORT == dto.APP_SORT && c.APP_KEY == "primary");
            if (result.Count > 0)
            {
                rm.IsSuccess = false;
                rm.msg = "该序号已存在,请修改";
                return rm;
            }
            result = GetExpressionResult(dto.Id, c => c.WCT_MODULE_ID == dto.WCT_MODULE_ID && c.APP_KEY == "primary");
            if (result.Count > 0)
            {
                rm.IsSuccess = false;
                rm.msg = "该关联模块已存在，请修改";
                return rm;
            }
            rm.IsSuccess = true;
            rm.result = JsonConvert.SerializeObject(basConfig.REDIS_NUM);
            return rm;
        }

        /// <summary>
        /// 统一处理查询
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="expression1"></param>
        /// <returns></returns>
        public List<WctAppMstr> GetExpressionResult(string Id, Expression<Func<WctAppMstr, bool>> expression1)
        {
            Expression<Func<WctAppMstr, bool>> expression = c => string.IsNullOrEmpty(Id) ? c.DEL_FLAG == 1 && c.BU_NO == AbpSession.ORG_NO :
               c.Id != Id & c.DEL_FLAG == 1 && c.BU_NO == AbpSession.ORG_NO;
            return _wctAppMstrRepository.GetAllList(expression.And(expression1));
        }

        /// <summary>
        /// 保存app菜单信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ReturnMsg SaveAppInfo(WctAppMstrDto dto)
        {
            var rm = new ReturnMsg();
            var isOk = CheckAppInfo(dto, rm);
            if (!isOk.IsSuccess)
                return rm;
            var excute = AddOrUpdateAppMstrInfo(dto, rm);
            if (!excute.IsSuccess)
                return rm;
            var redisNum = Convert.ToInt32(rm.result);
            var appList = GetAppInfoList(rm);
            if (!appList.IsSuccess)
                return rm;
            var redis = _redisHelper.GetRedisClient(redisNum);
            var key = AbpSession.ORG_NO + "-APP_ID";
            if (redis.Exists(key) != 1)
            {
                redis.Add(key, JsonConvert.DeserializeObject<List<WctAppInfoModel>>(rm.result));
            }
            else
            {
                redis.Set(key,JsonConvert.DeserializeObject<List<WctAppInfoModel>>(rm.result));
            }

            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 新增/更新app信息
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="rm"></param>
        /// <returns></returns>
        [UnitOfWork(false)]
        public ReturnMsg AddOrUpdateAppMstrInfo(WctAppMstrDto dto,ReturnMsg rm)
        {
            var entity = new WctAppMstr();
            var isAdd = string.IsNullOrEmpty(dto.Id) ? true : false;
            if (string.IsNullOrEmpty(dto.Id))
            {
                dto.Id = Guid.NewGuid().ToString("N");
                dto.APP_KEY = "primary";
                _initHelper.InitAdd(dto, AbpSession.USR_ID, AbpSession.ORG_NO, AbpSession.BG_NO);
                using (var unitOfWork = _unitOfWorkManager.Begin(TransactionScopeOption.RequiresNew))
                {
                    entity = dto.ToEntity();
                    _wctAppMstrRepository.Insert(entity);
                    unitOfWork.Complete();
                }
                    
            }
            else
            {
                _initHelper.InitUpdate(dto, AbpSession.USR_ID);
                using (var unitOfWork = _unitOfWorkManager.Begin(TransactionScopeOption.RequiresNew))
                {
                    entity = dto.ToEntity();
                    _wctAppMstrRepository.Update(entity);
                    unitOfWork.Complete();
                }
                
            }
            if (dto.WCT_MODULE_TYPE == "1")
            {
                var appItem = new WctAppItem();
                if (!isAdd)
                {
                    using (var unitOfWork = _unitOfWorkManager.Begin(TransactionScopeOption.RequiresNew))
                    {
                        _wctAppItemRepository.DelAppItemInfo(dto.Id);
                        unitOfWork.Complete();
                    }
                    
                }
                var i = 1;
                foreach (var item in dto.appItemList)
                {
                    item.Id = Guid.NewGuid().ToString("N");
                    item.ITEM_SORT = i;
                    _initHelper.InitAdd(item, AbpSession.USR_ID, AbpSession.ORG_NO, AbpSession.BG_NO);
                    using (var unitOfWork = _unitOfWorkManager.Begin(TransactionScopeOption.RequiresNew))
                    {
                        appItem = item.ToEntity();
                        _wctAppItemRepository.Insert(appItem);
                        unitOfWork.Complete();
                    }
                    
                }
            }
            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 获取app菜单
        /// </summary>
        /// <param name="rm"></param>
        /// <returns></returns>
        public ReturnMsg GetAppInfoList(ReturnMsg rm)
        {
            var appList = new List<WctAppInfoModel>();
            var appItemList = new List<WctAppItemModel>();
            appList = _wctAppMstrRepository.GetAppMstrList();
            if (appList.Count == 0)
            {
                rm.IsSuccess = false;
                rm.msg = "app菜单异常,请检查";
                return rm;
            }
            appItemList = _wctAppItemRepository.GetAppItemList();
            foreach (var item in appList)
            {
                if (item.moduleType == "1")
                {
                    item.itemList = appItemList.Where(c => c.appId == item.key).ToList();
                }
            }
            rm.IsSuccess = true;
            rm.result = JsonConvert.SerializeObject(appList);

            return rm;
        }
        /// <summary>
        /// 获取功能模块子菜单
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public ReturnMsg DelAppInfo(string appId)
        {
            var rm = new ReturnMsg();
            if (string.IsNullOrEmpty(appId))
            {
                rm.IsSuccess = false;
                rm.msg = "数据传输异常";
                return rm;
            }
            var appInfo = _wctAppMstrRepository.FirstOrDefault(c => c.Id == appId);
            _wctAppMstrRepository.Delete(appInfo);
            if (appInfo.WCT_MODULE_TYPE == "1")
            {
                _wctAppItemRepository.DelAppItemInfo(appId);
            }
            rm.IsSuccess = true;

            return rm;
        }


    }
}
