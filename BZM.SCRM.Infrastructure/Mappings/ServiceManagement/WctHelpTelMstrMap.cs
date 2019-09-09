using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Infrastructure.Mappings.ServiceManagement
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class WctHelpTelMstrMap : EntityMappingConfiguration<WctHelpTelMstr> {
    
        public override void Map(EntityTypeBuilder<WctHelpTelMstr> builder)
        {
            //映射表
            builder.ToTable("WCT_HELP_TEL_MSTR");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //主键
            builder.Property(t => t.Id)
                .HasColumnName("TEL_ID");
            
            //映射导航属性
        }
    }
}