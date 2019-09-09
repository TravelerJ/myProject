
using BZM.SCRM.Application;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Domain.Common.ReportModels;
using SCRM.Application.InformationActivitie.Contracts;
using SCRM.Application.InformationActivitie.Dtos;
using SCRM.Domain.InformationActivitie.Entitys;
using SCRM.Domain.InformationActivitie.Queries;
using SCRM.Domain.InformationActivitie.Repositories;
using System;
using System.Linq;

namespace SCRM.Application.InformationActivitie.Impl
{
    /// <summary>
    /// 服务
    /// </summary>
    public class CmsMaterialMstrService : SCRMAppServiceBase, ICmsMaterialMstrService {
    
        /// <summary>
        /// 服务
        /// </summary>
        private readonly ICmsMaterialMstrRepository _cmsMaterialMstrRepository;
        private readonly InitHelper _initHelper;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public CmsMaterialMstrService( ICmsMaterialMstrRepository cmsMaterialMstrRepository,
            InitHelper initHelper) {
            _cmsMaterialMstrRepository = cmsMaterialMstrRepository;
            _initHelper = initHelper;
        }

        /// <summary>
        /// 校验素材类型信息
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="rm"></param>
        /// <returns></returns>
        public ReturnMsg CheckMaterialInfo(CmsMaterialMstrDto dto, ReturnMsg rm)
        {
            if (string.IsNullOrEmpty(dto.MATERIAL_TITLE))
            {
                rm.IsSuccess = false;
                rm.msg = "请输入标题";
                return rm;
            }
            if (string.IsNullOrEmpty(dto.MATERIAL_TYPE_ID))
            {
                rm.IsSuccess = false;
                rm.msg = "请选择分类";
                return rm;
            }
            if (dto.MATERIAL_ATTR == "2")
            {
                if (string.IsNullOrEmpty(dto.MATERIAL_AUTHOR))
                {
                    rm.IsSuccess = false;
                    rm.msg = "请填写作者";
                    return rm;
                }
                if (dto.COMMENT_RULE==null)
                {
                    rm.IsSuccess = false;
                    rm.msg = "请选择评论规则";
                    return rm;
                }
                if (dto.IS_ROUND==null)
                {
                    rm.IsSuccess = false;
                    rm.msg = "请选择是否轮播";
                    return rm;
                }
                if (dto.SLT_MODULE_TYPE == null)
                {
                    rm.IsSuccess = false;
                    rm.msg = "请选择模版";
                    return rm;
                }
                if (dto.IS_ROUND == 1 && dto.SLT_MODULE_TYPE == 2)
                {
                    rm.IsSuccess = false;
                    rm.msg = "模版选择错误,请更换模版";
                    return rm;
                }
            }
            //商城素材
            if (dto.MATERIAL_ATTR == "3")
            {
                if (string.IsNullOrEmpty(dto.UDF2))
                {
                    rm.IsSuccess = false;
                    rm.msg = "请选择关联项";
                    return rm;
                }
            }
            if (string.IsNullOrEmpty(dto.MATERIAL_COVER_URL))
            {
                rm.IsSuccess = false;
                rm.msg = "请上传封面图";
                return rm;
            }           

            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 保存素材信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ReturnMsg SaveMaterialInfo(CmsMaterialMstrDto dto)
        {
            var rm = new ReturnMsg();
            var entity = new CmsMaterialMstr();
            var isOk = CheckMaterialInfo(dto, rm);
            if (!isOk.IsSuccess)
                return rm;           
            if (string.IsNullOrEmpty(dto.Id))
            {
                //新增
                dto.Id = Guid.NewGuid().ToString("N");
                _initHelper.InitAdd(dto, AbpSession.USR_ID, AbpSession.ORG_NO, AbpSession.BG_NO);
                dto.MATERIAL_STATUS = "待发布";
                entity = dto.ToEntity();
                _cmsMaterialMstrRepository.Insert(entity);
            }
            else
            {
                _initHelper.InitUpdate(dto,AbpSession.USR_ID);
                entity = dto.ToEntity();
                _cmsMaterialMstrRepository.Update(entity);
            }
            rm.IsSuccess = true;
            return rm;
        }

        /// <summary>
        /// 批量删除素材信息
        /// </summary>
        /// <param name="materialIds"></param>
        /// <returns></returns>
        public ReturnMsg BatchDelMaterialInfo(string materialIds)
        {
            var rm = new ReturnMsg();
            if (string.IsNullOrEmpty(materialIds))
            {
                rm.IsSuccess = false;
                rm.msg = "请选择要删除的信息";
                return rm;
            }
            var sqlStr = "'" + materialIds.Trim(new char[] { ',' }).Replace(",", "','") + "'";
            _cmsMaterialMstrRepository.BatchDelMaterialInfo(sqlStr);

            rm.IsSuccess = true;
            return rm;

        }

        /// <summary>
        /// 更改资讯状态/轮播
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ReturnMsg UpdateMaterialInfoStatus(CmsMaterialMstrQuery query)
        {
            var rm = new ReturnMsg();
            if (string.IsNullOrEmpty(query.MATERIAL_ID))
            {
                rm.IsSuccess = false;
                rm.msg = "请选择要操作的资讯";
                return rm;
            }
            var materialInfo = _cmsMaterialMstrRepository.FirstOrDefault(c => c.Id == query.MATERIAL_ID && c.DEL_FLAG == 1);
            if (materialInfo == null)
            {
                rm.IsSuccess = false;
                rm.msg = "该资讯不存在";
                return rm;
            }
            if (query.ExcuteType == 1)
            {
                if (query.IS_ROUND == 1)
                {
                    var materialList = _cmsMaterialMstrRepository.GetAllList(c => c.IS_ROUND == 1 && c.MATERIAL_STATUS == "在线" && c.MATERIAL_TYPE_ID == materialInfo.MATERIAL_TYPE_ID && c.CREATE_ORG_NO == AbpSession.ORG_NO);
                    if (materialList.Count >= 5)
                    {
                        rm.IsSuccess = false;
                        rm.msg = "同类型资讯已达最大轮播数,请取消后再试";
                        return rm;
                    }
                }
                materialInfo.IS_ROUND = query.IS_ROUND;
                _initHelper.InitUpdate(materialInfo, AbpSession.USR_ID);
                _cmsMaterialMstrRepository.Update(materialInfo);
            }
            else if (query.ExcuteType == 2)
            {
                materialInfo.MATERIAL_STATUS = query.MATERIAL_STATUS;
                _initHelper.InitUpdate(materialInfo, AbpSession.USR_ID);
                _cmsMaterialMstrRepository.Update(materialInfo);
            }
            else
            {
                rm.IsSuccess = false;
                rm.msg = "请选择操作类型";
                return rm;
            }
            rm.IsSuccess = true;

            return rm;
        }
    }
}
