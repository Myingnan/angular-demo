using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Data
{
    public class SysRoleMenuRelation
    {
        public string RoleID { get; set; }
        public string MenuID { get; set; }
        public SysRole SysRole { get; set; }
        public SysMenu SysMenu { get; set; }
    }
}
