using Abp.Domain.Uow;
using AutoMapper.Configuration;
using BT.BPMLIVE.Common._IO;
using BZM.SCRM.Application;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Domain.Common.ReportModels;
using BZM.SCRM.Domain.System.ReportModels;
using BZM.SCRM.Infrastructure.CommonHelper;
using Newtonsoft.Json;
using SCRM.Application.System.Contracts;
using SCRM.Application.System.Dtos;
using SCRM.Domain.System.Entitys;
using SCRM.Domain.System.Queries;
using SCRM.Domain.System.Repositories;
using Spring.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Convert = System.Convert;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace SCRM.Application.System.Impl
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class SysUsrMstrService : SCRMAppServiceBase, ISysUsrMstrService {
    
        /// <summary>
        /// 用户仓储
        /// </summary>
        private readonly ISysUsrMstrRepository _sysUsrMstrRepository;
        /// <summary>
        /// 菜单仓储
        /// </summary>
        private readonly ISysNavTreeRepository _sysNavTreeRepository;
        /// <summary>
        /// 角色用户关系表
        /// </summary>
        private readonly ISysUsrAuthRepository _sysUsrAuthRepository;
        /// <summary>
        /// 公共字段helper
        /// </summary>
        private readonly InitHelper _initHelper;
        /// <summary>
        /// 配置管理器
        /// </summary>
        public IConfiguration _configuration { get; }
        /// <summary>
        /// 初始化服务
        /// </summary>
        public SysUsrMstrService( ISysUsrMstrRepository sysUsrMstrRepository,
            ISysNavTreeRepository sysNavTreeRepository,
            InitHelper initHelper,
            IConfiguration configuration,
            ISysUsrAuthRepository sysUsrAuthRepository) {
            _sysUsrMstrRepository = sysUsrMstrRepository;
            _sysNavTreeRepository = sysNavTreeRepository;
            _initHelper = initHelper;
            _configuration = configuration;
            _sysUsrAuthRepository = sysUsrAuthRepository;
        }

        /// <summary>
        /// web登录验证
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ReturnMsg Login(SysUsrMstrQuery query)
        {
            var rm = new ReturnMsg();

            try
            {
                query.USR_NAME.Trim();
                query.USR_PWD.Trim();
                var isCheck = CheckLoginInfo(query, ref rm);
                if (!isCheck)
                {
                    rm.code = 28600;
                    rm.IsSuccess = false;
                    return rm;
                }
                query.USR_PWD = Encrypt.Md5Hash(query.USR_PWD);
                var userInfo = _sysUsrMstrRepository.FirstOrDefault(c => c.USR_NAME == query.USR_NAME && c.USR_PWD == query.USR_PWD && c.USR_STATUS == 1 && c.DEL_FLAG == 1);
                if (userInfo != null && userInfo.Id > 0)
                {
                    var tree = _sysNavTreeRepository.GetSysUsrMstrNavTree(userInfo.Id);
                    var dic = new Dictionary<string, object>();
                    dic.Add("UserInfo", userInfo);
                    dic.Add("NavTree", tree);

                    rm.code = 28000;
                    rm.IsSuccess = true;
                    rm.msg = "登录成功";
                    rm.result = JsonConvert.SerializeObject(dic);

                    return rm;
                }
                else
                {
                    rm.code = 28600;
                    rm.IsSuccess = false;
                    rm.msg = "用户名或密码错误";
                    return rm;
                }
            }
            catch (Exception ex)
            {
                rm.code = 28600;
                rm.IsSuccess = false;
                rm.msg = ex.Message;
                return rm;
            }
            
        }

        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <returns></returns>
        public ReturnMsg GetSysUsrMstrNavTree()
        {
            var rm = new ReturnMsg();
            var tree = new List<SysUsrMstrNavTreeModel>();
            var list = new List<SysUsrMstrParentNavTree>();
            if (AbpSession.USR_TYPE == "9")
            {
                tree = _sysNavTreeRepository.GetSysUsrMstrNavTreeList();
            }
            else
            {
                tree = _sysNavTreeRepository.GetSysUsrMstrNavTree(AbpSession.USR_ID);
            }
            var paerntTree = tree.Where(c => c.NAV_PARENT_NO == "0").ToList();
            foreach(var item in paerntTree)
            {
                var model = new SysUsrMstrParentNavTree();
                model.NAV_NO = item.NAV_NO;
                model.NAV_NAME = item.NAV_NAME;
                model.ChildTree = tree.Where(c => c.NAV_PARENT_NO == item.NAV_NO).ToList();
                list.Add(model);
            }
            rm.code = 28000;
            rm.IsSuccess = true;
            rm.msg = "登录成功";
            rm.result = JsonConvert.SerializeObject(list);

            return rm;
        }

        /// <summary>
        /// 验证登录信息
        /// </summary>
        /// <param name="query"></param>
        /// <param name="rm"></param>
        /// <returns></returns>
        public bool CheckLoginInfo(SysUsrMstrQuery query,ref ReturnMsg rm)
        {
            if (string.IsNullOrEmpty(query.USR_NAME))
            {
                rm.msg = "请输入用户名";
                return false;
            }
            if (string.IsNullOrEmpty(query.USR_PWD))
            {
                rm.msg = "请输入密码";
                return false;
            }
            if (string.IsNullOrEmpty(query.code))
            {
                rm.msg = "请输入验证码";
                return false;
            }
            var vch = new CaptchaHelper();
            if (!vch.VerifyCode(query.cookie, query.code))
            {
                rm.msg = "验证码错误";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="orgNo"></param>
        /// <param name="bgNo"></param>
        /// <param name="bizType"></param>
        /// <returns></returns>
        public async Task<SysUsrMstrDto> Login(string userName,string password,string orgNo,string bgNo,string bizType)
        {
            var log = new Log("Login/" + orgNo + "");
            log.Write("userName:" + userName + ",password:" + password + "");
            var userInfo = new SysUsrMstr();
            try
            {
                userName = userName.Trim();
                password = password.Trim();
                userInfo = _sysUsrMstrRepository.FirstOrDefault(c => (c.USR_NAME == userName || c.USR_MOBILE == userName) && c.ORG_NO == orgNo && c.BG_NO == bgNo && c.USR_STATUS == 1 && c.DEL_FLAG == 1);                        
                if (userInfo != null && userInfo.Id > 0)
                {
                    if (bizType == "web")
                    {
                        password = Encrypt.Md5Hash(password);
                        if (userInfo.USR_PWD.Equals(password))
                        {
                            return userInfo.ToDto();
                        }
                        return null;
                    }
                    return userInfo.ToDto();                  
                }
                return null;
            }
            catch (Exception ex)
            {
                log.Write(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 保存员工信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ReturnMsg SaveSysUsrInfo(SysUsrMstrDto dto)
        {
            var rm = new ReturnMsg();
            var entity = new SysUsrMstr();
            var isOk = CheckSysUsrInfo(dto, rm);
            if (!isOk.IsSuccess)
                return rm;
            if (dto.Id == 0)
            {
                dto.USR_REG_DATE = DateTime.Now;
                _initHelper.InitAdd(dto, AbpSession.USR_ID, AbpSession.ORG_NO, AbpSession.BG_NO);
                entity = dto.ToEntity();
                _sysUsrMstrRepository.Insert(entity);
            }
            else
            {
                _initHelper.InitUpdate(dto, AbpSession.USR_ID);
                entity = dto.ToEntity();
                _sysUsrMstrRepository.Update(entity);
            }
            var userAuth = _sysUsrAuthRepository.GetAllList(c => c.USR_ID == dto.Id);
            if (userAuth.Count > 0)
            {
                _sysUsrAuthRepository.DelSysUsrAuthInfo(dto.Id.ToString());
            }
            if (!string.IsNullOrEmpty(dto.RoleIds))
            {
                var list = dto.RoleIds.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (var item in list)
                {
                    var auth = new SysUsrAuth();
                    auth.Id = Guid.NewGuid().ToString("N");
                    auth.USR_ID =(long)dto.Id;
                    auth.ROLE_ID = Convert.ToInt32(item);
                    _initHelper.InitAdd(auth, AbpSession.USR_ID, AbpSession.ORG_NO, AbpSession.BG_NO);
                    _sysUsrAuthRepository.Insert(auth);
                }
            }
            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 校验用户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="rm"></param>
        /// <returns></returns>
        public ReturnMsg CheckSysUsrInfo(SysUsrMstrDto dto, ReturnMsg rm)
        {
            if (string.IsNullOrEmpty(dto.USR_NAME))
            {
                rm.IsSuccess = false;
                rm.msg = "请输入用户名";
                return rm;
            }
            if (string.IsNullOrEmpty(dto.USR_PWD))
            {
                rm.IsSuccess = false;
                rm.msg = "请输入密码";
                return rm;
            }
            if (string.IsNullOrEmpty(dto.USR_MOBILE))
            {
                rm.IsSuccess = false;
                rm.msg = "请输入用户手机";
                return rm;
            }
            if (string.IsNullOrEmpty(dto.USR_TYPE))
            {
                rm.IsSuccess = false;
                rm.msg = "请选择账号类型";
                return rm;
            }
            if (string.IsNullOrEmpty(dto.USR_REAL_NAME))
            {
                rm.IsSuccess = false;
                rm.msg = "请输入真实姓名";
                return rm;
            }
            if (string.IsNullOrEmpty(dto.ERP_EMP_ID))
            {
                rm.IsSuccess = false;
                rm.msg = "请输入员工编码";
                return rm;
            }
            if (string.IsNullOrEmpty(dto.ORG_NO))
            {
                rm.IsSuccess = false;
                rm.msg = "请选择所属机构";
                return rm;
            }
            var result = new List<SysUsrMstr>();
            dto.USR_PWD = Encrypt.Md5Hash(dto.USR_PWD);
            result = dto.Id == 0 ? _sysUsrMstrRepository.GetAllList(c => c.USR_NAME == dto.USR_NAME && c.USR_PWD == dto.USR_PWD && c.DEL_FLAG == 1)
                : _sysUsrMstrRepository.GetAllList(c => c.USR_NAME == dto.USR_NAME && c.USR_PWD == dto.USR_PWD && c.Id != dto.Id & c.DEL_FLAG == 1);
            if (result.Count > 0)
            {
                rm.IsSuccess = false;
                rm.msg = "用户名/密码已存在,请重新输入";
                return rm;
            }
            result = dto.Id==0 ? _sysUsrMstrRepository.GetAllList(c => c.USR_MOBILE == dto.USR_MOBILE && c.DEL_FLAG == 1 && c.ORG_NO == dto.ORG_NO)
                : _sysUsrMstrRepository.GetAllList(c => c.USR_MOBILE == dto.USR_MOBILE && c.Id != dto.Id & c.DEL_FLAG == 1 && c.ORG_NO == dto.ORG_NO);
            if (result.Count > 0)
            {
                rm.IsSuccess = false;
                rm.msg = "该手机已存在,请重新输入";
                return rm;
            }
            result = dto.Id==0 ? _sysUsrMstrRepository.GetAllList(c => c.ERP_EMP_ID == dto.ERP_EMP_ID && c.DEL_FLAG == 1 && c.ORG_NO == dto.ORG_NO)
                : _sysUsrMstrRepository.GetAllList(c => c.ERP_EMP_ID == dto.ERP_EMP_ID && c.Id != dto.Id & c.DEL_FLAG == 1 && c.ORG_NO == dto.ORG_NO);
            if (result.Count > 0)
            {
                rm.IsSuccess = false;
                rm.msg = "该员工代码已存在,请重新输入";
                return rm;
            }
            rm.IsSuccess = true;

            return rm;
        }

        /// <summary>
        /// 批量删除员工信息
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public ReturnMsg DelSysUsrInfo(string userIds)
        {
            var rm = new ReturnMsg();
            if (string.IsNullOrEmpty(userIds))
            {
                rm.IsSuccess = false;
                rm.msg = "请选择要删除的员工信息";
                return rm;
            }
            _sysUsrMstrRepository.BatchDelSysUsrInfo(userIds);

            rm.IsSuccess = true;
            return rm;

        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ReturnMsg ResetPassWord(decimal? userId)
        {
            var rm = new ReturnMsg();
            if (userId == null)
            {
                rm.IsSuccess = false;
                rm.msg = "请选择需要重置密码的用户";
                return rm;
            }
            var user = _sysUsrMstrRepository.FirstOrDefault(c => c.Id == userId && c.DEL_FLAG==1);
            if (user == null)
            {
                rm.IsSuccess = false;
                rm.msg = "该用户不存在";
                return rm;
            }
            var password = _configuration["AppSettings:Pwd"];
            user.USR_PWD= Encrypt.Md5Hash(password);
            _initHelper.InitUpdate(user, AbpSession.USR_ID);
            _sysUsrMstrRepository.Update(user);
            rm.IsSuccess = true;

            return rm;
        }
    }
}
