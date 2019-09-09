using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Infrastructure.Mappings.ServiceManagement
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class FinanceTagConfigMap : EntityMappingConfiguration<FinanceTagConfig> {
    
        public override void Map(EntityTypeBuilder<FinanceTagConfig> builder)
        {
            //映射表
            builder.ToTable("FINANCE_TAG_CONFIG");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //标签政策ID
            builder.Property(t => t.Id)
                .HasColumnName("TAG_ID");
            
            //映射导航属性
        }
    }
}