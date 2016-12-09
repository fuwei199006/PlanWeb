using System.Collections.Generic;
using System.Linq;
using Plain.BLL.LoginService;
using Plain.Dao;
using Plain.Model.Models;
using Plain.Model.Models.Model;
using Plain.Dto;
using Plain.Dao.MenuDao;
using System;
using System.Linq.Dynamic;
using Framework.Contract;

namespace Plain.BLL.MenuService
{
    [Serializable]
    public class MenuService: BaseService<Basic_Menu>, IMenuService
    {
      
        public List<Basic_Menu> GetMenusByType(string type)
        {
            return this.LoadEntitiesNoTracking(r => r.MenuType == type).OrderBy(r => r.MenuSort).ToList();
        }

        public List<Basic_Menu> GetMenus()
        {
            return this.LoadEntitiesNoTracking(r=>r.MenuStatus!=0).OrderBy(r => r.MenuSort).ToList();
        }


        public Basic_Menu GetMenuById(int id)
        {
            return this.GetEntityById(id);
        }

        public Basic_Menu DeleteMenuById(int id)
        {
            return this.Delete(GetMenuById(id));
        }

        public PagedList<Basic_MenuDto> GetMenuDtos(string menuName, int pageSize, int pageIndex)
        {
            return DaoFactory.MenuDao.GetMenuDto(menuName,pageSize, pageIndex);
        }

        public Basic_Menu UpdateMenu(Basic_Menu menu)
        {
            return this.Update(menu);
        }

        public Basic_Menu AddMenu(Basic_Menu menu)
        {
            return this.Add(menu);
        }

        public void DeleteMenus(IList<int> ids)
        {
              this.DeleteEntities(ids);
        }

        public List<Basic_Menu> GetMenusByLoginName(string loginName)
        {
            return DaoFactory.MenuDao.GetMenuByUserName(loginName);
        }

        public List<Basic_Menu> GetMenuByIds(List<int> ids)
        {
            return this.LoadEntitiesNoTracking(r => ids.Contains(r.Id)&&r.MenuStatus==1).ToList();
        }
    }
}