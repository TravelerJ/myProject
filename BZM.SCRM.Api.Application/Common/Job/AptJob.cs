using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.Quartz;
using BT.BPMLIVE.Common._IO;
using BZM.SCRM.Domain.Common.RabbitMq;
using BZM.SCRM.Domain.Common.Redis;
using BZM.SCRM.Domain.Common.ReportModels;
using BZM.SCRM.Domain.Common.Request;
using BZM.SCRM.Domain.Common.Util;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Quartz;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SCRM.Domain.ServiceManagement.Entitys;
using SCRM.Domain.ServiceManagement.Repositories;
using SCRM.Domain.System.Entitys;
using SCRM.Domain.System.Repositories;
using SCRM.Domain.WeChatPlatform.Entitys;
using SCRM.Domain.WeChatPlatform.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BZM.SCRM.Application.Common.Job
{
    /// <summary>
    /// 预约任务
    /// </summary>
    public class AptJob: JobBase, ITransientDependency
    {
        private static EventingBasicConsumer consumber;
        /// <summary>
        /// redis
        /// </summary>
        private readonly RedisHelper _redisHelper;
        /// <summary>
        /// 微信helper
        /// </summary>
        private readonly WxHelper _wxHelper;
        /// <summary>
        /// 短信helper
        /// </summary>
        private readonly SmsHelper _smsHelper;
        /// <summary>
        /// MqHelper
        /// </summary>
        private readonly MqHelper _mqHelper;
        /// <summary>
        /// abp自定义事务
        /// </summary>
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        /// <summary>
        /// 预约仓储
        /// </summary>
        private readonly ICrmAptMstrRepository _crmAptMstrRepository;
        /// <summary>
        /// 机构仓储
        /// </summary>
        private readonly IMdmBuMstrRepository _mdmBuMstrRepository;
        /// <summary>
        /// 粉丝仓储
        /// </summary>
        private readonly ISysUsrWctRepository _sysUsrWctRepository;
        /// <summary>
        /// 用户仓储
        /// </summary>
        private readonly ISysUsrMstrRepository _sysUsrMstrRepository;
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="redisHelper">redis</param>
        /// <param name="wxHelper">微信helper</param>
        /// <param name="unitOfWorkManager">abp自定义事务</param>
        /// <param name="crmAptMstrRepository">预约仓储</param>
        /// <param name="mdmBuMstrRepository">机构仓储</param>
        /// <param name="sysUsrWctRepository">粉丝仓储</param>
        /// <param name="sysUsrMstrRepository">用户仓储</param>
        /// <param name="smsHelper">短信helper</param>
        /// <param name="configuration">配置</param>
        /// <param name="mqHelper">mqHelper</param>
        public AptJob(RedisHelper redisHelper, WxHelper wxHelper,
            IUnitOfWorkManager unitOfWorkManager, ICrmAptMstrRepository crmAptMstrRepository,
            IMdmBuMstrRepository mdmBuMstrRepository, ISysUsrWctRepository sysUsrWctRepository,
            ISysUsrMstrRepository sysUsrMstrRepository, SmsHelper smsHelper,
            IConfiguration configuration, MqHelper mqHelper)
        {
            _redisHelper = redisHelper;
            _wxHelper = wxHelper;
            _unitOfWorkManager = unitOfWorkManager;
            _crmAptMstrRepository = crmAptMstrRepository;
            _mdmBuMstrRepository = mdmBuMstrRepository;
            _sysUsrWctRepository = sysUsrWctRepository;
            _sysUsrMstrRepository = sysUsrMstrRepository;
            _smsHelper = smsHelper;
            _configuration = configuration;
            _mqHelper = mqHelper;
        }
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() =>
            {
                ExcuteCustomerApt();
            });
        }
        /// <summary>
        /// 处理队列预约消息
        /// </summary>
        public void ExcuteCustomerApt()
        {
            var log = new Log("ExcuteCustomerApt");
            var aptQueue = _configuration["AptQueue"];
            try
            {
                using (var channel =_mqHelper.GetConnection().CreateModel())
                {
                    channel.QueueDeclare(aptQueue, true, false, false, null);
                    consumber = new EventingBasicConsumer(channel);
                    channel.BasicQos(0, 1, false);
                    consumber.Received += (sender, c) =>
                    {
                        try
                        {                      
                            var apt = JsonConvert.DeserializeObject<AptInfo>(Encoding.UTF8.GetString(c.Body));
                            var config = _wxHelper.GetBasConfig(apt.BG_NO);
                            var redisNum = Convert.ToInt32(config.REDIS_NUM);
                            var key = apt.orgNo + "-" + apt.APT_CLASS + "-" + apt.CUS_PHONE_NO + "-" + apt.APT_DATE.ToString("yyyy-MM-dd") + "-" + apt.APT_TIMESPAN;
                            var redis = _redisHelper.GetRedisClient(redisNum);
                            var flag = _redisHelper.GetRedisClient(redisNum).Incr(key);
                            log = new Log("ExcuteCustomerApt/" + apt.BG_NO + "");
                            log.Write("开始处理队列消息");
                            redis.Expire(key, 120);
                            if (flag == 1)//用户的第一次请求,为有效请求
                            {
                                var aptNum = Convert.ToInt32(redis.GetValue(apt.orgNo + "-" + apt.APT_CLASS + "-" + apt.APT_DATE.ToString("yyyy-MM-dd") + "-" + apt.APT_TIMESPAN));
                                if (aptNum > 0 || apt.aptConfigNum == 0)
                                {
                                    log.Write("客户预约手机号:" + apt.CUS_PHONE_NO + "");
                                    var ret = InsertCRM_APT_Info(apt, log);
                                    if (!ret)
                                    {
                                        log.Write("客户:" + apt.CUS_PHONE_NO + ",预约失败");
                                    }
                                    else
                                    {
                                        log.Write("客户:" + apt.CUS_PHONE_NO + ",预约成功");
                                        if (aptNum != 0)
                                        {
                                            aptNum = aptNum - 1;
                                            redis.Set(apt.orgNo + "-" + apt.APT_CLASS + "-" + apt.APT_DATE.ToString("yyyy-MM-dd") + "-" + apt.APT_TIMESPAN, aptNum);
                                            log.Write("更改预约设置人数：" + aptNum + "");
                                        }
                                    }
                                }
                                else
                                {
                                    var ret = WxToErrMessage(apt, log);
                                    if (!ret)
                                    {
                                        log.Write("客户:" + apt.CUS_PHONE_NO + ",消息推送失败");
                                    }
                                    log.Write("预约人数已满");
                                }



                            }
                            //用户的N次请求,为无效请求
                            channel.BasicAck(c.DeliveryTag, false);
                        }
                        catch (Exception ex)
                        {
                            log.Write(ex.Message);
                        }
                    };
                    channel.BasicConsume(aptQueue, false, consumber);

                    System.Threading.Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                log.Write("队列初始化异常:" + ex.Message + "");
            }
        }

        /// <summary>
        /// 新增预约信息
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        public bool InsertCRM_APT_Info(AptInfo obj, Log log)
        {
            var pk = _wxHelper.CreatePK("APT");
            bool ret = true;
            using (var unitOfWork = _unitOfWorkManager.Begin(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    var apt = new CrmAptMstr();
                    apt.Id = pk;
                    apt.APT_NO = pk;//预约单号
                    apt.APT_TYPE = "主动";
                    apt.APT_CLASS = obj.APT_CLASS;
                    apt.APT_CHANNEL = "微信";
                    apt.CUS_NAME = obj.NAME;//客户姓名
                    apt.UDF1 = obj.SEX;//性别
                    apt.CUS_NO = obj.CUS_NO;
                    apt.CUS_PHONE_NO = obj.CUS_PHONE_NO;
                    apt.UDF2 = obj.MILEAGE;
                    apt.UDF3 = obj.BRAND_NAME;//品牌
                    apt.UDF4 = obj.CARCLASS_NAME;//车系
                    apt.UDF5 = obj.CARTYPE_NAME;//车型
                    apt.UDF6 = obj.CARTYPEDET_NAME;//车型细分
                    apt.VIN = obj.VIN;//vin码
                    apt.CAR_ID = obj.CAR_ID;//车牌号
                    apt.UDF8 = obj.BU_NAME;//门店名称
                    apt.UDF9 = obj.DISCOUNT;//工时折扣
                    apt.UDF10 = obj.APT_PROJECT;//预约项目
                    apt.APT_DATE = obj.APT_DATE;
                    apt.APT_TIMESPAN = obj.APT_TIMESPAN;//时段
                    apt.IS_SA_APPOINT = 0;
                    apt.SERVICE_DESK = obj.CONSULTANT_NAME;
                    apt.APT_BU_NO = obj.orgNo;
                    apt.APT_STATUS = "未完成";
                    apt.APT_RMK = obj.APT_RMK;
                    apt.CREATE_ORG_NO = obj.orgNo;
                    apt.CREATE_PSN = obj.BPM_USRID;
                    apt.CREATE_DATE = DateTime.Now;
                    apt.UPDATE_PSN = obj.BPM_USRID;
                    apt.UPDATE_DATE = DateTime.Now;
                    apt.DEL_FLAG = 1;
                    apt.BG_NO = obj.BG_NO;
                    apt.BOOKING_TYPE = obj.APT_TYPE;
                    apt.OPENID = obj.openId;
                    _crmAptMstrRepository.Insert(apt);
                    SysUsrMstr userInfo = new SysUsrMstr();
                    var basInfo = _wxHelper.GetBasConfig(obj.BG_NO);
                    if (obj.APT_TYPE == 1)//售前
                    {


                        if (basInfo != null)
                        {
                            if (basInfo.IS_IRIS == 1)//对接iris
                            {
                                //预约试驾调用iris接口
                                string url = basInfo.IRIS_APT_URL;
                                log.Write("url:" + url + "");
                                Dictionary<string, object> dic = new Dictionary<string, object>();

                                //obj.APT_TIMESPAN; 预约时间段解析
                                string[] arr = obj.APT_TIMESPAN.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                                string aptDate = obj.APT_DATE.ToString("yyyy-MM-dd");
                                string startTime = aptDate + " " + arr[0];
                                string endTime = aptDate + " " + arr[1];

                                dic.Add("appCode", "iris");
                                dic.Add("custName", obj.NAME);
                                dic.Add("custSex", obj.SEX == "女" ? 0 : 1);
                                dic.Add("custMobile", obj.CUS_PHONE_NO);
                                dic.Add("startTime", startTime);
                                dic.Add("endTime", endTime);
                                dic.Add("storeCode", obj.orgNo);
                                dic.Add("brandCode", obj.BRAND_CODE);
                                dic.Add("brandName", obj.BRAND_NAME);
                                dic.Add("seriesCode", obj.CARCLASS_CODE);
                                dic.Add("seriesName", obj.CARCLASS_NAME);
                                dic.Add("carType", obj.CARTYPE_CODE);
                                dic.Add("carCode", obj.CARTYPEDET_CODE);
                                dic.Add("displayName", obj.CARTYPEDET_NAME);

                                string json = JsonConvert.SerializeObject(dic);
                                string result = IrisHelper.RequestIrisApi(url, basInfo.IRIS_CHAT_URL, json, log);
                                log.Write("预约试驾推送Iris接口结果：" + result);

                                var code = JObject.Parse(result)["code"] + "";
                                obj.APT_RMK = code == "fail" ? "预约试驾推送Iris失败" : obj.APT_RMK;
                                //推送微信公众号模板消息
                                if (code == "fail")
                                {
                                    ret = false;
                                    ret = WxToMessage(obj, basInfo.APT_URL, code, log);
                                }
                                else
                                {
                                    ret = SendAptSuccessMessage(obj, basInfo.APT_URL, log);
                                }
                            }
                            else
                            {
                                if (basInfo.IS_SEND_MSG == 1)
                                {
                                    ret = GetWxUsrAptInfo(obj, basInfo, log, ref userInfo);
                                    if (!ret)
                                    {
                                        return ret;
                                    }
                                    ret = _smsHelper.SendMessage(obj, userInfo.USR_MOBILE, basInfo, log);
                                    if (!ret)
                                    {
                                        log.Write("发送短消息失败");
                                    }
                                    //推送微信公众号模板消息
                                    ret = SendAptSuccessMessage(obj, basInfo.APT_URL, log);
                                    if (!ret)
                                    {
                                        log.Write("发送模板消息失败");
                                    }

                                }
                                else
                                {
                                    //推送微信公众号模板消息
                                    ret = SendAptSuccessMessage(obj, basInfo.APT_URL, log);
                                }
                            }
                        }
                        else
                        {
                            ret = false;
                            log.Write("请先维护基础配置");
                            return ret;
                        }

                    }
                    else if (obj.APT_TYPE == 2)//售后
                    {
                        if (basInfo.IS_TOERP == 1)
                        {
                            ret = AptToErp(basInfo, obj, log);
                        }
                        else if (basInfo.IS_BZT == 1)
                        {
                            ret = PushAptInfoToOdm(basInfo, obj, log);
                        }
                        if (ret)
                        {
                            if (basInfo == null)
                            {
                                ret = false;
                                log.Write("请先维护基础配置");
                                return ret;
                            }
                            if (basInfo.IS_SEND_MSG == 1)
                            {
                                ret = GetWxUsrAptInfo(obj, basInfo, log, ref userInfo);
                                if (!ret)
                                {
                                    return ret;
                                }
                                ret = _smsHelper.SendMessage(obj, userInfo.USR_MOBILE, basInfo, log);
                                if (!ret)
                                {
                                    log.Write("发送短消息失败");
                                }
                                ret = SendAptSuccessMessage(obj, basInfo.APT_URL, log);
                                if (!ret)
                                {
                                    log.Write("发送模板消息失败");
                                }
                            }
                            else
                            {
                                ret = SendAptSuccessMessage(obj, basInfo.APT_URL, log);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ret = false;
                    log.Write("预约服务-" + ex.Message + "");
                    return ret;
                }
                unitOfWork.Complete();
            }


            return ret;
        }

        /// <summary>
        /// 预约服务-预约推送ERP
        /// </summary>
        /// <param name="config"></param>
        /// <param name="apt"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        public bool AptToErp(WctBasConfig config, AptInfo apt, Log log)
        {
            var creator = config.CREATOR;
            var tDate = apt.APT_DATE.ToString("yyyy-MM-dd");
            var dic = new Dictionary<string, object>();
            dic.Add("storeNo", apt.orgNo);
            dic.Add("cusNo", apt.CUS_NO);
            dic.Add("appointmentMode", "微信");
            dic.Add("appointmentSource", apt.APT_CLASS);
            dic.Add("appointmentType", "主动预约");
            dic.Add("receiveHead", apt.USR_ID);
            dic.Add("Creator", creator);
            dic.Add("appointmentDate", Convert.ToDateTime(tDate));
            dic.Add("Consigner", apt.NAME);
            dic.Add("consignerPhone", apt.CUS_PHONE_NO);
            dic.Add("Remark", apt.APT_RMK);
            dic.Add("carId", apt.CAR_ID);
            dic.Add("Vin", apt.VIN);
            dic.Add("AppointmentPeriod", apt.APT_TIMESPAN);
            dic.Add("WorkingHoursDiscount", string.IsNullOrEmpty(apt.DISCOUNT) ? "" : (Convert.ToDouble(apt.DISCOUNT) / 10) + "");
            dic.Add("appointmentProject", apt.APT_PROJECT);
            var json = JsonConvert.SerializeObject(dic);
            var url = "";
            var msg = "";
            var getUrl = _wxHelper.GetErpApiUrl(apt.orgNo, ref url, ref msg);
            if (!getUrl)
            {
                log.Write("getUrl:" + msg + "");
                return false;
            }
            var result = HttpRequest.ErpRequestApi(json, "CRM/SaveAfterSaleAppointMentInfo", url, apt.orgNo);
            JObject jo = (JObject)JsonConvert.DeserializeObject(result);
            if (!Convert.ToBoolean(jo["IsSuccess"]))
            {
                log.Write("AptToErp:" + jo["msg"].ToString() + "");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 推送预约单到odm
        /// </summary>
        /// <param name="basConfig"></param>
        /// <param name="aptInfo"></param>
        /// <param name="log"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        private bool PushAptInfoToOdm(WctBasConfig basConfig, AptInfo aptInfo, Log log, string method = "CrmAptMstr/SaveCrmAptMstrInfo")
        {
            string url = basConfig.IBZT_URL + method;
            string msg = "";
            string token = OdmCarRequest.GetToken(basConfig, ref msg);

            CrmAptInputModel crmAptInputModel = new CrmAptInputModel()
            {
                CusNo = aptInfo.CUS_NO,
                CusName = aptInfo.NAME,
                CusMobile = aptInfo.CUS_PHONE_NO,
                CusSex = string.IsNullOrEmpty(aptInfo.SEX) ? "3" : aptInfo.SEX,
                OpenId = aptInfo.openId,
                AptClass = aptInfo.APT_CLASS,
                AptDate = aptInfo.APT_DATE,
                AptTimeSpan = aptInfo.APT_TIMESPAN,
                AptItem = aptInfo.APT_PROJECT,
                AptContent = aptInfo.APT_RMK,
                CarId = aptInfo.CAR_ID,
                Vin = aptInfo.VIN,
                BuNo = aptInfo.orgNo,
                ScrmAptNo = aptInfo.APT_TYPE.ToString()
            };

            string json = JsonConvert.SerializeObject(crmAptInputModel);
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Authorization", token);
            string result = HttpRequest.Post(url, json, dic);

            var data = Newtonsoft.Json.Linq.JObject.Parse(result)["Data"] + "";
            var code = Newtonsoft.Json.Linq.JObject.Parse(result)["Code"] + "";
            msg = Newtonsoft.Json.Linq.JObject.Parse(result)["Message"] + "";
            if (code == "1")
            {
                return true;
            }
            log.Write(msg);
            return false;
        }

        /// <summary>
        /// 分配预约专员
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="basInfo"></param>
        /// <param name="log"></param>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool GetWxUsrAptInfo(AptInfo obj, WctBasConfig basInfo, Log log, ref SysUsrMstr userInfo)
        {
            bool ret = true;
            try
            {
                var usrList = new List<SysUsrMstr>();
                var job = obj.APT_TYPE == 1 ? basInfo.SALE_APT : basInfo.AFTER_SALE_APT;
                var salescode = "";
                //查询微信粉丝信息
                string where = string.Format(" OPEN_ID='{0}' and BG_NO='{1}' and FOLLOW_STATUS=1 and DEL_FLAG=1", obj.openId, obj.BG_NO);
                var wctInfo = _sysUsrWctRepository.FirstOrDefault(c => c.OPEN_ID == obj.openId && c.BG_NO == obj.BG_NO && c.DEL_FLAG == 1);
                if (wctInfo == null)
                {
                    ret = false;
                    log.Write("该粉丝信息不存在或未关注公众号！");
                    return ret;
                }
                var sql = string.Format("ORG_NO='{0}' and DEL_FLAG=1", obj.orgNo);
                usrList = _sysUsrMstrRepository.GetAllList(c => c.ORG_NO == obj.orgNo && c.USR_TYPE == "2" && c.DEL_FLAG == 1);
                //未绑定预约专员
                if (string.IsNullOrEmpty(obj.APT_TYPE == 1 ? wctInfo.CUS_SVC_CODE : wctInfo.AFTER_SALE_CODE))
                {
                    //绑定销售顾问
                    userInfo = GetAptUser(usrList, wctInfo, job);
                    if (userInfo != null)
                    {
                        log.Write("绑定成功");
                    }
                    else
                    {
                        log.Write("绑定失败");
                        ret = false;
                        return ret;
                    }
                    salescode = userInfo.ERP_EMP_ID;//赋值预约专员erp编码
                }
                else
                {
                    //查询绑定的预约专员是否存在   
                    salescode = obj.APT_TYPE == 1 ? wctInfo.CUS_SVC_CODE : wctInfo.AFTER_SALE_CODE;
                    userInfo = usrList.Where(c => c.ERP_EMP_ID == salescode && c.USR_JOB == job).FirstOrDefault();
                    if (userInfo == null)
                    {
                        //重新绑定销售顾问
                        userInfo = GetAptUser(usrList, wctInfo, job);
                        if (userInfo != null)
                        {
                            log.Write("更新绑定成功");
                        }
                        else
                        {
                            log.Write("更新绑定失败");
                            ret = false;
                            return ret;
                        }
                        salescode = userInfo.ERP_EMP_ID;
                    }
                    else
                    {
                        salescode = userInfo.ERP_EMP_ID;
                        log.Write("该粉丝已绑定预约专员");
                    }
                }
                if (obj.APT_TYPE == 1 && wctInfo.CUS_SVC_CODE != salescode)
                {
                    wctInfo.CUS_SVC_CODE = salescode;
                    _sysUsrWctRepository.Update(wctInfo);
                }
                if (obj.APT_TYPE == 2 && wctInfo.AFTER_SALE_CODE != salescode)
                {
                    wctInfo.AFTER_SALE_CODE = salescode;
                    _sysUsrWctRepository.Update(wctInfo);
                }

            }
            catch (Exception ex)
            {
                log.Write("" + ex.Message + "");
            }
            return ret;
        }

        /// <summary>
        /// 绑定预约专员
        /// </summary>
        /// <param name="userList"></param>
        /// <param name="wctInfo"></param>
        /// <param name="usrJob"></param>
        /// <returns></returns>
        public static SysUsrMstr GetAptUser(List<SysUsrMstr> userList, SysUsrWct wctInfo, string usrJob)
        {
            var list = userList.Where(c => c.USR_JOB == usrJob).ToList();
            if (list.Count == 0)
            {
                return null;
            }
            Random random = new Random();
            int i = random.Next(list.Count);
            SysUsrMstr userInfo = list[i];

            return userInfo;
        }

        /// <summary>
        /// 推送预约成功消息至微信
        /// </summary>
        /// <param name="apt"></param>
        /// <param name="url"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        public bool SendAptSuccessMessage(AptInfo apt, string url, Log log)
        {

            var buInfo = _mdmBuMstrRepository.FirstOrDefault(c => c.Id == apt.orgNo);
            if (buInfo == null)
            {
                log.Write("该门店不存在");
                return false;
            }
            if (string.IsNullOrEmpty(buInfo.BU_PHONE))
            {
                log.Write("请先维护门店电话");
                return false;
            }

            var first = "您好,您已预约成功!\r\n";
            var remark = "\r\n请在约定时间内准时到店,\n超时将不保留工位,如需更改时间,\n请重新预约或拨打客服电话" + buInfo.BU_PHONE + "";
            var tDate = apt.APT_DATE.ToString("yyyy-MM-dd") + " " + apt.APT_TIMESPAN;
            var dic = new Dictionary<string, object>();
            dic.Add("first", first);
            dic.Add("cusName", apt.NAME);
            dic.Add("aptServiceName", apt.APT_TYPE == 1 ? "试驾" : apt.APT_PROJECT);
            dic.Add("aptDate", tDate);
            dic.Add("mobile", apt.CUS_PHONE_NO);
            dic.Add("orgNo", apt.orgNo);
            dic.Add("orgName", apt.BU_NAME);
            dic.Add("url", url);
            dic.Add("openId", apt.openId);
            dic.Add("remark", remark);
            dic.Add("bgNo", apt.BG_NO);
            string json = JsonConvert.SerializeObject(dic);
            var ret = SendAptSuccessMessageInfo(json, log);
            return ret;
        }

        /// 推送预约消息至微信
        /// </summary>
        /// <param name="apt"></param>
        /// <param name="url"></param>
        /// <param name="code"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        public bool WxToMessage(AptInfo apt, string url, string code, Log log)
        {
            var tDate = apt.APT_DATE.ToString("yyyy-MM-dd") + " " + apt.APT_TIMESPAN;
            var dic = new Dictionary<string, object>();
            dic.Add("name", apt.APT_CLASS);
            dic.Add("orgNo", apt.orgNo);
            dic.Add("url", url);
            dic.Add("time", tDate);
            dic.Add("openId", apt.openId);
            dic.Add("remark", "备注:" + apt.APT_RMK + "");
            switch (code)
            {
                case "success":
                    dic.Add("result", "已预约!");
                    break;
                case "fail":
                    dic.Add("result", "预约失败!");
                    break;
                default:
                    dic.Add("result", "预约失败!");
                    break;
            }

            string json = JsonConvert.SerializeObject(dic);
            var ret = SendAptMessage(json, log);
            return ret;
        }

        /// <summary>
        /// 发送预约模版消息
        /// </summary>
        /// <param name="json"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        public bool SendAptMessage(string json, Log log)
        {
            try
            {
                #region 解析入参
                var param = new AptMessageInput();
                param = JsonConvert.DeserializeObject<AptMessageInput>(json);
                #endregion

                #region 绑定数据
                string linkUrl = param.url;
                #endregion

                #region biz
                //为模版中的各属性赋值
                var templateData = new AptTemplateData()
                {
                    name = new TemplateDataItem(param.name, "#000000"),
                    time = new TemplateDataItem(param.time, "#000000"),
                    result = new TemplateDataItem(param.result, "#000000"),
                    remark = new TemplateDataItem(param.remark, "#CD0000")
                };
                var paInfo = _wxHelper.GetPaInfo(1, c => c.PA_ID_NO == param.orgNo, param.bgNo);
                if (paInfo == null)
                {
                    log.Write("未找到该接口公众号信息");
                    return false;
                }
                if (string.IsNullOrEmpty(paInfo.UDF3))
                {
                    log.Write("请先维护模版id");
                    return false;
                }
                string access_token = "";
                var getToken = _wxHelper.GetAccessToken(paInfo, param.bgNo);
                if (!getToken.IsSuccess)
                {
                    log.Write(getToken.msg);
                    return false;
                }
                WxJsonResult sendResult = _wxHelper.SendTemplateMessage(access_token, param.openId, paInfo.UDF3, linkUrl, templateData, null);
                //发送成功
                if (sendResult.errcode.ToString() == "请求成功")
                {
                    return true;
                }
                else
                {
                    log.Write("推送预约消息失败," + sendResult.errmsg + "");
                    return false;
                }
                #endregion
            }
            catch (Exception ex)
            {
                log.Write("预约推送," + ex.Message + "");
                return false;
            }
        }

        /// <summary>
        /// 发送预约成功模版消息
        /// </summary>
        /// <param name="json"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        public bool SendAptSuccessMessageInfo(string json, Log log)
        {
            try
            {
                #region 解析入参
                AptTemplateInfo param = new AptTemplateInfo();
                param = JsonConvert.DeserializeObject<AptTemplateInfo>(json);
                #endregion

                #region 绑定数据
                string linkUrl = param.url;
                #endregion

                #region biz
                //为模版中的各属性赋值
                var templateData = new AptSuccessTemplateData()
                {
                    first = new TemplateDataItem(param.first, "#3A5FCD"),
                    keyword1 = new TemplateDataItem(param.aptServiceName, "#000000"),
                    keyword2 = new TemplateDataItem(param.aptDate, "#000000"),
                    keyword3 = new TemplateDataItem(param.cusName, "#000000"),
                    keyword4 = new TemplateDataItem(param.mobile, "#000000"),
                    keyword5 = new TemplateDataItem(param.orgName, "#000000"),
                    remark = new TemplateDataItem(param.remark, "#CD0000")
                };
                var paInfo = _wxHelper.GetPaInfo(1, c => c.PA_ID_NO == param.orgNo,param.bgNo);
                if (paInfo == null)
                {
                    log.Write("未找到该接口公众号信息");
                    return false;
                }
                if (string.IsNullOrEmpty(paInfo.PA_TEMPLATE_APT))
                {
                    log.Write("请先维护模版id");
                    return false;
                }
                string access_token = "";
                var getToken = _wxHelper.GetAccessToken(paInfo, paInfo.BG_NO);
                if (!getToken.IsSuccess)
                {
                    log.Write(getToken.msg);
                    return false;
                }
                access_token = getToken.result;
                WxJsonResult sendResult = _wxHelper.SendTemplateMessage(access_token, param.openId, paInfo.PA_TEMPLATE_APT, linkUrl, templateData, null);
                //发送成功
                if (sendResult.errcode.ToString() == "请求成功")
                {
                    return true;
                }
                else
                {
                    log.Write("推送预约消息失败," + sendResult.errmsg + "");
                    return false;
                }
                #endregion
            }
            catch (Exception ex)
            {
                log.Write("预约推送," + ex.Message + "");
                return false;
            }
        }

        /// <summary>
        /// 推送异常消息提醒
        /// </summary>
        /// <param name="apt"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        public bool WxToErrMessage(AptInfo apt, Log log)
        {
            var tDate = apt.APT_DATE.ToString("yyyy-MM-dd") + " " + apt.APT_TIMESPAN;
            var dic = new Dictionary<string, object>();
            dic.Add("name", apt.APT_CLASS);
            dic.Add("result", "预约失败!");
            dic.Add("orgNo", apt.orgNo);
            dic.Add("remark", "\r\n该时段预约人数已满,请您更改预约时段,\n给您带来的不便非常抱歉");
            dic.Add("openId", apt.openId);
            dic.Add("url", "");
            dic.Add("time", tDate);
            string json = JsonConvert.SerializeObject(dic);
            var ret = SendAptMessage(json, log);
            return ret;
        }
    }
}
