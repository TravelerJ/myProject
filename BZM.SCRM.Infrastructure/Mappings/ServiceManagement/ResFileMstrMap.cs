using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.ServiceManagement.Entitys;

namespace SCRM.Infrastructure.Mappings.ServiceManagement
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class ResFileMstrMap : EntityMappingConfiguration<ResFileMstr> {
    
        public override void Map(EntityTypeBuilder<ResFileMstr> builder)
        {
            //映射表
            builder.ToTable("RES_FILE_MSTR");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //文件ID
            builder.Property(t => t.Id)
                .HasColumnName("FILE_ID");
            
            //映射导航属性
        }
    }
}