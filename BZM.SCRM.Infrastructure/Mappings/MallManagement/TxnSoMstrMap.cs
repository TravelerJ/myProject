using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.MallManagement.Entitys;

namespace SCRM.Infrastructure.Mappings.MallManagement
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class TxnSoMstrMap : EntityMappingConfiguration<TxnSoMstr> {
    
        public override void Map(EntityTypeBuilder<TxnSoMstr> builder)
        {
            //映射表
            builder.ToTable("TXN_SO_MSTR");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //订单号
            builder.Property(t => t.Id)
                .HasColumnName("SO_NO");
            
            //映射导航属性
        }
    }
}