using App.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using App.Core.Data;
using App.Data.DataBase;
using App.Repositories.IRepository;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace App.Service.CoreServices
{
   public class SystemUserService : ISystemUserService
    {
        private ISystemUserRepository systemUserRepository;

        public SystemUserService(ISystemUserRepository _systemUserRepository) {
            systemUserRepository = _systemUserRepository;
        }

        public List<SysUserInfo> GetAllUser()
        {
            return systemUserRepository.QueryTable().Include(a=>a.SysUserRoleRelations).ThenInclude(p=>p.SysRole).ToList();
        }

        public int AddUser(SysUserInfo model)
        {
            return systemUserRepository.Add(model);
        }

        public int DelUser(string id)
        {
            return systemUserRepository.Delete(r=>id.Equals(r.Id));
        }

        public SysUserInfo GetLoginUserInfo(string loginName)
        {
            return systemUserRepository.Get(r=> loginName.Equals(r.UserName)).FirstOrDefault();
        }

        public int UpdateUserInfo(SysUserInfo model)
        {
           return systemUserRepository.Edit(model);
        }
    }
}
