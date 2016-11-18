using System.Collections.Generic;
using Framework.Contract;
using Plain.Model.Models;
using Plain.Model.Models.Mapping;
using Plain.Model.Models.Model;
using Plain.Dto;

namespace Plain.BLL.MenuService
{
    public interface IMenuService : IBaseService<Basic_Menu>
    {
        List<Basic_Menu> GetMenusByType(string type);
        List<Basic_Menu> GetMenus();
        PagedList<Basic_MenuDto> GetMenuDtos(string menuName, int pageSize, int pageIndex);
        Basic_Menu GetMenuById(int id);
        List<Basic_Menu> GetMenuByIds(List<int> ids);
        Basic_Menu DeleteMenuById(int id);

        Basic_Menu UpdateMenu(Basic_Menu menu);

        Basic_Menu AddMenu(Basic_Menu menu);
        void DeleteMenus(IList<int> ids);

    }
}