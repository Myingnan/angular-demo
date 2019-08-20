using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Mapping
{
    public class SysUserRoleRelationMapping : IEntityTypeConfiguration<SysUserRoleRelation>
    {
        public void Configure(EntityTypeBuilder<SysUserRoleRelation> builder)
        {
            builder.ToTable("SysUserRoleRelation", "base").HasKey(k=>new {k.UserID,k.RoleID });

            builder.HasOne(r => r.SysUserInfo).WithMany(r => r.SysUserRoleRelations).HasForeignKey(r => r.UserID);
            builder.HasOne(r => r.SysRole).WithMany(r => r.SysUserRoleRelations).HasForeignKey(r => r.RoleID);
        }
    }
}
