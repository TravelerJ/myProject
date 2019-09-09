using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.WeChatPlatform.Entitys;

namespace SCRM.Infrastructure.Mappings.WeChatPlatform
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class TagMstrMap : EntityMappingConfiguration<TagMstr> {
    
        public override void Map(EntityTypeBuilder<TagMstr> builder)
        {
            //映射表
            builder.ToTable("TAG_MSTR");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //标签码
            builder.Property(t => t.Id)
                .HasColumnName("TAG_MSTR_CODE");
            
            //映射导航属性
        }
    }
}