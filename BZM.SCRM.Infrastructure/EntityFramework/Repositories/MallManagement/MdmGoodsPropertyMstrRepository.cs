using Abp.EntityFrameworkCore;
using BZM.SCRM.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SCRM.Domain.MallManagement.Entitys;
using SCRM.Domain.MallManagement.Repositories;
using Spring.Datas.Sql.Queries;

namespace SCRM.Infrastructure.EntityFramework.Repositories.MallManagement
{

    /// <summary>
    /// 仓储
    /// </summary>
    public class MdmGoodsPropertyMstrRepository : SCRMRespositoryBase<MdmGoodsPropertyMstr, string>, IMdmGoodsPropertyMstrRepository
    {

        /// <summary>
        /// Sql查询工具
        /// </summary>
        protected readonly ISqlQuery _sqlQuery;

        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="dbContextProvider">DbContext服务</param>
        /// <param name="sqlQuery">Sql查询工具</param>
        public MdmGoodsPropertyMstrRepository(IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery) : base(dbContextProvider)
        {
            _sqlQuery = sqlQuery;
        }

        /// <summary>
        /// 验证该属性是否存在
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ValidateProperty(string parentId, string value)
        {
            var list = _sqlQuery.Select("*")
                .Filter("del_flag", 1)
                .Filter("PROPERTY_PARENTID", parentId)
                .Filter("PROPERTY_DEFAULT_VALUE", value)
                .Filter("CREATE_ORG_NO", AbpSession.ORG_NO)
                .GetList<dynamic>("MDM_GOODS_PROPERTY_MSTR", Context.Database.GetDbConnection());

            return list?.Count > 0;
        }

        /// <summary>
        /// 删除属性
        /// </summary>
        /// <param name="propertyId"></param>
        /// <param name="where"></param>
        public bool DelProValue(string propertyId, string where)
        {
            string sql = @"update MDM_GOODS_PROPERTY_MSTR set del_flag=0 where PROPERTY_PARENTID='" + propertyId + "' " + where;
            return _sqlQuery.ExcuteSql(sql, Context.Database.GetDbConnection()) > 0;
        }
    }
}
