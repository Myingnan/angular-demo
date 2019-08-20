using App.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Data
{
    public class SysMenu : BaseEntity<string>
    {
        /// <summary>
        /// 路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 菜单名
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 组件
        /// </summary>
        public string Component { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 上级ID
        /// </summary>
        public string ParentID { get; set; }

        public SysMenu Parent { get; set; }

        /// <summary>
        /// 下级菜单类
        /// </summary>
        public ICollection<SysMenu> Children { get; set; }
        
        public ICollection<SysRoleMenuRelation>  SysRoleMenuRelations { get; set; }
    }
}
