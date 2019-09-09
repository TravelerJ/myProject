using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.WeChatPlatform.Entitys;

namespace SCRM.Infrastructure.Mappings.WeChatPlatform
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class WctMenuMstrMap : EntityMappingConfiguration<WctMenuMstr> {
    
        public override void Map(EntityTypeBuilder<WctMenuMstr> builder)
        {
            //映射表
            builder.ToTable("WCT_MENU_MSTR");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //主键	
            builder.Property(t => t.Id)
                .HasColumnName("MENU_ID");
            
            //映射导航属性
        }
    }
}