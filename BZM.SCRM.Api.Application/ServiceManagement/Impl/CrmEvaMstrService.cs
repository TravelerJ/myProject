
using BZM.SCRM.Application;
using SCRM.Application.ServiceManagement.Contracts;
using SCRM.Domain.ServiceManagement.Entitys;
using SCRM.Domain.ServiceManagement.Queries;
using SCRM.Domain.ServiceManagement.Repositories;
using System;

namespace SCRM.Application.ServiceManagement.Impl
{
    /// <summary>
    /// 服务
    /// </summary>
    public class CrmEvaMstrService : SCRMAppServiceBase, ICrmEvaMstrService
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly ICrmEvaMstrRepository _crmEvaMstrRepository;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public CrmEvaMstrService(ICrmEvaMstrRepository crmEvaMstrRepository)
        {
            _crmEvaMstrRepository = crmEvaMstrRepository;
        }

        /// <summary>
        /// 导出评价数据
        /// </summary>
        /// <param name="query"></param>
        public void ExportCrmEvaData(CrmEvaMstrQuery query) { }

        /// <summary>
        /// 回复评价
        /// </summary>
        /// <param name="evaContent">回复内容</param>
        /// <returns></returns>
        public CrmEvaMstr ReplyEvaInfo(string id, string evaContent)
        {
            try
            {
                var entity = _crmEvaMstrRepository.Get(id);
                if (entity != null)
                {
                    entity.UDF10 = evaContent;
                    entity.UPDATE_DATE = DateTime.Now;
                    entity.UPDATE_PSN = AbpSession.USR_ID;
                    return _crmEvaMstrRepository.Update(entity);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 删除评价
        /// </summary>
        public void DelCrmEvaInfo(string ids)
        {
            try
            {
                if (!string.IsNullOrEmpty(ids))
                {
                    string[] arr = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (arr?.Length > 0)
                    {
                        for (int i = 0; i < arr.Length; i++)
                        {
                            var entity = _crmEvaMstrRepository.Get(arr[i]);
                            _crmEvaMstrRepository.Delete(entity);
                        }
                    }
                }
                else
                {
                    throw new Exception("参数不能为空");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 回复消息
        /// </summary>
        public void SendMessage(string id, string evaContent) { }
    }
}
