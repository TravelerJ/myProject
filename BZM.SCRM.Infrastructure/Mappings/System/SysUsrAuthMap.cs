using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.System.Entitys;

namespace SCRM.Infrastructure.Mappings.System
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class SysUsrAuthMap : EntityMappingConfiguration<SysUsrAuth> {
    
        public override void Map(EntityTypeBuilder<SysUsrAuth> builder)
        {
            //映射表
            builder.ToTable("SYS_USR_AUTH");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //PK值
            builder.Property(t => t.Id)
                .HasColumnName("AUTH_ID");
            
            //映射导航属性
        }
    }
}