using App.Core.Data;
using App.Data.DataBase;
using App.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Repositories.Repository
{
   public class SystemUserRepository : Repository<SysUserInfo, string>, ISystemUserRepository
    {
        public SystemUserRepository(IDbContext dbContext) : base(dbContext)
        { }

    }
}
