using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.WeChatPlatform.Entitys;

namespace SCRM.Infrastructure.Mappings.WeChatPlatform
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class WctAppMstrMap : EntityMappingConfiguration<WctAppMstr> {
    
        public override void Map(EntityTypeBuilder<WctAppMstr> builder)
        {
            //映射表
            builder.ToTable("WCT_APP_MSTR");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //应用主键ID
            builder.Property(t => t.Id)
                .HasColumnName("APP_ID");
            
            //映射导航属性
        }
    }
}