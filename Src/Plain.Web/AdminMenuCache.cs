using System.Collections.Generic;
using System.Linq;
using Core.Cache;
using Core.Service;
using Plain.BLL.MenuService;
using Plain.Model.Models;

namespace Plain.Web
{
    public class AdminMenuCache
    {

        public static AdminMenuCache Current
        {
            get
            {
                return CacheContext.GetItem<AdminMenuCache>();
            }
        }
        public virtual List<Basic_Menu> Menus
        {
            get
            {
                return CacheContext.Get("PlainMenu",
                     () => ServiceContext.Current.CreateService<IMenuService>().GetMenus());
            }
        }

        public List<Basic_Menu> this[string key]
        {
            get
            {
                return CacheContext.Get(key,
                     () => Menus.Where(r=>r.MenuType==key).ToList());
            }
        } 
    }
}