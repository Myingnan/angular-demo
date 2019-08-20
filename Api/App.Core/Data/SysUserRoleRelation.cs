using App.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Data
{
    public class SysUserRoleRelation
    {
        public string UserID { get; set; }
        public string RoleID { get; set; }
        public SysUserInfo SysUserInfo { get; set; }
        public SysRole SysRole { get; set; }
    }
}
