using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.System.Entitys;

namespace SCRM.Infrastructure.Mappings.System
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class SysRoleMstrMap : EntityMappingConfiguration<SysRoleMstr> {
    
        public override void Map(EntityTypeBuilder<SysRoleMstr> builder)
        {
            //映射表
            builder.ToTable("SYS_ROLE_MSTR");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //角色编号
            builder.Property(t => t.Id)
                .HasColumnName("ROLE_ID");
            
            //映射导航属性
        }
    }
}