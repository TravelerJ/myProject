using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Infrastructure.Mappings.ServiceManagement
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class StoreAdvertiseMstrMap : EntityMappingConfiguration<StoreAdvertiseMstr> {
    
        public override void Map(EntityTypeBuilder<StoreAdvertiseMstr> builder)
        {
            //映射表
            builder.ToTable("STORE_ADVERTISE_MSTR");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //主键id
            builder.Property(t => t.Id)
                .HasColumnName("ADVERTISE_ID");
            
            //映射导航属性
        }
    }
}