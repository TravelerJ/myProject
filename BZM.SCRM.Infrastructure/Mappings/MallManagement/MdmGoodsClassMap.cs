using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.MallManagement.Entitys;

namespace SCRM.Infrastructure.Mappings.MallManagement
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class MdmGoodsClassMap : EntityMappingConfiguration<MdmGoodsClass> {
    
        public override void Map(EntityTypeBuilder<MdmGoodsClass> builder)
        {
            //映射表
            builder.ToTable("MDM_GOODS_CLASS");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //分类ID
            builder.Property(t => t.Id)
                .HasColumnName("CLASS_ID");
            
            //映射导航属性
        }
    }
}