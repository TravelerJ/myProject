using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.MallManagement.ReportModels
{
    /// <summary>
    /// 请求erp接口入参
    /// </summary>
    public class GoodsInfoInputModel
    {
        /// <summary>
        /// 门店编码
        /// </summary>
        public string storeNo { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        public string goodsNo { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string goodsName { get; set; }
        /// <summary>
        /// 商品状态1上架0下架
        /// </summary>
        public string goodStatus { get; set; }

        /// <summary>
        /// 商品一级编码
        /// </summary>
        public string goodsLargeClassCode { get; set; }

        /// <summary>
        /// 开始页数
        /// </summary>
        public int iDisplayStart { get; set; }

        /// <summary>
        /// 分页长度
        /// </summary>
        public int iDisplayLength { get; set; }

        /// <summary>
        /// 模糊查询字段
        /// </summary>
        public string fuzzyQueryFields { get; set; }
    }
}
