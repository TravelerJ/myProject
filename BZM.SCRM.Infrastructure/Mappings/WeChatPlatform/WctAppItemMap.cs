using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.WeChatPlatform.Entitys;

namespace SCRM.Infrastructure.Mappings.WeChatPlatform
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class WctAppItemMap : EntityMappingConfiguration<WctAppItem> {
    
        public override void Map(EntityTypeBuilder<WctAppItem> builder)
        {
            //映射表
            builder.ToTable("WCT_APP_ITEM");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //子应用主键ID
            builder.Property(t => t.Id)
                .HasColumnName("ITEM_ID");
            
            //映射导航属性
        }
    }
}