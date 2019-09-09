using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Infrastructure.Mappings.ServiceManagement
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class CrmAptMstrMap : EntityMappingConfiguration<CrmAptMstr> {
    
        public override void Map(EntityTypeBuilder<CrmAptMstr> builder)
        {
            //映射表
            builder.ToTable("CRM_APT_MSTR");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //PK值
            builder.Property(t => t.Id)
                .HasColumnName("APT_ID");
            
            //映射导航属性
        }
    }
}