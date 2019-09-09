using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.System.Entitys;

namespace SCRM.Infrastructure.Mappings.System
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class WctOpTokenMap : EntityMappingConfiguration<WctOpToken> {
    
        public override void Map(EntityTypeBuilder<WctOpToken> builder)
        {
            //映射表
            builder.ToTable("WCT_OP_TOKEN");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //PK值
            builder.Property(t => t.Id)
                .HasColumnName("TOKEN_ID");
            
            //映射导航属性
        }
    }
}