using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.WeChatApi.Entitys;

namespace SCRM.Infrastructure.Mappings.WeChatApi
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class CrmBehaviorRecordMap : EntityMappingConfiguration<CrmBehaviorRecord> {
    
        public override void Map(EntityTypeBuilder<CrmBehaviorRecord> builder)
        {
            //映射表
            builder.ToTable("CRM_BEHAVIOR_RECORD");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //主键
            builder.Property(t => t.Id)
                .HasColumnName("BEHAVIOR_ID");
            
            //映射导航属性
        }
    }
}