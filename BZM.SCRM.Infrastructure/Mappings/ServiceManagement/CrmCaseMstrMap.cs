using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Infrastructure.Mappings.ServiceManagement
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class CrmCaseMstrMap : EntityMappingConfiguration<CrmCaseMstr> {
    
        public override void Map(EntityTypeBuilder<CrmCaseMstr> builder)
        {
            //映射表
            builder.ToTable("CRM_CASE_MSTR");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //事件编号
            builder.Property(t => t.Id)
                .HasColumnName("CASE_NO");
            
            //映射导航属性
        }
    }
}