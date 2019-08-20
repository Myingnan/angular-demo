using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Mapping
{
    public class SysMenuMapping: IEntityTypeConfiguration<SysMenu>
    {
        public void Configure(EntityTypeBuilder<SysMenu> builder)
        {
            builder.ToTable("SysMenu", "Base").HasKey(r => r.Id);
            builder.Property(r => r.Id).HasColumnType("varchar(36)");
            builder.Property(r => r.Path).HasColumnType("varchar(50)");
            builder.Property(r => r.Title).HasColumnType("varchar(50)");
            builder.Property(r => r.Component).HasColumnType("varchar(100)");
            builder.Property(r => r.Icon).HasColumnType("varchar(50)");
            builder.Property(r => r.ParentID).HasColumnType("varchar(36)");
            builder.Property(r => r.CreateTime).HasColumnType("DATETIME");
            builder.Property(r => r.UpdateTime).HasColumnType("DATETIME");
            builder.Property(r => r.CreateBy).HasColumnType("varchar(20)");
            builder.Property(r => r.UpdateBy).HasColumnType("varchar(20)");
            builder.HasMany(r => r.Children).WithOne(r=>r.Parent).HasForeignKey(r => r.ParentID);

        }
    }
}
