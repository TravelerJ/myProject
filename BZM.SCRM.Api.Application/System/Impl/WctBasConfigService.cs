
using BZM.SCRM.Application;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Domain.Common.Redis;
using BZM.SCRM.Domain.Common.ReportModels;
using SCRM.Application.System.Contracts;
using SCRM.Application.System.Dtos;
using SCRM.Domain.System.Entitys;
using SCRM.Domain.System.Repositories;
using Spring.Helpers;

namespace SCRM.Application.System.Impl
{
    /// <summary>
    /// 基础配置服务
    /// </summary>
    public class WctBasConfigService : SCRMAppServiceBase, IWctBasConfigService {
    
        /// <summary>
        /// 基础配置仓储
        /// </summary>
        private readonly IWctBasConfigRepository _wctBasConfigRepository;
        /// <summary>
        /// 公共字段helper
        /// </summary>
        private readonly InitHelper _initHelper;
        /// <summary>
        /// redis
        /// </summary>
        private readonly RedisHelper _redisHelper;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public WctBasConfigService( IWctBasConfigRepository wctBasConfigRepository,
            InitHelper initHelper, RedisHelper redisHelper) {
            _wctBasConfigRepository = wctBasConfigRepository;
            _initHelper = initHelper;
            _redisHelper = redisHelper;
        }

        /// <summary>
        /// 保存基础配置信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ReturnMsg SaveWctBasConfigInfo(WctBasConfigDto dto)
        {
            var rm = new ReturnMsg();
            var entity = new WctBasConfig();
            var redis=_redisHelper.GetRedisClient(Convert.ToInt(dto.REDIS_NUM));
            if (string.IsNullOrEmpty(dto.Id))
            {
                _initHelper.InitAdd(dto, AbpSession.USR_ID, AbpSession.ORG_NO, AbpSession.BG_NO);
                entity = dto.ToEntity();
                _wctBasConfigRepository.Insert(entity);
                redis.Add(AbpSession.BG_NO + "-CONFIG_ID", dto);
            }
            else
            {
                _initHelper.InitUpdate(dto, AbpSession.USR_ID);
                entity = dto.ToEntity();
                _wctBasConfigRepository.Update(entity);
                //redis集团缓存配置修改
                if (redis.Exists(AbpSession.BG_NO + "-CONFIG_ID") != 1)
                {
                    redis.Add(AbpSession.BG_NO + "-CONFIG_ID", dto);
                }
                else
                {
                    redis.Set(AbpSession.BG_NO + "-CONFIG_ID", dto);
                }
            }
            rm.IsSuccess = true;

            return rm;
        }
    }
}
