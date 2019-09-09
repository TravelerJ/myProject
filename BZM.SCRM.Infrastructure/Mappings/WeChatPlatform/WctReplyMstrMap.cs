using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.WeChatPlatform.Entitys;

namespace SCRM.Infrastructure.Datas.MySql.Mappings {
    /// <summary>
    /// 映射配置
    /// </summary>
    public class WctReplyMstrMap : EntityMappingConfiguration<WctReplyMstr> {
    
        public override void Map(EntityTypeBuilder<WctReplyMstr> builder)
        {
            //映射表
            builder.ToTable("WCT_REPLY_MSTR");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //PK值
            builder.Property(t => t.Id)
                .HasColumnName("REPLY_ID");
            
            //映射导航属性
        }
    }
}