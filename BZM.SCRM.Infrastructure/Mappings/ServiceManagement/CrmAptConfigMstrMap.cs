using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Infrastructure.Mappings.ServiceManagement
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class CrmAptConfigMstrMap : EntityMappingConfiguration<CrmAptConfigMstr> {
    
        public override void Map(EntityTypeBuilder<CrmAptConfigMstr> builder)
        {
            //映射表
            builder.ToTable("CRM_APT_CONFIG_MSTR");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //PK值
            builder.Property(t => t.Id)
                .HasColumnName("APT_CONFIG_ID");
            
            //映射导航属性
        }
    }
}