using Abp.EntityFrameworkCore;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SCRM.Domain.MallManagement.Entitys;
using SCRM.Domain.MallManagement.Repositories;
using Spring.Datas.Sql.Queries;
using System.Text;

namespace SCRM.Infrastructure.EntityFramework.Repositories.MallManagement
{

    /// <summary>
    /// 仓储
    /// </summary>
    public class MdmGoodsClassRepository : SCRMRespositoryBase<MdmGoodsClass, long>, IMdmGoodsClassRepository
    {

        /// <summary>
        /// Sql查询工具
        /// </summary>
        protected readonly ISqlQuery _sqlQuery;

        private readonly PermissionHelper _permissionHelper;

        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="dbContextProvider">DbContext服务</param>
        /// <param name="sqlQuery">Sql查询工具</param>
        public MdmGoodsClassRepository(IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery, PermissionHelper permissionHelper) : base(dbContextProvider)
        {
            _sqlQuery = sqlQuery;
            _permissionHelper = permissionHelper;
        }

        public dynamic GetGoodClassList()
        {
            //string where = _permissionHelper.GetCondition(AbpSession.USR_TYPE, AbpSession.USR_SCOPE, "CREATE_ORG_NO", AbpSession.ORG_NO, AbpSession.BG_NO);
            return _sqlQuery.Select("*")
                .Filter("DEL_FLAG", 1)
                .Filter("BG_NO", AbpSession.BG_NO)
                .OrderBy("UPDATE_DATE DESC")
                //.And(where)
                .GetList<dynamic>("mdm_goods_class", Context.Database.GetDbConnection());
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool DelGoodsClass(string where)
        {
            string sql = "update MDM_GOODS_CLASS set CLASS_STATUS=0 where 1=1  and BG_NO='" + AbpSession.BG_NO + "' ";
            if (!string.IsNullOrEmpty(where))
            {
                sql += " and " + where;
            }
            return _sqlQuery.ExcuteSql(sql, Context.Database.GetDbConnection()) > 0 ? true : false;
        }

        /// <summary>
        /// 查询分类是否被绑定
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public bool GetBindGoodsNum(string where)
        {
            var list = _sqlQuery.Select("GOODS_ID")
                .Filter("DEL_FLAG", 1)
                .Filter("CREATE_ORG_NO", AbpSession.ORG_NO)
                .GetList<dynamic>("MDM_GOODS_MSTR", Context.Database.GetDbConnection());

            return list != null && list.Count > 0 ? true : false;
        }
    }
}
