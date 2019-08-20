using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Mapping
{
    public class SysRoleMenuRelationMapping : IEntityTypeConfiguration<SysRoleMenuRelation>
    {
        public void Configure(EntityTypeBuilder<SysRoleMenuRelation> builder)
        {
            builder.ToTable("SysRoleMenuRelation", "base").HasKey(k=>new {k.RoleID,k.MenuID });

            builder.HasOne(r => r.SysRole).WithMany(r => r.SysRoleMenuRelations).HasForeignKey(r => r.RoleID);
            builder.HasOne(r => r.SysMenu).WithMany(r => r.SysRoleMenuRelations).HasForeignKey(r => r.MenuID);
        }
    }
}
