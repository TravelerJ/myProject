using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Infrastructure.Mappings.ServiceManagement
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class CarFinancePolicyMap : EntityMappingConfiguration<CarFinancePolicy> {
    
        public override void Map(EntityTypeBuilder<CarFinancePolicy> builder)
        {
            //映射表
            builder.ToTable("CAR_FINANCE_POLICY");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //金融ID
            builder.Property(t => t.Id)
                .HasColumnName("FINANCE_ID");
            
            //映射导航属性
        }
    }
}