using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.WeChatPlatform.Entitys;

namespace SCRM.Infrastructure.Mappings.WeChatPlatform
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class TagHistMap : EntityMappingConfiguration<TagHist> {
    
        public override void Map(EntityTypeBuilder<TagHist> builder)
        {
            //映射表
            builder.ToTable("TAG_HIST");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //标签历史PK
            builder.Property(t => t.Id)
                .HasColumnName("TAG_HIST_ID");
            
            //映射导航属性
        }
    }
}