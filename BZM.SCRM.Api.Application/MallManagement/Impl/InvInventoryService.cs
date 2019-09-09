
using BZM.SCRM.Application;
using BZM.SCRM.Domain.MallManagement.ReportModels;
using SCRM.Application.MallManagement.Contracts;
using SCRM.Application.MallManagement.Dtos;
using SCRM.Domain.MallManagement.Entitys;
using SCRM.Domain.MallManagement.Repositories;
using System;
using System.Linq;

namespace SCRM.Application.MallManagement.Impl
{
    /// <summary>
    /// 服务
    /// </summary>
    public class InvInventoryService : SCRMAppServiceBase, IInvInventoryService
    {

        /// <summary>
        /// 服务
        /// </summary>
        private readonly IInvInventoryRepository _invInventoryRepository;
        /// <summary>
        /// 初始化服务
        /// </summary>
        public InvInventoryService(IInvInventoryRepository invInventoryRepository)
        {
            _invInventoryRepository = invInventoryRepository;
        }

        /// <summary>
        /// 新增库存
        /// </summary>
        /// <param name="goodsNO"></param>
        /// <param name="newPublicInfo"></param>
        /// <param name="pk"></param>
        public void AddInventory(string goodsNO, NewPublicInfo newPublicInfo,string pk)
        {
            InvInventoryDto invInventoryDto = new InvInventoryDto();
            invInventoryDto.Id = int.Parse(pk);
            invInventoryDto.ORG_NO = AbpSession.ORG_NO;
            invInventoryDto.GOODS_NO = goodsNO;
            invInventoryDto.QTY = newPublicInfo.QTY;
            invInventoryDto.CREATE_PSN = AbpSession.USR_ID;
            invInventoryDto.CREATE_ORG_NO = AbpSession.ORG_NO;
            invInventoryDto.CREATE_DATE = DateTime.Now;
            invInventoryDto.UPDATE_DATE = DateTime.Now;
            invInventoryDto.UPDATE_PSN = AbpSession.USR_ID;
            invInventoryDto.DEL_FLAG = 1;

            _invInventoryRepository.Insert(invInventoryDto.ToEntity());
        }

        /// <summary>
        /// 修改库存
        /// </summary>
        /// <param name="goodsNo"></param>
        /// <param name="newPublicInfo"></param>
        /// <param name="pk"></param>
        public void UpdateInventory(string goodsNo, NewPublicInfo newPublicInfo, string pk)
        {
            var invEntity = _invInventoryRepository.FirstOrDefault(k => k.GOODS_NO == goodsNo);
            if (invEntity == null)
            {
                AddInventory(goodsNo, newPublicInfo, pk);
            }
            else
            {
                invEntity.QTY = newPublicInfo.QTY;
                invEntity.UPDATE_DATE = DateTime.Now;
                invEntity.UPDATE_PSN = (decimal)AbpSession.USR_ID;
                invEntity.GOODS_NO = goodsNo;

                _invInventoryRepository.Update(invEntity);
            }
        }
    }
}
