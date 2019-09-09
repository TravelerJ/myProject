using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Spring.Domains.Repositories;

namespace SCRM.Domain.WeChatPlatform.Queries
{
    /// <summary>
    /// 
    /// </summary>
    [Description( "" )]
    public partial class WctMenuMstrQuery : Pager {     

        /// <summary>
        /// 主键	
        /// </summary>
        [Display(Name="主键")]
        public string MENU_ID { get; set; }
        /// <summary>
        /// 组织机构编号	
        /// </summary>
        [Display(Name="组织机构编号")]
        public string MENU_ID_NO { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Display(Name="菜单名称")]
        public string MENU_NAME { get; set; }
        /// <summary>
        /// 菜单key
        /// </summary>
        [Display(Name="菜单key")]
        public string MENU_KEY { get; set; }
        /// <summary>
        /// 菜单类型
        /// </summary>
        [Display(Name="菜单类型")]
        public string MENU_TYPE { get; set; }
        /// <summary>
        /// 菜单层级
        /// </summary>
        [Display(Name="菜单层级")]
        public long MENU_LEVEL { get; set; }
        /// <summary>
        /// 显示序列	
        /// </summary>
        [Display(Name="显示序列	")]
        public long MENU_DISPLAYINDEX { get; set; }
        /// <summary>
        /// 回复消息类型ID
        /// </summary>
        [Display(Name="回复消息类型ID")]
        public long? MENU_MATERIALTYPEID { get; set; }
        /// <summary>
        /// 父级菜单编号
        /// </summary>
        [Display(Name="父级菜单编号")]
        public string MENU_PARENTID { get; set; }
        /// <summary>
        /// 回复文本内容
        /// </summary>
        [Display(Name="回复文本内容")]
        public string MENU_TEXT { get; set; }
        /// <summary>
        /// 菜单链接地址
        /// </summary>
        [Display(Name="菜单链接地址")]
        public string MENU_MENUURL { get; set; }
        /// <summary>
        /// 关联系统模块ID
        /// </summary>
        [Display(Name="关联系统模块ID")]
        public string MENU_MODULEID { get; set; }
        /// <summary>
        /// 关联模块页面配置
        /// </summary>
        [Display(Name="关联模块页面配置")]
        public string MENU_PAGEPARAMJSON { get; set; }
        /// <summary>
        /// 是否要求AUTH认证
        /// </summary>
        [Display(Name="是否要求AUTH认证")]
        public long? MENU_ISAUTH { get; set; }
        /// <summary>
        /// 状态标识0：删除1：启用2：禁用
        /// </summary>
        [Display(Name="状态标识0：删除1：启用2：禁用")]
        public long MENU_STATUS { get; set; }
        /// <summary>
        /// 菜单关联类型(1链接2回复消息3系统模块4小程序)
        /// </summary>
        [Display(Name= "菜单关联类型(1链接2回复消息3系统模块4小程序)")]
        public long? MENU_BELINKEDTYPE { get; set; }
        /// <summary>
        /// 创建机构代码
        /// </summary>
        [Display(Name="创建机构代码")]
        public string CREATE_ORG_NO { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name="创建人")]
        public decimal CREATE_PSN { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        [Display(Name="创建日期")]
        public DateTime CREATE_DATE { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        [Display(Name="更新人")]
        public decimal UPDATE_PSN { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        [Display(Name="更新日期")]
        public DateTime UPDATE_DATE { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF1 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF2 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF3 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF4 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF5 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF6 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF7 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF8 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF9 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [Display(Name="未定义")]
        public string UDF10 { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        [Display(Name="数据删除标志(1-有效/0-已删除)")]
        public decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 图文素材主键集
        /// </summary>
        [Display(Name="图文素材主键集")]
        public string MATERIAL_IDS { get; set; }
        /// <summary>
        /// 微信图文素材ID
        /// </summary>
        [Display(Name="微信图文素材ID")]
        public string MEDIA_ID { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [Display(Name="集团编号")]
        public string BG_NO { get; set; }
        /// <summary>
        /// 是否支持二级菜单
        /// </summary>
        [Display(Name="是否支持二级菜单")]
        public decimal? MENU_ISSECOND { get; set; }
    }
}