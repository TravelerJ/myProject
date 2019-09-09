using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.ServiceManagement.ReportModels
{
    /// <summary>
    /// 车型数据model
    /// </summary>
    public class CarInfoModel
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public string CLASS_ID { get; set; }

        /// <summary>
        /// 车型编码
        /// </summary>
        public string CLASS_NO { get; set; }

        /// <summary>
        /// 车型名称
        /// </summary>
        public string CLASS_NAME { get; set; }

        /// <summary>
        /// 车型等级
        /// </summary>
        public int CLASS_LEVEL { get; set; }

        /// <summary>
        /// 上级id
        /// </summary>
        public string PARENT_ID { get; set; }

        /// <summary>
        /// 车辆属性(ZC-整车/SP-商品)
        /// </summary>
        public string CLASS_ATTR { get; set; }

        /// <summary>
        /// 车辆状态(默认1)
        /// </summary>
        public int CLASS_STATUS { get; set; }

        /// <summary>
        /// 业务类型{ZC:(NC:新车，AC:售后车，UC:二手车)}
        /// </summary>
        public string BIZ_TYPE { get; set; }

        /// <summary>
        /// 预约试驾配置车型细分是否选中
        /// </summary>
        public bool IsCheck { get; set; }

        /// <summary>
        /// 文件id
        /// </summary>
        public string FILE_ID { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string imgName { get; set; }
        /// <summary>
        /// 子项
        /// </summary>
        public List<CarInfoModel> ChildInfo { get; set; }

    }

    public class CarInfo
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public string CLASS_ID { get; set; }

        /// <summary>
        /// 车型编码
        /// </summary>
        public string CLASS_NO { get; set; }

        /// <summary>
        /// 车型名称
        /// </summary>
        public string CLASS_NAME { get; set; }

        /// <summary>
        /// 车型等级
        /// </summary>
        public int CLASS_LEVEL { get; set; }

        /// <summary>
        /// 上级id
        /// </summary>
        public string PARENT_ID { get; set; }
        /// <summary>
        /// 文件id
        /// </summary>
        public string FILE_ID { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string imgName { get; set; }
        /// <summary>
        /// 子项
        /// </summary>
        public List<CarInfo> ChildInfo { get; set; }

    }
}
