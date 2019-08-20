using App.Core;
using App.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Repositories.IRepository
{
    public interface ISystemUserRepository: IRepository<SysUserInfo, string>, IAutoInject
    {

    }
}
