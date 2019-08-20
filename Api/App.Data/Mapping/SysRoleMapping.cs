using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Mapping
{
    public class SysRoleMapping: IEntityTypeConfiguration<SysRole>
    {
        public void Configure(EntityTypeBuilder<SysRole> builder)
        {
            builder.ToTable("SysRole", "Base").HasKey(r => r.Id);
            builder.Property(r => r.Id).HasColumnName("RoleID").HasColumnType("varchar(36)");
            builder.Property(r => r.RoleName).HasColumnType("varchar(50)");
            builder.Property(r => r.CreateTime).HasColumnType("DATETIME");
            builder.Property(r => r.UpdateTime).HasColumnType("DATETIME");
            builder.Property(r => r.CreateBy).HasColumnType("varchar(20)");
            builder.Property(r => r.UpdateBy).HasColumnType("varchar(20)");
        }
    }
}
