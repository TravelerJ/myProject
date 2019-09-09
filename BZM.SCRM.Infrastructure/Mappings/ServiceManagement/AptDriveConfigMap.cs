using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Infrastructure.Mappings.ServiceManagement
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class AptDriveConfigMap : EntityMappingConfiguration<AptDriveConfig> {
    
        public override void Map(EntityTypeBuilder<AptDriveConfig> builder)
        {
            //映射表
            builder.ToTable("APT_DRIVE_CONFIG");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //主键ID
            builder.Property(t => t.Id)
                .HasColumnName("DRIVE_ID");
            
            //映射导航属性
        }
    }
}