
using BZM.SCRM.Application;
using BZM.SCRM.Domain.Common;
using SCRM.Application.ServiceManagement.Contracts;
using SCRM.Application.ServiceManagement.Dtos;
using SCRM.Domain.ServiceManagement.Entitys;
using SCRM.Domain.ServiceManagement.Repositories;
using System;

namespace SCRM.Application.ServiceManagement.Impl
{
    /// <summary>
    /// 服务
    /// </summary>
    public class StoreAdvertiseMstrService : SCRMAppServiceBase, IStoreAdvertiseMstrService
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly IStoreAdvertiseMstrRepository _storeAdvertiseMstrRepository;

        private InitHelper _initHelper;

        /// <summary>
        /// 初始化服务
        /// </summary>
        public StoreAdvertiseMstrService(IStoreAdvertiseMstrRepository storeAdvertiseMstrRepository, InitHelper initHelper)
        {
            _storeAdvertiseMstrRepository = storeAdvertiseMstrRepository;
            _initHelper = initHelper;
        }

        /// <summary>
        /// 新增保险续保/门店宣传
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public StoreAdvertiseMstr InsertAdvertise(StoreAdvertiseMstrDto dto)
        {
            StoreAdvertiseMstr mstr = null;
            try
            {
                if (!EnableStoreAdvertiseList(Convert.ToInt32(dto.ADVERTISE_CATEGORY)))
                {
                    return null;
                }

                if (string.IsNullOrEmpty(dto.Id))
                {
                    //新增
                    dto.Id = Guid.NewGuid().ToString("N");
                    _initHelper.InitAdd(dto, AbpSession.USR_ID, AbpSession.ORG_NO, AbpSession.BG_NO);
                    mstr = _storeAdvertiseMstrRepository.Insert(dto.ToEntity());
                }
                else
                {
                    //修改
                    _initHelper.InitUpdate(dto, AbpSession.USR_ID);
                    mstr = _storeAdvertiseMstrRepository.Update(dto.ToEntity());
                }
                return mstr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 启用/禁用宣传
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StoreAdvertiseMstr EnableAdvertise(string id)
        {
            var entity = _storeAdvertiseMstrRepository.Get(id);

            if (entity != null)
            {
                //启用状态(1.启用,2.禁用)
                if (entity.ADVERTISE_STATUS == 1)
                {
                    entity.ADVERTISE_STATUS = 2;
                }
                else if (entity.ADVERTISE_STATUS == 2)
                {
                    entity.ADVERTISE_STATUS = 1;

                    //将已启用的文件改为禁用
                    if (!EnableStoreAdvertiseList(int.Parse(entity.ADVERTISE_CATEGORY + "")))
                    {
                        return null;
                    }
                }
                return _storeAdvertiseMstrRepository.Update(entity);
            }
            return null;
        }

        /// <summary>
        /// 禁用门店该分类下的宣传
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private bool EnableStoreAdvertiseList(int type)
        {
            try
            {
                var list = _storeAdvertiseMstrRepository.GetAllList(m => m.DEL_FLAG == 1 && m.ADVERTISE_STATUS == 1 && m.ADVERTISE_CATEGORY == type && m.BU_NO == AbpSession.ORG_NO);

                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        item.ADVERTISE_STATUS = 2;
                        _storeAdvertiseMstrRepository.Update(item);
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 删除宣传
        /// </summary>
        /// <param name="ids"></param>
        public void DeleteAdvertise(string ids)
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
                    var entity = _storeAdvertiseMstrRepository.Get(arr[i]);
                    _storeAdvertiseMstrRepository.Delete(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
