using Abp.EntityFrameworkCore;
using BZM.SCRM.Domain.Common.Request;
using BZM.SCRM.Domain.MallManagement.ReportModels;
using BZM.SCRM.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SCRM.Domain.MallManagement.Entitys;
using SCRM.Domain.MallManagement.Queries;
using SCRM.Domain.MallManagement.Repositories;
using Spring.Datas.Sql.Queries;
using Spring.Domains.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SCRM.Infrastructure.EntityFramework.Repositories.MallManagement
{

    /// <summary>
    /// 仓储
    /// </summary>
    public class MdmGoodsListRepository : SCRMRespositoryBase<MdmGoodsList, string>, IMdmGoodsListRepository
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
        public MdmGoodsListRepository(IDbContextProvider<SCRMDbContext> dbContextProvider, ISqlQuery sqlQuery) : base(dbContextProvider)
        {
            _sqlQuery = sqlQuery;
        }

        /// <summary>
        /// 获取上架商品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PagerList<MdmGoodsList> GetPutAwayGoodsList(GoodsInfoInputModel model)
        {
            return _sqlQuery.Select(@"GL_ID as Id, GL_NO, GL_NAME, GL_PRINT_NAME, GL_TYPE, GL_LARGECLASS, GL_INCLASS, GL_SMALLCLASS, GL_SUBCLASS, GL_LEVEL, CAR_BRAND_ID, CAR_BRAND_DESC, CAR_CLASS_ID, CAR_CLASS_DESC, CAR_TYPE_ID, CAR_TYPE_DESC, GL_UNIT, MNEMONIC_CODE, GL_SPEC, GL_MODEL, GL_MATERIAL, GL_SHELFLIFE, MADE_IN, GL_STATUS, BU_NO, GL_RMK, GL_PROPERTY, COMMENT_NUM, HIT_NUM, PROMOTION_INFO, GL_DESC, GL_SPEC_DESC, GL_PACKAGE_DESC, GL_DESC_M, GL_SPEC_DESC_M, GL_PACKAGE_DESC_M, GL_WARRANTY_DESC, GL_PUR_ATTR, GL_QA, GL_BRAND, GL_FUNC, IS_COMBO, GOODS_ATTR, LGS_SP, LGS_SP_NO, GL_SDATE, GL_EDATE, UDF1, UDF2, UDF3, UDF4, UDF5, UDF6, UDF7, UDF8, UDF9, UDF10, CREATE_PSN, CREATE_DATE, UPDATE_PSN, UPDATE_DATE, CREATE_ORG_NO, DEL_FLAG, PROMOTION_ATTR, BG_NO, MEMBER_PRICE, MENBER_POINTS, ENABLE_MP, GOODS_SALES, IS_ERPGOODS")
                .Filter("del_flag", 1)
                .Filter("GL_STATUS", 1)
                .Filter("IS_ERPGOODS", 1)
                .Filter("BU_NO", AbpSession.ORG_NO)
                .Contains("GL_NAME", model.goodsName)
                .OrderBy("CREATE_DATE desc")
                .GetPageList<MdmGoodsList>("mdm_goods_list", Context.Database.GetDbConnection(), model.iDisplayStart, model.iDisplayLength);
        }

        /// <summary>
        /// 获取erp商品信息
        /// </summary>
        /// <param name="url"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetErpGoodsInfo(string url, GoodsInfoInputModel model)
        {
            var dic = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(model.goodsName))
            {
                string[] arr = new string[] { "goodsName" };
                dic.Add("fuzzyQueryFields", arr);
            }

            dic.Add("storeNo", model.storeNo);
            dic.Add("iDisplayStart", model.iDisplayStart);
            dic.Add("iDisplayLength", model.iDisplayLength);
            dic.Add("goodsNo", model.goodsNo);
            dic.Add("goodsName", model.goodsName);
            dic.Add("goodsLargeClassCode", model.goodsLargeClassCode);

            var json = JsonConvert.SerializeObject(dic);

            return HttpRequest.ErpRequestApi(json, "Goods/GetGoodsInfo", url, AbpSession.ORG_NO);
        }

        /// <summary>
        /// 获取商品分页数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public dynamic GetGoodsInfoPageList(MdmGoodsListQuery query)
        {
           
            return _sqlQuery.Select(@"gd.GL_ID,gd.GL_NO,gd.GL_NAME,gd.GL_STATUS,gd.UDF2,gd.UPDATE_DATE,CASE WHEN gd.GL_STATUS=1 THEN '已上架' ELSE '未上架' END GL_STATUS_TEXT       
                                ,(SELECT CLASS_NAME FROM MDM_GOODS_CLASS WHERE CLASS_ID=gd.GL_LARGECLASS) AS LARGECLASS_TEXT
                                ,(SELECT CLASS_NAME FROM MDM_GOODS_CLASS WHERE CLASS_ID=gd.GL_INCLASS) AS INCLASS_TEXT
                                ,(SELECT CLASS_NAME FROM MDM_GOODS_CLASS WHERE CLASS_ID=gd.GL_SMALLCLASS) AS SMALLCLASS_TEXT
                                ,(SELECT CLASS_NAME FROM MDM_GOODS_CLASS WHERE CLASS_ID=gd.GL_SUBCLASS) AS SUBCLASS_TEXT,
                                gd.GL_LARGECLASS,gd.GL_INCLASS,gd.GL_SMALLCLASS,
                                bu.BU_NAME,BU.PARENT_BU_NAME")
                                .Filter("gd.DEL_FLAG", 1)
                                .Filter("gd.CREATE_ORG_NO", AbpSession.ORG_NO)
                                .Filter("gd.IS_ERPGOODS", 0)
                                .Contains("gd.GL_NAME", query.GL_NAME)
                                .Contains("gd.GL_NO", query.GL_NO)
                                .Filter("gd.GL_STATUS", query.GL_STATUS)
                                .Filter("gd.GL_LARGECLASS", query.GL_LARGECLASS)
                                .Filter("gd.GL_INCLASS", query.GL_INCLASS)
                                .Filter("gd.GL_SMALLCLASS", query.GL_SMALLCLASS)
                                .Filter("bu.PARENT_BU_NO", query.AREA_NO)
                                .Filter("bu.BU_NO", query.BU_NO)
                                .OrderBy("gd.UPDATE_DATE desc")
                                .GetPageList<dynamic>(@"MDM_GOODS_LIST gd left join mdm_bu_mstr bu on gd.bu_no=bu.bu_no", Context.Database.GetDbConnection(), query);
        }
    }
}
