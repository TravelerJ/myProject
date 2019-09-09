using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.WeChatPlatform.Entitys;

namespace SCRM.Infrastructure.Mappings.WeChatPlatform
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class WctPushMsgMap : EntityMappingConfiguration<WctPushMsg> {
    
        public override void Map(EntityTypeBuilder<WctPushMsg> builder)
        {
            //映射表
            builder.ToTable("WCT_PUSH_MSG");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //主键
            builder.Property(t => t.Id)
                .HasColumnName("MSG_ID");
            
            //映射导航属性
        }
    }
}