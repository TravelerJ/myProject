using BZM.SCRM.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Infrastructure.Mappings.ServiceManagement
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class CrmEvaMstrMap : EntityMappingConfiguration<CrmEvaMstr> {
    
        public override void Map(EntityTypeBuilder<CrmEvaMstr> builder)
        {
            //映射表
            builder.ToTable("CRM_EVA_MSTR");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //PK值
            builder.Property(t => t.Id)
                .HasColumnName("EVA_ID");
            
            //映射导航属性
        }
    }
}