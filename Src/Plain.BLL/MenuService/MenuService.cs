using System.Collections.Generic;
using System.Linq;
using Plain.BLL.LoginService;
using Plain.Dao;
using Plain.Model.Models;
using Plain.Model.Models.Model;
using Plain.Dto;
using Plain.Dao.MenuDao;
using System;

namespace Plain.BLL.MenuService
{
    public class MenuService: BaseService<Basic_Menu>, IMenuService
    {
      
        public List<Basic_Menu> GetMenusByType(string type)
        {
            return this.LoadEntitiesNoTracking(r => r.MenuType == type).OrderBy(r => r.MenuSort).ToList();
        }

        public List<Basic_Menu> GetMenus()
        {
            return this.LoadEntitiesNoTracking(r=>r.MenuStatus).OrderBy(r => r.MenuSort).ToList();
        }


        public Basic_Menu GetMenuById(int id)
        {
            return this.GetEntityById(id);
        }

        public Basic_Menu DeleteMenuById(int id)
        {
            return this.Delete(GetMenuById(id));
        }

        public List<Basic_MenuDto> GetMenuDtos()
        {
            return DaoFactory.MenuDao.GetMenuDto();
        }

        public Basic_Menu UpdateMenu(Basic_Menu menu)
        {
            return this.Update(menu);
        }
    }
}