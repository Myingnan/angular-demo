using App.Core;
using App.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Data
{
    /// <summary>
    /// 角色
    /// </summary>
    public class SysRole: BaseEntity<string>
    {
        /// <summary>
        /// 角色名
        /// </summary>
        public string RoleName { get; set; }

        public ICollection<SysUserRoleRelation> SysUserRoleRelations { get; set; }
        public ICollection<SysRoleMenuRelation> SysRoleMenuRelations { get; set; }
    }
}
