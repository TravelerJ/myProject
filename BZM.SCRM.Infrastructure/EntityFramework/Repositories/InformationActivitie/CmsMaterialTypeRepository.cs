using Abp.EntityFrameworkCore;
using BZM.SCRM.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SCRM.Domain.InformationActivitie.Entitys;
using SCRM.Domain.InformationActivitie.Queries;
using SCRM.Domain.InformationActivitie.Repositories;
using Spring.Datas.Sql.Queries;
using Spring.Domains.Repositories;
using System.Collections.Generic;

namespace SCRM.Infrastructure.EntityFramework.Repositories.InformationActivitie
{    
        
    /// <summary>
    /// 仓储
    /// </summary>
    public class CmsMaterialTypeRepository : SCRMRespositoryBase<CmsMaterialType,string>, ICmsMaterialTypeRepository {
        
        /// <summary>
        /// Sql查询工具
        /// </summary>
        protected readonly ISqlQuery _sqlQuery;
    
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="dbContextProvider">DbContext服务</param>
        /// <param name="sqlQuery">Sql查询工具</param>
        public CmsMaterialTypeRepository( IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery) : base( dbContextProvider ) {
            _sqlQuery = sqlQuery;
        }

        /// <summary>
        /// 获取素材类型分页
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public PagerList<dynamic> GetMaterialTypePageList(CmsMaterialTypeQuery query)
        {
            return _sqlQuery.Select(@"
                MATERIAL_TYPE_ID,
                MATERIAL_TYPE_NAME,
                CREATE_DATE")
                .Filter("MATERIAL_ATTR",query.MATERIAL_ATTR)
                .Filter("MATERIAL_TYPE_ID",query.MATERIAL_TYPE_ID)
                .Filter("DEL_FLAG",1)
                .Filter("BG_NO", AbpSession.BG_NO)
                .OrderBy("CREATE_DATE desc")
                .GetPageList<dynamic>("CMS_MATERIAL_TYPE", Context.Database.GetDbConnection(), query);
        }

        /// <summary>
        /// 获取素材类型列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<dynamic> GetMaterialTypeList(CmsMaterialTypeQuery query)
        {
            return _sqlQuery.Select(@"
                MATERIAL_TYPE_ID,
                MATERIAL_TYPE_NAME,
                CREATE_DATE")
                .Filter("MATERIAL_ATTR", query.MATERIAL_ATTR)
                .Filter("DEL_FLAG",1)
                .Filter("BG_NO", AbpSession.BG_NO)
                .OrderBy("CREATE_DATE desc")
                .GetList<dynamic>("CMS_MATERIAL_TYPE", Context.Database.GetDbConnection());
        }

        /// <summary>
        /// 批量删除素材类型信息
        /// </summary>
        /// <param name="materialTypeIds"></param>
        public void BatchDelMaterialTypeInfo(string materialTypeIds)
        {
            var sql = "Update CMS_MATERIAL_TYPE set DEL_FLAG=0 Where MATERIAL_TYPE_ID in (" + materialTypeIds + ")";
            _sqlQuery.ExcuteSql(sql, Context.Database.GetDbConnection(), null, null);
        }
    }
}
