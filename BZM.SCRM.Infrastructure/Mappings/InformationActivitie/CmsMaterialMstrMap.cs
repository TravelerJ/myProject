using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.InformationActivitie.Entitys;

namespace SCRM.Infrastructure.Mappings.InformationActivitie
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class CmsMaterialMstrMap : EntityMappingConfiguration<CmsMaterialMstr> {
    
        public override void Map(EntityTypeBuilder<CmsMaterialMstr> builder)
        {
            //映射表
            builder.ToTable("CMS_MATERIAL_MSTR");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //PK值
            builder.Property(t => t.Id)
                .HasColumnName("MATERIAL_ID");
            
            //映射导航属性
        }
    }
}