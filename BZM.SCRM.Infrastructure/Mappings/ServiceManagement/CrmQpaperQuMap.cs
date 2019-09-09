using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Infrastructure.Mappings.ServiceManagement
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class CrmQpaperQuMap : EntityMappingConfiguration<CrmQpaperQu> {
    
        public override void Map(EntityTypeBuilder<CrmQpaperQu> builder)
        {
            //映射表
            builder.ToTable("CRM_QPAPER_QU");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //题目编号
            builder.Property(t => t.Id)
                .HasColumnName("QU_ID");
            
            //映射导航属性
        }
    }
}