using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.System.Entitys;

namespace SCRM.Infrastructure.Mappings.System
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class WctBasConfigMap : EntityMappingConfiguration<WctBasConfig> {
    
        public override void Map(EntityTypeBuilder<WctBasConfig> builder)
        {
            //映射表
            builder.ToTable("WCT_BAS_CONFIG");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //主键ID
            builder.Property(t => t.Id)
                .HasColumnName("CONFIG_ID");
            
            //映射导航属性
        }
    }
}