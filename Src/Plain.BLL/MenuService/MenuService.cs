using System.Collections.Generic;
using System.Linq;
using Plain.BLL.LoginService;
using Plain.Model.Models;

namespace Plain.BLL.MenuService
{
    public class MenuService: BaseService<Basic_Menu>, IMenuService
    {
        public List<Basic_Menu> GetMenusByType(string type)
        {
            return this.CurrentResposity.GetListNoTracking(r => r.MenuType == type).OrderBy(r => r.MenuSort).ToList();
        }
    }
}