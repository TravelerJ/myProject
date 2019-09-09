using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.MallManagement.Entitys;

namespace SCRM.Infrastructure.Mappings.MallManagement
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class InvInventoryMap : EntityMappingConfiguration<InvInventory> {
    
        public override void Map(EntityTypeBuilder<InvInventory> builder)
        {
            //映射表
            builder.ToTable("INV_INVENTORY");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //PK值
            builder.Property(t => t.Id)
                .HasColumnName("INV_ID");
            
            //映射导航属性
        }
    }
}