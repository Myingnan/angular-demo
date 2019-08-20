using App.Core.Data;
using App.Repositories.IRepository;
using App.Service.Interface;
using App.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Service.CoreServices
{
    public class MenuService: IMenuService
    {
        private IMenuRepository menuRepository;

        public MenuService(IMenuRepository _menuRepository)
        {
            menuRepository = _menuRepository;
        }

        public List<SysMenu> GetAllMenu()
        {
            return menuRepository.QueryTable().ToList();
        }
    }
}
