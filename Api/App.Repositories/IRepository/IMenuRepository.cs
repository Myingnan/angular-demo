using App.Core.Data;
using App.Core;
using App.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Repositories.IRepository
{
    public interface IMenuRepository : IRepository<SysMenu, string>, IAutoInject
    {
    }
}
