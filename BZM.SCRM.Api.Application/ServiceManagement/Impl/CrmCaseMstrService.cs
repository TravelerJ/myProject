
using BZM.SCRM.Application;
using SCRM.Application.ServiceManagement.Contracts;
using SCRM.Domain.ServiceManagement.Repositories;
using System;

namespace SCRM.Application.ServiceManagement.Impl
{
    /// <summary>
    /// 服务
    /// </summary>
    public class CrmCaseMstrService : SCRMAppServiceBase, ICrmCaseMstrService
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly ICrmCaseMstrRepository _crmCaseMstrRepository;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public CrmCaseMstrService(ICrmCaseMstrRepository crmCaseMstrRepository)
        {
            _crmCaseMstrRepository = crmCaseMstrRepository;
        }

        /// <summary>
        /// 删除客户反馈信息
        /// </summary>
        /// <param name="ids"></param>
        public void DeleteCrmCaseInfo(string ids)
        {
            try
            {
                if (string.IsNullOrEmpty(ids))
                {
                    throw new Exception("id不允许为空");
                }

                string[] arr = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < arr.Length; i++)
                {
                    var entity = _crmCaseMstrRepository.Get(arr[i]);
                    _crmCaseMstrRepository.Delete(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
