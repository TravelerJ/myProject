using BZM.SCRM.Domain.Common.Request;
using BZM.SCRM.Domain.ServiceManagement.ReportModels;
using Newtonsoft.Json;
using SCRM.Domain.System.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.Common.Util
{
    /// <summary>
    /// 车型数据公共类型
    /// </summary>
    public class CarHelper
    {
        /// <summary>
        /// 获取车型数据
        /// </summary>
        /// <param name="bgNo"></param>
        /// <param name="level"></param>
        /// <param name="msg"></param>
        /// <param name="parentids"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static List<CarInfoModel> GetCarInfo(string bgNo, int level, ref string msg, string parentids = "", string ids = "")
        {
            List<CarInfoModel> list = new List<CarInfoModel>();
            var basConfig = new WxHelper().GetBasConfig(bgNo);
            if (basConfig == null)
            {
                msg = "请先维护微信基础设置";
                return null;
            }

            //车型来源(1.比滋特, 2.ERP)
            if (basConfig.CAR_FROM == 1)
            {
                list = new OdmCarRequest().GetODMCarInfo(basConfig, level, parentids, ref msg, ids);
            }
            else
            {
                string url = "";
                var getUrl = new WxHelper().GetErpApiUrl(bgNo, ref url, ref msg, "new");
                if (!getUrl)
                {
                    throw new Exception(msg);
                }
                list = new ErpCarRequest(url).GetERPCarInfo(level, ref msg, parentids, ids);
            }
            return list;
        }

        /// <summary>
        /// 获取二手库存信息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static List<UseCarStockModel> GetUseCarStockInfo(string bgNo, string buNo, ref string msg)
        {
            var basConfig = new WxHelper().GetBasConfig(bgNo);
            if (basConfig == null)
            {
                throw new Exception("请先维护微信基础设置");
            }

            var list = new OdmCarRequest().GetUseCarStockInfo(basConfig, buNo, ref msg);

            return list;
        }
    }
}
