using Abp.EntityFrameworkCore;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SCRM.Domain.MallManagement.Entitys;
using SCRM.Domain.MallManagement.Queries;
using SCRM.Domain.MallManagement.Repositories;
using Spring.Datas.Sql.Queries;

namespace SCRM.Infrastructure.EntityFramework.Repositories.MallManagement
{

    /// <summary>
    /// 仓储
    /// </summary>
    public class MdmGoodsMstrRepository : SCRMRespositoryBase<MdmGoodsMstr, long>, IMdmGoodsMstrRepository
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
        public MdmGoodsMstrRepository(IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery, PermissionHelper permissionHelper) : base(dbContextProvider)
        {
            _sqlQuery = sqlQuery;
            _permissionHelper = permissionHelper;
        }

        /// <summary>
        /// 获取秒杀商品分页数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public dynamic GetMsGoodsPageList(MdmGoodsMstrQuery query)
        {
            string where = _permissionHelper.GetCondition(AbpSession.USR_TYPE, AbpSession.USR_SCOPE, "good.CREATE_ORG_NO", AbpSession.ORG_NO, AbpSession.BG_NO);
            return _sqlQuery.Select(@"good.goods_id,good.GOODS_RMK ,good.goods_name,gl.UDF2 Pic,gl.GL_STATUS,good.sp_sdate,good.sp_edate,good.sp_qty,good.SP_PRICE,gs.PL_SELL_PRICE,gs.PL_PROMO_PRICE")
                .Filter("good.sp_flag", 1)
                .Filter("gl.GL_STATUS", 1)
                .Contains("good.GOODS_RMK", query.GOODS_RMK)
                .And(where)
                .OrderBy("good.CREATE_DATE DESC")
                .GetPageList<dynamic>(@"mdm_goods_mstr good 
                            left join mdm_goods_list gl on good.gl_id = gl.gl_id
                            left join MDM_GOODS_SPL gs on gs.pl_goods_no = good.goods_no", Context.Database.GetDbConnection(), query);
        }

        /// <summary>
        /// 获取商品规格
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public dynamic GetGoodsSpecById(string id)
        {
            return _sqlQuery.Select(@"gl.GL_NO,gm.SHOW_IN_LIST,gm.PROPERTY_IMAGE,gl.GL_NAME,gm.gl_id,gm.goods_no,gm.goods_id,gm.GOODS_RMK,nvl(gm.SP_FLAG,0)SP_FLAG,gm.SP_SDATE,gm.SP_EDATE,nvl(gm.SP_QTY,0)SP_QTY,nvl(gm.SP_PRICE,0)SP_PRICE,gs.PL_SELL_PRICE,gs.PL_PROMO_PRICE
                                            ,ii.QTY,BARCODE,gm.GOODS_STATUS,gm.PROMOTION_ATTR,gm.show_in_list,gm.is_three_commitments,gm.create_org_no")
                                            .Filter("gm.del_flag", 1)
                                            .Filter("gm.GL_ID", id)
                                            .Filter("gm.create_org_no", AbpSession.ORG_NO)
                                            .GetList<dynamic>(@"mdm_goods_mstr gm
                                            left join mdm_goods_list gl on gm.GL_ID=gl.GL_ID
                                            left join MDM_GOODS_SPL gs on gs.pl_goods_no = gm.goods_no
                                            left join inv_inventory ii on ii.goods_no = gm.goods_no", Context.Database.GetDbConnection());
        }
    }
}
