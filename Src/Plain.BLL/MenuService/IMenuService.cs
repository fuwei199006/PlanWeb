using System.Collections.Generic;
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
        List<Basic_MenuDto> GetMenuDtos();
        Basic_Menu GetMenuById(int id);
        Basic_Menu DeleteMenuById(int id);

        Basic_Menu UpdateMenu(Basic_Menu menu);

    }
}