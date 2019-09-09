using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Infrastructure.Mappings.ServiceManagement
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class CrmQpaperMstrMap : EntityMappingConfiguration<CrmQpaperMstr> {
    
        public override void Map(EntityTypeBuilder<CrmQpaperMstr> builder)
        {
            //映射表
            builder.ToTable("CRM_QPAPER_MSTR");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //问卷编号
            builder.Property(t => t.Id)
                .HasColumnName("PAPER_ID");
            
            //映射导航属性
        }
    }
}