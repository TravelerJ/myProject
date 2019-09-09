
using BZM.SCRM.Application;
using BZM.SCRM.Domain.Common;
using BZM.SCRM.Domain.Common.Util;
using BZM.SCRM.Domain.ServiceManagement.ReportModels;
using SCRM.Application.ServiceManagement.Contracts;
using SCRM.Application.ServiceManagement.Dtos;
using SCRM.Domain.ServiceManagement.Entitys;
using SCRM.Domain.ServiceManagement.Repositories;
using SCRM.Domain.System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SCRM.Application.ServiceManagement.Impl
{
    /// <summary>
    /// 服务
    /// </summary>
    public class AptDriveConfigService : SCRMAppServiceBase, IAptDriveConfigService
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly IAptDriveConfigRepository _aptDriveConfigRepository;

        private readonly IMdmBuMstrRepository _mdmBuMstrRepository;

        private readonly WxHelper _wxHelper;

        private readonly InitHelper _initHelper;

        /// <summary>
        /// 初始化服务
        /// </summary>
        public AptDriveConfigService(IAptDriveConfigRepository aptDriveConfigRepository, WxHelper wxHelper, IMdmBuMstrRepository mdmBuMstrRepository, InitHelper initHelper)
        {
            _aptDriveConfigRepository = aptDriveConfigRepository;
            _mdmBuMstrRepository = mdmBuMstrRepository;
            _wxHelper = wxHelper;
            _initHelper = initHelper;
        }

        /// <summary>
        /// 预约试驾车型数据
        /// </summary>
        /// <returns></returns>
        public List<CarInfoModel> GetAptDriveCarList()
        {
            var list = new List<CarInfoModel>();
            var newList = new List<CarInfoModel>();
            var buInfo = _mdmBuMstrRepository.Get(AbpSession.ORG_NO);
            if (buInfo != null)
            {
                if (string.IsNullOrEmpty(buInfo.CARBRAND_IDS))
                {
                    throw new Exception("尚未设置门店经营品牌!");
                }
                string msg = "";

                List<CarInfoModel> carlist = CarHelper.GetCarInfo(AbpSession.BG_NO, 1, ref msg);//所有品牌信息
                List<string> brandIds = buInfo.CARBRAND_IDS.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                List<CarInfoModel> carbrandList = carlist.Where(m => brandIds.Contains(m.CLASS_ID)).ToList();
                list.AddRange(carbrandList);

                List<CarInfoModel> carclassList = CarHelper.GetCarInfo(AbpSession.BG_NO, 2, ref msg, buInfo.CARBRAND_IDS);
                list.AddRange(carclassList);

                var classIds = (from item in carclassList select item.CLASS_ID).ToList();
                List<CarInfoModel> cartypeList = CarHelper.GetCarInfo(AbpSession.BG_NO, 3, ref msg);
                cartypeList = cartypeList.Where(m => classIds.Contains(m.PARENT_ID)).ToList();
                list.AddRange(cartypeList);

                var typeIds = (from item in cartypeList select item.CLASS_ID).ToArray();
                List<CarInfoModel> carsubtypeList = CarHelper.GetCarInfo(AbpSession.BG_NO, 4, ref msg);
                carsubtypeList = carsubtypeList.Where(m => typeIds.Contains(m.PARENT_ID)).ToList();
                list.AddRange(carsubtypeList);

                //处理选中的车型
                List<AptDriveConfig> driveList = _aptDriveConfigRepository.GetAllList(m => m.BU_NO == AbpSession.ORG_NO);
                if (driveList.Count>0)
                {
                    foreach (var item in driveList)
                    {
                        var config = carsubtypeList.Where(c => c.CLASS_ID == item.SUBTYPE_ID).FirstOrDefault();
                        if (config != null)
                            config.IsCheck = true;
                    }
                }

                foreach (var item in carbrandList)
                {
                    var result = GetCarInfos(item, list);
                    newList.Add(result);

                }

            }
            else
            {
                throw new Exception("暂未查到该门店!");
            }

            return newList;
        }

        /// <summary>
        /// 获取车辆数据
        /// </summary>
        /// <param name="item"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public CarInfoModel GetCarInfos(CarInfoModel item, List<CarInfoModel> list)
        {
            var childList = list.Where(c => c.PARENT_ID == item.CLASS_ID).ToList();
            item.ChildInfo = childList;
            foreach (var child in childList)
            {
                GetCarInfos(child, list);
            }
            return item;
        }

        /// <summary>
        /// 核对车型细分是否选中
        /// </summary>
        private void CarSubtypeIsCheck(List<CarInfoModel> carlist, List<string> list)
        {
            int? count = carlist?.Count;
            if (count == null)
            {
                throw new ArgumentNullException("车型数据为空！");
            }

            //查找交集
            var intersects = carlist.Where(m => list.Contains(m.CLASS_ID)).ToList();

            foreach (var item in carlist.Intersect(intersects))
            {
                item.IsCheck = true;
            }
        }

        /// <summary>
        /// 保存预约试驾车型数据
        /// </summary>
        /// <param name="dtos"></param>
        public void SaveDriveInfo(List<AptDriveConfigDto> dtos)
        {
            if (dtos?.Count > 0)
            {
                //删除已保存的车型数据
                var driveList = _aptDriveConfigRepository.GetAllList(m => m.BU_NO == AbpSession.ORG_NO);
                foreach (var item in driveList)
                {
                    _aptDriveConfigRepository.Delete(item);
                }

                //新增车型细分数据
                foreach (var item in dtos)
                {
                    _initHelper.InitAdd(item, AbpSession.USR_ID, AbpSession.ORG_NO, AbpSession.BG_NO);
                    item.Id = Guid.NewGuid().ToString("N");

                    _aptDriveConfigRepository.Insert(item.ToEntity());
                }
            }
            else
            {
                throw new Exception("未选择任何车型数据");
            }
        }
    }
}
