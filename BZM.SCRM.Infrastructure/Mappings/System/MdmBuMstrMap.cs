using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.System.Entitys;

namespace SCRM.Infrastructure.Mappings.System
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class MdmBuMstrMap : EntityMappingConfiguration<MdmBuMstr> {
    
        public override void Map(EntityTypeBuilder<MdmBuMstr> builder)
        {
            //映射表
            builder.ToTable("MDM_BU_MSTR");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //业务单元编号
            builder.Property(t => t.Id)
                .HasColumnName("BU_NO");
            
            //映射导航属性
        }
    }
}