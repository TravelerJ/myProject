using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.System.Entitys;

namespace SCRM.Infrastructure.Mappings.System
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class SysNavTreeMap : EntityMappingConfiguration<SysNavTree> {
    
        public override void Map(EntityTypeBuilder<SysNavTree> builder)
        {
            //映射表
            builder.ToTable("SYS_NAV_TREE");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //导航编号
            builder.Property(t => t.Id)
                .HasColumnName("NAV_NO");
            
            //映射导航属性
        }
    }
}