using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SCRM.Application.System.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MdmBuMstrDto : EntityDto<string> {    

        /// <summary>
        /// 业务单元名称
        /// </summary>
        [StringLength( 200, ErrorMessage = "业务单元名称输入过长，不能超过200位" )]         
        [Display( Name = "业务单元名称" )]        
        public string BU_NAME { get; set; }
        /// <summary>
        /// 业务单元简称
        /// </summary>
        [StringLength( 60, ErrorMessage = "业务单元简称输入过长，不能超过60位" )]         
        [Display( Name = "业务单元简称" )]        
        public string BU_SHORT_NAME { get; set; }
        /// <summary>
        /// 业务单元注册名
        /// </summary>
        [StringLength( 100, ErrorMessage = "业务单元注册名输入过长，不能超过100位" )]         
        [Display( Name = "业务单元注册名" )]        
        public string BU_REGISTERED_NAME { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]         
        [Display( Name = "集团编号" )]        
        public string BG_NO { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        [StringLength( 20, ErrorMessage = "电话号码输入过长，不能超过20位" )]         
        [Display( Name = "电话号码" )]        
        public string BU_PHONE { get; set; }
        /// <summary>
        /// 业务单元类型
        /// </summary>
                 
        [Display( Name = "业务单元类型" )]        
        public long BU_TYPE { get; set; }
        /// <summary>
        /// 业务单元实物面积
        /// </summary>
        [Display( Name = "业务单元实物面积" )]        
        public decimal? BU_AREA { get; set; }
        /// <summary>
        /// 工位数
        /// </summary>
        [Display( Name = "工位数" )]        
        public long? STATION_COUNT { get; set; }
        /// <summary>
        /// 经营品牌
        /// </summary>
        [StringLength( 200, ErrorMessage = "经营品牌输入过长，不能超过200位" )]         
        [Display( Name = "经营品牌" )]        
        public string BU_BRAND { get; set; }
        /// <summary>
        /// 开店日期
        /// </summary>
        [Display( Name = "开店日期" )]        
        public DateTime? OPEN_DATE { get; set; }
        /// <summary>
        /// 开单类型
        /// </summary>
        [StringLength( 20, ErrorMessage = "开单类型输入过长，不能超过20位" )]         
        [Display( Name = "开单类型" )]        
        public string OPEN_TYPE { get; set; }
        /// <summary>
        /// 业务单元层级
        /// </summary>
        [Display( Name = "业务单元层级" )]        
        public long? BU_LEVEL { get; set; }
        /// <summary>
        /// 地址省
        /// </summary>
        [StringLength( 100, ErrorMessage = "地址省输入过长，不能超过100位" )]         
        [Display( Name = "地址省" )]        
        public string BU_ADDR_PROVINCE { get; set; }
        /// <summary>
        /// 地址市
        /// </summary>
        [StringLength( 50, ErrorMessage = "地址市输入过长，不能超过50位" )]         
        [Display( Name = "地址市" )]        
        public string BU_ADDR_CITY { get; set; }
        /// <summary>
        /// 地址区
        /// </summary>
        [StringLength( 50, ErrorMessage = "地址区输入过长，不能超过50位" )]         
        [Display( Name = "地址区" )]        
        public string BU_ADDR_DISTRICT { get; set; }
        /// <summary>
        /// 地址详情
        /// </summary>
        [StringLength( 100, ErrorMessage = "地址详情输入过长，不能超过100位" )]         
        [Display( Name = "地址详情" )]        
        public string BU_ADDR { get; set; }
        /// <summary>
        /// 记忆码
        /// </summary>
        [StringLength( 50, ErrorMessage = "记忆码输入过长，不能超过50位" )]         
        [Display( Name = "记忆码" )]        
        public string MNEMONIC_CODE { get; set; }
        /// <summary>
        /// 业务单元状态
        /// </summary>
                 
        [Display( Name = "业务单元状态" )]        
        public long BU_STATUS { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
                 
        [Display( Name = "创建人" )]        
        public decimal CREATE_PSN { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
                 
        [Display( Name = "创建日期" )]        
        public DateTime CREATE_DATE { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
                 
        [Display( Name = "更新人" )]        
        public decimal UPDATE_PSN { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
                 
        [Display( Name = "更新日期" )]        
        public DateTime UPDATE_DATE { get; set; }
        /// <summary>
        /// 创建机构代码
        /// </summary>
        [StringLength( 50, ErrorMessage = "创建机构代码输入过长，不能超过50位" )]         
        [Display( Name = "创建机构代码" )]        
        public string CREATE_ORG_NO { get; set; }
        /// <summary>
        /// 未定义10
        /// </summary>
        [StringLength( 100, ErrorMessage = "未定义10输入过长，不能超过100位" )]         
        [Display( Name = "未定义10" )]        
        public string UDF10 { get; set; }
        /// <summary>
        /// 未定义1
        /// </summary>
        [StringLength( 100, ErrorMessage = "未定义1输入过长，不能超过100位" )]         
        [Display( Name = "未定义1" )]        
        public string UDF1 { get; set; }
        /// <summary>
        /// 未定义2
        /// </summary>
        [StringLength( 100, ErrorMessage = "未定义2输入过长，不能超过100位" )]         
        [Display( Name = "未定义2" )]        
        public string UDF2 { get; set; }
        /// <summary>
        /// 未定义3
        /// </summary>
        [StringLength( 100, ErrorMessage = "未定义3输入过长，不能超过100位" )]         
        [Display( Name = "未定义3" )]        
        public string UDF3 { get; set; }
        /// <summary>
        /// 未定义4
        /// </summary>
        [StringLength( 100, ErrorMessage = "未定义4输入过长，不能超过100位" )]         
        [Display( Name = "未定义4" )]        
        public string UDF4 { get; set; }
        /// <summary>
        /// 未定义5
        /// </summary>
        [StringLength( 100, ErrorMessage = "未定义5输入过长，不能超过100位" )]         
        [Display( Name = "未定义5" )]        
        public string UDF5 { get; set; }
        /// <summary>
        /// 未定义6
        /// </summary>
        [StringLength( 100, ErrorMessage = "未定义6输入过长，不能超过100位" )]         
        [Display( Name = "未定义6" )]        
        public string UDF6 { get; set; }
        /// <summary>
        /// 未定义7
        /// </summary>
        [StringLength( 100, ErrorMessage = "未定义7输入过长，不能超过100位" )]         
        [Display( Name = "未定义7" )]        
        public string UDF7 { get; set; }
        /// <summary>
        /// 未定义8
        /// </summary>
        [StringLength( 100, ErrorMessage = "未定义8输入过长，不能超过100位" )]         
        [Display( Name = "未定义8" )]        
        public string UDF8 { get; set; }
        /// <summary>
        /// 未定义9
        /// </summary>
        [StringLength( 100, ErrorMessage = "未定义9输入过长，不能超过100位" )]         
        [Display( Name = "未定义9" )]        
        public string UDF9 { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Display( Name = "数据删除标志(1-有效/0-已删除)" )]        
        public decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// ERP数据接口路径
        /// </summary>
        [StringLength( 4000, ErrorMessage = "ERP数据接口路径输入过长，不能超过4000位" )]         
        [Display( Name = "ERP数据接口路径" )]        
        public string ERP_API_URL { get; set; }
        /// <summary>
        /// ERP机构代码
        /// </summary>
        [StringLength( 50, ErrorMessage = "ERP机构代码输入过长，不能超过50位" )]         
        [Display( Name = "ERP机构代码" )]        
        public string ERP_ORG_NO { get; set; }
        /// <summary>
        /// APP接口URL
        /// </summary>
        [StringLength( 4000, ErrorMessage = "APP接口URL输入过长，不能超过4000位" )]         
        [Display( Name = "APP接口URL" )]        
        public string APP_API_URL { get; set; }
        /// <summary>
        /// 经营品牌
        /// </summary>
        [StringLength( 200, ErrorMessage = "经营品牌输入过长，不能超过200位" )]         
        [Display( Name = "经营品牌" )]        
        public string BRAND_NO { get; set; }
        /// <summary>
        /// 经营品牌名称
        /// </summary>
        [StringLength( 500, ErrorMessage = "经营品牌名称输入过长，不能超过500位" )]         
        [Display( Name = "经营品牌名称" )]        
        public string BRAND_NAME { get; set; }
        /// <summary>
        /// 机构密钥
        /// </summary>
        [StringLength( 100, ErrorMessage = "机构密钥输入过长，不能超过100位" )]         
        [Display( Name = "机构密钥" )]        
        public string BU_KEY { get; set; }
        /// <summary>
        /// 业务下属单元编号
        /// </summary>
        [StringLength( 4000, ErrorMessage = "业务下属单元编号输入过长，不能超过4000位" )]         
        [Display( Name = "业务下属单元编号" )]        
        public string BU_BRANCH_NOS { get; set; }
        /// <summary>
        /// 上级机构代码
        /// </summary>
        [StringLength( 50, ErrorMessage = "上级机构代码输入过长，不能超过50位" )]         
        [Display( Name = "上级机构代码" )]        
        public string PARENT_BU_NO { get; set; }
        /// <summary>
        /// 上级机构名称
        /// </summary>
        [StringLength( 100, ErrorMessage = "上级机构名称输入过长，不能超过100位" )]         
        [Display( Name = "上级机构名称" )]        
        public string PARENT_BU_NAME { get; set; }
        /// <summary>
        /// 请求路径
        /// </summary>
        [StringLength( 200, ErrorMessage = "请求路径输入过长，不能超过200位" )]         
        [Display( Name = "请求路径" )]        
        public string USR_QRCODE_PATH { get; set; }
        /// <summary>
        /// 经营品牌ID
        /// </summary>
        [StringLength( 500, ErrorMessage = "经营品牌ID输入过长，不能超过500位" )]         
        [Display( Name = "经营品牌ID" )]        
        public string CARBRAND_IDS { get; set; }
        /// <summary>
        /// 热门车系ID
        /// </summary>
        [StringLength( 500, ErrorMessage = "热门车系ID输入过长，不能超过500位" )]         
        [Display( Name = "热门车系ID" )]        
        public string CARCLASS_IDS { get; set; }
        /// <summary>
        /// 车系编码
        /// </summary>
        [StringLength( 300, ErrorMessage = "车系编码输入过长，不能超过300位" )]         
        [Display( Name = "车系编码" )]        
        public string CARCLASS_NO { get; set; }
        /// <summary>
        /// 车系名称
        /// </summary>
        [StringLength( 500, ErrorMessage = "车系名称输入过长，不能超过500位" )]         
        [Display( Name = "车系名称" )]        
        public string CARCLASS_NAME { get; set; }
        
    }
}