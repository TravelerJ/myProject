using BZM.SCRM.Domain;
using BZM.SCRM.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Infrastructure.EntityFramework
{
   public class SCRMDbContextFactory: IDesignTimeDbContextFactory<SCRMDbContext>
    {
        public SCRMDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SCRMDbContext>();
            var configuration = AppConfigurations.Get(path: WebContentFolderHelper.CalculateContentRootFolder());

            SCRMDbContextOptionsConfigurer.Configure(
                dbContextOptions: builder,
                connectionString: configuration.GetConnectionString(name: SCRMConsts.ConnectionStringName)
            );

            return new SCRMDbContext(options: builder.Options);
        }
    }
}
