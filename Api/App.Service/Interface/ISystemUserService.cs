using App.Core;
using App.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Service.Interface
{
   public interface ISystemUserService : IAutoInject
    {
        List<SysUserInfo> GetAllUser();

        int AddUser(SysUserInfo model);
        int DelUser(string id);
        SysUserInfo GetLoginUserInfo(string loginName);
        int UpdateUserInfo(SysUserInfo model);
    }
}
