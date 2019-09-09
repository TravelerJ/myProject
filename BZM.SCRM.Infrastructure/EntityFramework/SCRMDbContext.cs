using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SCRM.Domain.System.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Infrastructure.EntityFramework
{
    public class SCRMDbContext : AbpDbContext
    {
        public SCRMDbContext(DbContextOptions<SCRMDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.AddFromAssembly(typeof(UCDbContext).Assembly);

            modelBuilder.AddEntityConfigurationsFromAssembly(assembly: typeof(SCRMDbContext).Assembly);
            base.OnModelCreating(modelBuilder: modelBuilder);
        }

        public DbSet<SysUsrMstr> SysUsrMstr { get; set; }
    }
}
