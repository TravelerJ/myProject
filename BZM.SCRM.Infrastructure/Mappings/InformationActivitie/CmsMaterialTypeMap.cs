using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.InformationActivitie.Entitys;

namespace SCRM.Infrastructure.Mappings.InformationActivitie
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class CmsMaterialTypeMap : EntityMappingConfiguration<CmsMaterialType> {
    
        public override void Map(EntityTypeBuilder<CmsMaterialType> builder)
        {
            //映射表
            builder.ToTable("CMS_MATERIAL_TYPE");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //PK值
            builder.Property(t => t.Id)
                .HasColumnName("MATERIAL_TYPE_ID");
            
            //映射导航属性
        }
    }
}