using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.WeChatPlatform.Entitys;

namespace SCRM.Infrastructure.Mappings.WeChatPlatform
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class SysUsrWctMap : EntityMappingConfiguration<SysUsrWct> {
    
        public override void Map(EntityTypeBuilder<SysUsrWct> builder)
        {
            //映射表
            builder.ToTable("SYS_USR_WCT");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //pk值
            builder.Property(t => t.Id)
                .HasColumnName("WCT_ID");
            
            //映射导航属性
        }
    }
}