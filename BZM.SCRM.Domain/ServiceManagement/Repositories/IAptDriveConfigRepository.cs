﻿using Abp.Domain.Repositories;
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Domain.ServiceManagement.Repositories {
    /// <summary>
    /// 仓储
    /// </summary>
    public interface IAptDriveConfigRepository : IRepository<AptDriveConfig,string> {
    }
}
