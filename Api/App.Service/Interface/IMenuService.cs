using App.Core.Data;
using App.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Service.Interface
{
    public interface IMenuService: IAutoInject
    {
        List<SysMenu> GetAllMenu();
    }
}
