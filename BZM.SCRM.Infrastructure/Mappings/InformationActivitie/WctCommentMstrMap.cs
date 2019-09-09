using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.InformationActivitie.Entitys;

namespace SCRM.Infrastructure.Mappings.InformationActivitie
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class WctCommentMstrMap : EntityMappingConfiguration<WctCommentMstr> {
    
        public override void Map(EntityTypeBuilder<WctCommentMstr> builder)
        {
            //映射表
            builder.ToTable("WCT_COMMENT_MSTR");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //主键
            builder.Property(t => t.Id)
                .HasColumnName("COMMENT_ID");
            
            //映射导航属性
        }
    }
}