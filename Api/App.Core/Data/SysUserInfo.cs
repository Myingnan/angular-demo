using App.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Data
{
    /// <summary>
    /// 用户
    /// </summary>
  public class SysUserInfo: BaseEntity<string>
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string ReallyName { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public string DepartmentID { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        public bool IsEnable { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 权限范围
        /// </summary>
        public string PermissionRange { get; set; }

        /// <summary>
        /// 合同类型
        /// </summary>
        public string ContractType { get; set; }

        public ICollection<SysUserRoleRelation> SysUserRoleRelations { get; set; }

    }
}
