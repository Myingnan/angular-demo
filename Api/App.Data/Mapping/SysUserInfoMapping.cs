using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Core.Data;
using App.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Mapping
{
    public class SysUserInfoMapping : IEntityTypeConfiguration<SysUserInfo>
    {
        public void Configure(EntityTypeBuilder<SysUserInfo> builder)
        {

            builder.ToTable("SysUser", "Base").HasKey(r => r.Id);

            builder.Property(r => r.Id).HasColumnName("UserID").HasColumnType("varchar(36)").HasDefaultValueSql("NEWID()");

            builder.Property(r => r.UserName).HasColumnType("varchar(50)");

            builder.Property(r => r.Password).HasColumnType("varchar(50)");

            builder.Property(r => r.ReallyName).HasColumnType("varchar(50)");

            builder.Property(r => r.MobilePhone).HasColumnType("varchar(20)");

            builder.Property(r => r.Email).HasColumnType("varchar(50)");

            builder.Property(r => r.DepartmentID).HasColumnType("varchar(36)");

            builder.Property(r => r.IsEnable);

            builder.Property(r => r.Remark).HasColumnType("varchar(200)");

            builder.Property(r => r.CreateTime).HasColumnType("DATETIME");

            builder.Property(r => r.UpdateTime).HasColumnType("DATETIME");

            builder.Property(r => r.CreateBy).HasColumnType("varchar(20)").HasDefaultValueSql("GETDATE()");

            builder.Property(r => r.UpdateBy).HasColumnType("varchar(20)");

            builder.Property(r => r.PermissionRange).HasColumnType("varchar(100)");

            builder.Property(r => r.ContractType).HasColumnType("varchar(200)");

        }
    }
}
