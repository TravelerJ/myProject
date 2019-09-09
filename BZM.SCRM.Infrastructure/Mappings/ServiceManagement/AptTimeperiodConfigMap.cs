using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Infrastructure.Mappings.ServiceManagement
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class AptTimeperiodConfigMap : EntityMappingConfiguration<AptTimeperiodConfig> {
    
        public override void Map(EntityTypeBuilder<AptTimeperiodConfig> builder)
        {
            //映射表
            builder.ToTable("APT_TIMEPERIOD_CONFIG");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //预约时间段id
            builder.Property(t => t.Id)
                .HasColumnName("PERIOD_ID");
            
            //映射导航属性
        }
    }
}