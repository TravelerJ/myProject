
using Abp.Specifications;
using AutoMapper.Configuration;
using BZM.SCRM.Application;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Domain.Common.ReportModels;
using BZM.SCRM.Domain.Common.Util;
using SCRM.Application.WeChatPlatform.Contracts;
using SCRM.Application.WeChatPlatform.Dtos;
using SCRM.Domain.WeChatPlatform.Entitys;
using SCRM.Domain.WeChatPlatform.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Microsoft.Extensions.Configuration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using Newtonsoft.Json;
using BZM.SCRM.Domain.Common.Request;
using System.Text;

namespace SCRM.Application.WeChatPlatform.Impl
{
    /// <summary>
    /// 微信菜单服务
    /// </summary>
    public class WctMenuMstrService : SCRMAppServiceBase, IWctMenuMstrService {
    
        /// <summary>
        /// 微信菜单仓储
        /// </summary>
        private readonly IWctMenuMstrRepository _wctMenuMstrRepository;
        /// <summary>
        /// 公共字段helper
        /// </summary>
        private readonly InitHelper _initHelper;
        /// <summary>
        /// 微信hepler
        /// </summary>
        private readonly WxHelper _wxHelper;
        /// <summary>
        /// 配置管理器
        /// </summary>
        public IConfiguration _configuration { get; }
        /// <summary>
        /// 初始化服务
        /// </summary>
        public WctMenuMstrService( IWctMenuMstrRepository wctMenuMstrRepository,
            InitHelper initHelper, WxHelper wxHelper,
            IConfiguration configuration) {
            _wctMenuMstrRepository = wctMenuMstrRepository;
            _initHelper = initHelper;
            _wxHelper = wxHelper;
            _configuration = configuration;
        }

        /// <summary>
        /// 保存微信菜单信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ReturnMsg SaveWxMenuInfo(WctMenuMstrDto dto)
        {
            var rm = new ReturnMsg();
            var entity = new WctMenuMstr();
            var isOk = CheckWxMenuInfo(dto, rm);
            if (!isOk.IsSuccess)
                return rm;
            if (string.IsNullOrEmpty(dto.Id))
            {
                dto.Id = Guid.NewGuid().ToString("N");
                dto.MENU_KEY = Guid.NewGuid().ToString("N");
                dto.MENU_ID_NO = AbpSession.ORG_NO;
                _initHelper.InitAdd(dto, AbpSession.USR_ID, AbpSession.ORG_NO, AbpSession.BG_NO);
                entity = dto.ToEntity();
                _wctMenuMstrRepository.Insert(entity);
            }
            else
            {
                _initHelper.InitUpdate(dto, AbpSession.USR_ID);
                entity = dto.ToEntity();
                _wctMenuMstrRepository.Update(entity);
            }
            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 校验微信菜单信息
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="rm"></param>
        /// <returns></returns>
        public ReturnMsg CheckWxMenuInfo(WctMenuMstrDto dto, ReturnMsg rm)
        {
            if (string.IsNullOrEmpty(dto.MENU_NAME))
            {
                rm.IsSuccess = false;
                rm.msg = "请输入菜单名称";
                return rm;
            }
            if (dto.MENU_ISSECOND == null)
            {
                rm.IsSuccess = false;
                rm.msg = "请选择是否支持二级菜单";
                return rm;
            }
            var nameByte = Encoding.Default.GetBytes(dto.MENU_NAME).Length;
            if (dto.MENU_LEVEL == 1 && nameByte > 12)
            {
                rm.IsSuccess = false;
                rm.msg = "一级菜单不能超过12个字节";
                return rm;
            }
            if (dto.MENU_LEVEL == 2 && nameByte > 16)
            {
                rm.IsSuccess = false;
                rm.msg = "二级菜单不能超过24个字节";
                return rm;
            }
            if (dto.MENU_DISPLAYINDEX == 0)
            {
                rm.IsSuccess = false;
                rm.msg = "请选择菜单序号";
                return rm;
            }
            if (dto.MENU_BELINKEDTYPE == null || dto.MENU_BELINKEDTYPE == 0)
            {
                rm.IsSuccess = false;
                rm.msg = "请选择菜单关联项";
                return rm;
            }
            if (dto.MENU_BELINKEDTYPE == 1 && string.IsNullOrEmpty(dto.MENU_MENUURL))
            {
                rm.IsSuccess = false;
                rm.msg = "请填写链接地址";
                return rm;
            }
            if (dto.MENU_BELINKEDTYPE == 2)
            {
                if (dto.MENU_MATERIALTYPEID == null)
                {
                    rm.IsSuccess = false;
                    rm.msg = "请选择回复消息类型";
                    return rm;
                }
                if (dto.MENU_MATERIALTYPEID == 0)
                {
                    if (string.IsNullOrEmpty(dto.MENU_TEXT))
                    {
                        rm.IsSuccess = false;
                        rm.msg = "请填写文本内容";
                        return rm;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(dto.MATERIAL_IDS))
                    {
                        rm.IsSuccess = false;
                        rm.msg = "请选择图文素材";
                        return rm;
                    }
                    var list = dto.MATERIAL_IDS.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    if (list.Count > 8)
                    {
                        rm.IsSuccess = false;
                        rm.msg = "图文素材不可超过8个";
                        return rm;
                    }
                }

            }
            if (dto.MENU_BELINKEDTYPE == 3)
            {
                if (string.IsNullOrEmpty(dto.MENU_MODULEID))
                {
                    rm.IsSuccess = false;
                    rm.msg = "请选择关联系统模块";
                    return rm;
                }
                if (string.IsNullOrEmpty(dto.MENU_MENUURL))
                {
                    rm.IsSuccess = false;
                    rm.msg = "系统模块地址不可为空";
                    return rm;
                }
            }
            if (dto.MENU_BELINKEDTYPE == 4)
            {
                if (string.IsNullOrEmpty(dto.MENU_APPLET_ID))
                {
                    rm.IsSuccess = false;
                    rm.msg = "请选择关联小程序";
                    return rm;
                }
                if (string.IsNullOrEmpty(dto.MENU_APPLET_APP_ID))
                {
                    rm.IsSuccess = false;
                    rm.msg = "关联小程序appId不可为空";
                    return rm;
                }
                if (string.IsNullOrEmpty(dto.MENU_MENUURL))
                {
                    rm.IsSuccess = false;
                    rm.msg = "小程序地址不可为空";
                    return rm;
                }
            }
            if (string.IsNullOrEmpty(dto.MENU_TYPE))
            {
                rm.IsSuccess = false;
                rm.msg = "菜单类型有误";
                return rm;
            }
            if (dto.MENU_LEVEL == 0)
            {
                rm.IsSuccess = false;
                rm.msg = "菜单层级有误";
                return rm;
            }
            if (dto.MENU_LEVEL == 2 && string.IsNullOrEmpty(dto.MENU_PARENTID))
            {
                rm.IsSuccess = false;
                rm.msg = "父级菜单不可为空";
                return rm;
            }
            var result = new List<WctMenuMstr>();
            result = GetExpressionResult(dto.Id, c => c.MENU_NAME == dto.MENU_NAME && c.MENU_LEVEL == dto.MENU_LEVEL && c.DEL_FLAG == 1 && c.MENU_STATUS == 1);
            if (result.Count > 0)
            {
                rm.IsSuccess = false;
                rm.msg = "该菜单名称已存在";
                return rm;
            }
            if (string.IsNullOrEmpty(dto.MENU_PARENTID))
            {
                result = GetExpressionResult(dto.Id, c => c.MENU_DISPLAYINDEX == dto.MENU_DISPLAYINDEX && c.MENU_LEVEL == dto.MENU_LEVEL && c.DEL_FLAG == 1 && c.MENU_STATUS == 1);
            }
            else
            {
                result = GetExpressionResult(dto.Id, c =>c.MENU_PARENTID==dto.MENU_PARENTID&&c.MENU_DISPLAYINDEX == dto.MENU_DISPLAYINDEX && c.MENU_LEVEL == dto.MENU_LEVEL && c.DEL_FLAG == 1 && c.MENU_STATUS == 1);
            }
            if (result.Count > 0)
            {

                rm.IsSuccess = false;
                rm.msg = "该序号已存在";
                return rm;
            }
            if (dto.MENU_LEVEL == 1)
            {
                result = GetExpressionResult(dto.Id, c => c.MENU_LEVEL == dto.MENU_LEVEL && c.DEL_FLAG == 1 && c.MENU_STATUS == 1);
                if (dto.MENU_LEVEL == 1 && result.Count >= 3)
                {

                    rm.IsSuccess = false;
                    rm.msg = "一级菜单最多创建3个";
                    return rm;
                }
            }
            else
            {
                result = GetExpressionResult(dto.Id, c => c.MENU_PARENTID == dto.MENU_PARENTID && c.MENU_LEVEL == dto.MENU_LEVEL && c.DEL_FLAG == 1 && c.MENU_STATUS == 1);
                if (dto.MENU_LEVEL == 2 && result.Count >= 5)
                {

                    rm.IsSuccess = false;
                    rm.msg = "二级菜单最多创建5个";
                    return rm;
                }
            }
            
            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 统一处理查询
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="expression1"></param>
        /// <returns></returns>
        public List<WctMenuMstr> GetExpressionResult(string Id, Expression<Func<WctMenuMstr, bool>> expression1)
        {
            Expression<Func<WctMenuMstr, bool>> expression = c => string.IsNullOrEmpty(Id) ? c.DEL_FLAG == 1 && c.CREATE_ORG_NO == AbpSession.ORG_NO :
               c.Id != Id & c.DEL_FLAG == 1 && c.CREATE_ORG_NO == AbpSession.ORG_NO;
            return _wctMenuMstrRepository.GetAllList(expression.And(expression1));
        }

        /// <summary>
        /// 微信菜单发布
        /// </summary>
        /// <returns></returns>
        public ReturnMsg PublishWxMenu()
        {
            var rm = new ReturnMsg();
            var dic = new Dictionary<string, object>();
            var arr = new Dictionary<string, object>[3];
            var paInfo = _wxHelper.GetPaInfo(1, c => c.PA_ID_NO == AbpSession.ORG_NO, AbpSession.BG_NO);
            if (paInfo == null)
            {
                rm.IsSuccess = false;
                rm.msg = "公众号信息不存在";
                return rm;
            }
            var requestToken = _wxHelper.GetAccessToken(paInfo, AbpSession.BG_NO);
            if (!requestToken.IsSuccess)
                return rm;
            var allList = _wctMenuMstrRepository.GetAllList(c => c.DEL_FLAG == 1 && c.MENU_STATUS == 1 && c.MENU_ID_NO == AbpSession.ORG_NO).OrderBy(c => c.MENU_DISPLAYINDEX).ToList();
            if (allList.Count == 0)
            {
                rm.IsSuccess = false;
                rm.msg = "菜单查询异常";
                return rm;
            }
            var firstWxMenuList = allList.Where(c => c.MENU_LEVEL == 1).ToList();
            var i = 0;
            foreach (var item in firstWxMenuList)
            {
                var menu = new Dictionary<string, object>();
                if (item.MENU_ISSECOND == 0)
                {
                    switch (item.MENU_TYPE)
                    {
                        case "view":
                            menu.Add("type", "view");
                            menu.Add("name", item.MENU_NAME);
                            menu.Add("url", GetModuleUrl(item.MENU_MENUURL, paInfo.PA_APPID));
                            break;
                        case "click":
                            menu.Add("type", "click");
                            menu.Add("name", item.MENU_NAME);
                            menu.Add("key", "Text_" + item.MENU_KEY);
                            break;
                        case "miniprogram":
                            menu.Add("type", "miniprogram");
                            menu.Add("name", item.MENU_NAME);
                            menu.Add("url", "http://mp.weixin.qq.com");
                            menu.Add("appid", item.MENU_APPLET_APP_ID);
                            menu.Add("pagepath", item.MENU_MENUURL);
                            break;
                    }
                    arr[i] = menu;
                }
                else if (item.MENU_ISSECOND == 1)
                {
                    var menu1 = new Dictionary<string, object>();                    
                    menu1.Add("name", item.MENU_NAME);
                    var secondWxMenuList = allList.Where(c => c.MENU_PARENTID == item.Id).ToList();
                    var subArr = new Dictionary<string, object>[secondWxMenuList.Count];
                    var m = 0;
                    foreach (var sec in secondWxMenuList)
                    {
                        var menu2 = new Dictionary<string, object>();
                        switch (sec.MENU_TYPE)
                        {
                            case "view":
                                menu2.Add("type", "view");
                                menu2.Add("name", sec.MENU_NAME);
                                menu2.Add("url", GetModuleUrl(sec.MENU_MENUURL, paInfo.PA_APPID));
                                break;
                            case "click":
                                menu2.Add("type", "click");
                                menu2.Add("name", sec.MENU_NAME);
                                menu2.Add("key", "Text_" + sec.MENU_KEY);
                                break;
                            case "miniprogram":
                                menu2.Add("type", "miniprogram");
                                menu2.Add("name", sec.MENU_NAME);
                                menu2.Add("url", "http://mp.weixin.qq.com");
                                menu2.Add("appid", sec.MENU_APPLET_APP_ID);
                                menu2.Add("pagepath", sec.MENU_MENUURL);
                                break;
                        }
                        subArr[m] = menu2;
                        m++;
                    }
                    menu1.Add("sub_button", subArr);
                    arr[i] = menu1;
                }
                i++;
            }
            dic.Add("button", arr);
            var json= JsonConvert.SerializeObject(dic);
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}", requestToken.result);
            var publishMenu = HttpRequest.Post(url, json);
            var result = JsonConvert.DeserializeObject<TagObj>(publishMenu);
            if (result.errcode != "0")
            {
                rm.IsSuccess = false;
                rm.msg = "发布菜单失败," + result.errmsg;
                return rm;
            }
            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 合成微信菜单跳转地址
        /// </summary>
        /// <param name="url"></param>
        /// <param name="appId"></param>
        /// <returns></returns>
        public string GetModuleUrl(string url, string appId)
        {
            var auth = "";
            var returnUrl = _configuration["AuthWx:Url"];
            returnUrl = returnUrl + "appId=" + appId + "";
            auth = "https://open.weixin.qq.com/connect/oauth2/authorize?appId="
                   + appId + "&redirect_uri="
                   + returnUrl + "&response_type=code&scope=snsapi_base&state="
                   + HttpUtility.UrlEncode(url) + "#wechat_redirect";
            return auth;
        }
    }
}
