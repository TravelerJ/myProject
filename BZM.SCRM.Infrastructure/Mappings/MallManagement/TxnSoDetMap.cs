using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.MallManagement.Entitys;

namespace SCRM.Infrastructure.Mappings.MallManagement
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class TxnSoDetMap : EntityMappingConfiguration<TxnSoDet> {
    
        public override void Map(EntityTypeBuilder<TxnSoDet> builder)
        {
            //映射表
            builder.ToTable("TXN_SO_DET");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //明细ID
            builder.Property(t => t.Id)
                .HasColumnName("SOD_ID");
            
            //映射导航属性
        }
    }
}