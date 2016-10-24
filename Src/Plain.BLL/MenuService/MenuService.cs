using System.Collections.Generic;
using System.Linq;
using Plain.BLL.LoginService;
using Plain.Dao;
using Plain.Model.Models;
using Plain.Model.Models.Model;
using Plain.Dto;
using Plain.Dao.MenuDao;

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


        public List<Basic_MenuDto> GetMenuDtos()
        {
            return DaoFactory.MenuDao.GetMenuDto();
        }
      

    
    }
}