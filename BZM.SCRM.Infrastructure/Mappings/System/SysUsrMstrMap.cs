﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BZM.SCRM.Infrastructure.Configuration;
using SCRM.Domain.System.Entitys;

namespace SCRM.Infrastructure.Mappings.System
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class SysUsrMstrMap : EntityMappingConfiguration<SysUsrMstr> {
    
        public override void Map(EntityTypeBuilder<SysUsrMstr> builder)
        {
            //映射表
            builder.ToTable("SYS_USR_MSTR");
            
            //映射主键
            builder.HasKey(t => t.Id);
            
            //映射属性            
            //用户ID
            builder.Property(t => t.Id)
                .HasColumnName("USR_ID");
            
            //映射导航属性
        }
    }
}