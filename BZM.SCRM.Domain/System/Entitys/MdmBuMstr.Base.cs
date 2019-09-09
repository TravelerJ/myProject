using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.System.Entitys
{
    /// <summary>
    /// 机构主表
    /// </summary>
    public partial class MdmBuMstr : Entity<string> {       

        /// <summary>
        /// 业务单元名称
        /// </summary>
        [Required(ErrorMessage = "业务单元名称不能为空")]
        [StringLength( 200, ErrorMessage = "业务单元名称输入过长，不能超过200位" )]
        public virtual string BU_NAME { get; set; }
        /// <summary>
        /// 业务单元简称
        /// </summary>
        [Required(ErrorMessage = "业务单元简称不能为空")]
        [StringLength( 60, ErrorMessage = "业务单元简称输入过长，不能超过60位" )]
        public virtual string BU_SHORT_NAME { get; set; }
        /// <summary>
        /// 业务单元注册名
        /// </summary>
        [StringLength( 100, ErrorMessage = "业务单元注册名输入过长，不能超过100位" )]
        public virtual string BU_REGISTERED_NAME { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]
        public virtual string BG_NO { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        [StringLength( 20, ErrorMessage = "电话号码输入过长，不能超过20位" )]
        public virtual string BU_PHONE { get; set; }
        /// <summary>
        /// 业务单元类型
        /// </summary>
        [Required(ErrorMessage = "业务单元类型不能为空")]
        public virtual long BU_TYPE { get; set; }
        /// <summary>
        /// 业务单元实物面积
        /// </summary>
        public virtual decimal? BU_AREA { get; set; }
        /// <summary>
        /// 工位数
        /// </summary>
        public virtual long? STATION_COUNT { get; set; }
        /// <summary>
        /// 经营品牌
        /// </summary>
        [StringLength( 200, ErrorMessage = "经营品牌输入过长，不能超过200位" )]
        public virtual string BU_BRAND { get; set; }
        /// <summary>
        /// 开店日期
        /// </summary>
        public virtual DateTime? OPEN_DATE { get; set; }
        /// <summary>
        /// 开单类型
        /// </summary>
        [StringLength( 20, ErrorMessage = "开单类型输入过长，不能超过20位" )]
        public virtual string OPEN_TYPE { get; set; }
        /// <summary>
        /// 业务单元层级
        /// </summary>
        public virtual long? BU_LEVEL { get; set; }
        /// <summary>
        /// 地址省
        /// </summary>
        [StringLength( 100, ErrorMessage = "地址省输入过长，不能超过100位" )]
        public virtual string BU_ADDR_PROVINCE { get; set; }
        /// <summary>
        /// 地址市
        /// </summary>
        [StringLength( 50, ErrorMessage = "地址市输入过长，不能超过50位" )]
        public virtual string BU_ADDR_CITY { get; set; }
        /// <summary>
        /// 地址区
        /// </summary>
        [StringLength( 50, ErrorMessage = "地址区输入过长，不能超过50位" )]
        public virtual string BU_ADDR_DISTRICT { get; set; }
        /// <summary>
        /// 地址详情
        /// </summary>
        [StringLength( 100, ErrorMessage = "地址详情输入过长，不能超过100位" )]
        public virtual string BU_ADDR { get; set; }
        /// <summary>
        /// 记忆码
        /// </summary>
        [StringLength( 50, ErrorMessage = "记忆码输入过长，不能超过50位" )]
        public virtual string MNEMONIC_CODE { get; set; }
        /// <summary>
        /// 业务单元状态
        /// </summary>
        [Required(ErrorMessage = "业务单元状态不能为空")]
        public virtual long BU_STATUS { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Required(ErrorMessage = "创建人不能为空")]
        public virtual decimal CREATE_PSN { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        [Required(ErrorMessage = "创建日期不能为空")]
        public virtual DateTime CREATE_DATE { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        [Required(ErrorMessage = "更新人不能为空")]
        public virtual decimal UPDATE_PSN { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        [Required(ErrorMessage = "更新日期不能为空")]
        public virtual DateTime UPDATE_DATE { get; set; }
        /// <summary>
        /// 创建机构代码
        /// </summary>
        [Required(ErrorMessage = "创建机构代码不能为空")]
        [StringLength( 50, ErrorMessage = "创建机构代码输入过长，不能超过50位" )]
        public virtual string CREATE_ORG_NO { get; set; }
        /// <summary>
        /// 未定义10
        /// </summary>
        [StringLength( 100, ErrorMessage = "未定义10输入过长，不能超过100位" )]
        public virtual string UDF10 { get; set; }
        /// <summary>
        /// 未定义1
        /// </summary>
        [StringLength( 100, ErrorMessage = "未定义1输入过长，不能超过100位" )]
        public virtual string UDF1 { get; set; }
        /// <summary>
        /// 未定义2
        /// </summary>
        [StringLength( 100, ErrorMessage = "未定义2输入过长，不能超过100位" )]
        public virtual string UDF2 { get; set; }
        /// <summary>
        /// 未定义3
        /// </summary>
        [StringLength( 100, ErrorMessage = "未定义3输入过长，不能超过100位" )]
        public virtual string UDF3 { get; set; }
        /// <summary>
        /// 未定义4
        /// </summary>
        [StringLength( 100, ErrorMessage = "未定义4输入过长，不能超过100位" )]
        public virtual string UDF4 { get; set; }
        /// <summary>
        /// 未定义5
        /// </summary>
        [StringLength( 100, ErrorMessage = "未定义5输入过长，不能超过100位" )]
        public virtual string UDF5 { get; set; }
        /// <summary>
        /// 未定义6
        /// </summary>
        [StringLength( 100, ErrorMessage = "未定义6输入过长，不能超过100位" )]
        public virtual string UDF6 { get; set; }
        /// <summary>
        /// 未定义7
        /// </summary>
        [StringLength( 100, ErrorMessage = "未定义7输入过长，不能超过100位" )]
        public virtual string UDF7 { get; set; }
        /// <summary>
        /// 未定义8
        /// </summary>
        [StringLength( 100, ErrorMessage = "未定义8输入过长，不能超过100位" )]
        public virtual string UDF8 { get; set; }
        /// <summary>
        /// 未定义9
        /// </summary>
        [StringLength( 100, ErrorMessage = "未定义9输入过长，不能超过100位" )]
        public virtual string UDF9 { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        public virtual decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// ERP数据接口路径
        /// </summary>
        [StringLength( 4000, ErrorMessage = "ERP数据接口路径输入过长，不能超过4000位" )]
        public virtual string ERP_API_URL { get; set; }
        /// <summary>
        /// ERP机构代码
        /// </summary>
        [StringLength( 50, ErrorMessage = "ERP机构代码输入过长，不能超过50位" )]
        public virtual string ERP_ORG_NO { get; set; }
        /// <summary>
        /// APP接口URL
        /// </summary>
        [StringLength( 4000, ErrorMessage = "APP接口URL输入过长，不能超过4000位" )]
        public virtual string APP_API_URL { get; set; }
        /// <summary>
        /// 经营品牌
        /// </summary>
        [StringLength( 200, ErrorMessage = "经营品牌输入过长，不能超过200位" )]
        public virtual string BRAND_NO { get; set; }
        /// <summary>
        /// 经营品牌名称
        /// </summary>
        [StringLength( 500, ErrorMessage = "经营品牌名称输入过长，不能超过500位" )]
        public virtual string BRAND_NAME { get; set; }
        /// <summary>
        /// 机构密钥
        /// </summary>
        [StringLength( 100, ErrorMessage = "机构密钥输入过长，不能超过100位" )]
        public virtual string BU_KEY { get; set; }
        /// <summary>
        /// 业务下属单元编号
        /// </summary>
        [StringLength( 4000, ErrorMessage = "业务下属单元编号输入过长，不能超过4000位" )]
        public virtual string BU_BRANCH_NOS { get; set; }
        /// <summary>
        /// 上级机构代码
        /// </summary>
        [StringLength( 50, ErrorMessage = "上级机构代码输入过长，不能超过50位" )]
        public virtual string PARENT_BU_NO { get; set; }
        /// <summary>
        /// 上级机构名称
        /// </summary>
        [StringLength( 100, ErrorMessage = "上级机构名称输入过长，不能超过100位" )]
        public virtual string PARENT_BU_NAME { get; set; }
        /// <summary>
        /// 请求路径
        /// </summary>
        [StringLength( 200, ErrorMessage = "请求路径输入过长，不能超过200位" )]
        public virtual string USR_QRCODE_PATH { get; set; }
        /// <summary>
        /// 经营品牌ID
        /// </summary>
        [StringLength( 500, ErrorMessage = "经营品牌ID输入过长，不能超过500位" )]
        public virtual string CARBRAND_IDS { get; set; }
        /// <summary>
        /// 热门车系ID
        /// </summary>
        [StringLength( 500, ErrorMessage = "热门车系ID输入过长，不能超过500位" )]
        public virtual string CARCLASS_IDS { get; set; }
        /// <summary>
        /// 车系编码
        /// </summary>
        [StringLength( 300, ErrorMessage = "车系编码输入过长，不能超过300位" )]
        public virtual string CARCLASS_NO { get; set; }
        /// <summary>
        /// 车系名称
        /// </summary>
        [StringLength( 500, ErrorMessage = "车系名称输入过长，不能超过500位" )]
        public virtual string CARCLASS_NAME { get; set; }
    }
}