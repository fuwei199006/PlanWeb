using System.Collections.Generic;
using Plain.Model.Models;
using Plain.Model.Models.Mapping;

namespace Plain.BLL.MenuService
{
    public interface IMenuService: IBaseService<Basic_Menu>
    {
        List<Basic_Menu> GetMenusByType(string type);
        List<Basic_Menu> GetMenus();
    }
}