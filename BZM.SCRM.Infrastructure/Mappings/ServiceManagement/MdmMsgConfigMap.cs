using BZM.SCRM.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Infrastructure.Mappings.ServiceManagement
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class MdmMsgConfigMap : EntityMappingConfiguration<MdmMsgConfig> {
    
        public override void Map(EntityTypeBuilder<MdmMsgConfig> builder)
        {
            //映射表
            builder.ToTable("MDM_MSG_CONFIG");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //门店配置id
            builder.Property(t => t.Id)
                .HasColumnName("BU_CONFIG_ID");
            
            //映射导航属性
        }
    }
}