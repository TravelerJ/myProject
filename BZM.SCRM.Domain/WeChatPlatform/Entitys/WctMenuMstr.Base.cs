using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace SCRM.Domain.WeChatPlatform.Entitys
{
    /// <summary>
    /// 微信菜单表
    /// </summary>
    public partial class WctMenuMstr : Entity<string> {       

        /// <summary>
        /// 组织机构编号	
        /// </summary>
        [Required(ErrorMessage = "组织机构编号不能为空")]
        [StringLength( 50, ErrorMessage = "组织机构编号输入过长，不能超过50位" )]
        public virtual string MENU_ID_NO { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Required(ErrorMessage = "菜单名称不能为空")]
        [StringLength( 50, ErrorMessage = "菜单名称输入过长，不能超过50位" )]
        public virtual string MENU_NAME { get; set; }
        /// <summary>
        /// 菜单key
        /// </summary>
        [Required(ErrorMessage = "菜单key不能为空")]
        [StringLength( 50, ErrorMessage = "菜单key输入过长，不能超过50位" )]
        public virtual string MENU_KEY { get; set; }
        /// <summary>
        /// 菜单类型
        /// </summary>
        [Required(ErrorMessage = "菜单类型不能为空")]
        [StringLength( 20, ErrorMessage = "菜单类型输入过长，不能超过20位" )]
        public virtual string MENU_TYPE { get; set; }
        /// <summary>
        /// 菜单层级
        /// </summary>
        [Required(ErrorMessage = "菜单层级不能为空")]
        public virtual long MENU_LEVEL { get; set; }
        /// <summary>
        /// 显示序列	
        /// </summary>
        [Required(ErrorMessage = "显示序列	不能为空")]
        public virtual long MENU_DISPLAYINDEX { get; set; }
        /// <summary>
        /// 回复消息类型ID
        /// </summary>
        public virtual long? MENU_MATERIALTYPEID { get; set; }
        /// <summary>
        /// 父级菜单编号
        /// </summary>
        [StringLength( 200, ErrorMessage = "父级菜单编号输入过长，不能超过200位" )]
        public virtual string MENU_PARENTID { get; set; }
        /// <summary>
        /// 回复文本内容
        /// </summary>
        [StringLength( 500, ErrorMessage = "回复文本内容输入过长，不能超过500位" )]
        public virtual string MENU_TEXT { get; set; }
        /// <summary>
        /// 菜单链接地址
        /// </summary>
        [StringLength( 500, ErrorMessage = "菜单链接地址输入过长，不能超过500位" )]
        public virtual string MENU_MENUURL { get; set; }
        /// <summary>
        /// 关联系统模块ID
        /// </summary>
        [StringLength( 50, ErrorMessage = "关联系统模块ID输入过长，不能超过50位" )]
        public virtual string MENU_MODULEID { get; set; }
        /// <summary>
        /// 关联模块页面配置
        /// </summary>
        [StringLength( 4000, ErrorMessage = "关联模块页面配置输入过长，不能超过4000位" )]
        public virtual string MENU_PAGEPARAMJSON { get; set; }
        /// <summary>
        /// 是否要求AUTH认证
        /// </summary>
        public virtual long? MENU_ISAUTH { get; set; }
        /// <summary>
        /// 状态标识0：删除1：启用2：禁用
        /// </summary>
        [Required(ErrorMessage = "状态标识0：删除1：启用2：禁用不能为空")]
        public virtual long MENU_STATUS { get; set; }
        /// <summary>
        /// 菜单关联类型
        /// </summary>
        public virtual long? MENU_BELINKEDTYPE { get; set; }
        /// <summary>
        /// 创建机构代码
        /// </summary>
        [Required(ErrorMessage = "创建机构代码不能为空")]
        [StringLength( 50, ErrorMessage = "创建机构代码输入过长，不能超过50位" )]
        public virtual string CREATE_ORG_NO { get; set; }
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
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF1 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF2 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF3 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF4 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF5 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF6 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF7 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF8 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF9 { get; set; }
        /// <summary>
        /// 未定义
        /// </summary>
        [StringLength( 50, ErrorMessage = "未定义输入过长，不能超过50位" )]
        public virtual string UDF10 { get; set; }
        /// <summary>
        /// 数据删除标志(1-有效/0-已删除)
        /// </summary>
        public virtual decimal? DEL_FLAG { get; set; }
        /// <summary>
        /// 图文素材主键集
        /// </summary>
        [StringLength( 400, ErrorMessage = "图文素材主键集输入过长，不能超过400位" )]
        public virtual string MATERIAL_IDS { get; set; }
        /// <summary>
        /// 微信图文素材ID
        /// </summary>
        [StringLength( 300, ErrorMessage = "微信图文素材ID输入过长，不能超过300位" )]
        public virtual string MEDIA_ID { get; set; }
        /// <summary>
        /// 集团编号
        /// </summary>
        [StringLength( 50, ErrorMessage = "集团编号输入过长，不能超过50位" )]
        public virtual string BG_NO { get; set; }
        /// <summary>
        /// 是否支持二级菜单
        /// </summary>
        public virtual decimal? MENU_ISSECOND { get; set; }
        /// <summary>
        /// 关联小程序id
        /// </summary>
        [StringLength(50, ErrorMessage = "关联小程序id输入过长，不能超过50位")]
        public virtual string MENU_APPLET_ID { get; set; }
        /// <summary>
        /// 关联小程序appid
        /// </summary>
        [StringLength(50, ErrorMessage = "关联小程序appid输入过长，不能超过50位")]
        public virtual string MENU_APPLET_APP_ID { get; set; }
    }
}