using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCRM.Domain.System.Entitys;
using BZM.SCRM.Infrastructure.Configuration;

namespace SCRM.Infrastructure.Mappings.System
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class MdmDeptMstrMap : EntityMappingConfiguration<MdmDeptMstr> {
    
        public override void Map(EntityTypeBuilder<MdmDeptMstr> builder)
        {
            //映射表
            builder.ToTable("MDM_DEPT_MSTR");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //PK值
            builder.Property(t => t.Id)
                .HasColumnName("DEPT_ID");
            
            //映射导航属性
        }
    }
}