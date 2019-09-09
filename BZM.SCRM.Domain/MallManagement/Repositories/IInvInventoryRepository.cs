﻿using Abp.Domain.Repositories;
using SCRM.Domain.MallManagement.Entitys;

namespace SCRM.Domain.MallManagement.Repositories
{
    /// <summary>
    /// 仓储
    /// </summary>
    public interface IInvInventoryRepository : IRepository<InvInventory,long> {
    }
}