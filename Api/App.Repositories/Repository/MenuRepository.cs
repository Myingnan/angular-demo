using App.Core.Data;
using App.Repositories.IRepository;
using App.Data.DataBase;
using App.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Repositories.Repository
{
    public class MenuRepository : Repository<SysMenu, string>, IMenuRepository
    {
        public MenuRepository(IDbContext dbContext) : base(dbContext)
        { }
    }
}
