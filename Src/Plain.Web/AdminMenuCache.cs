using System.Collections.Generic;
using System.Linq;
using Core.Cache;
using Core.Service;
using Plain.BLL.MenuService;
using Plain.Model.Models;
using Plain.Model.Models.Model;
using Plain.Dto;

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
                return CacheContext.Get(string.Format(CacheKey.PlainMenu, AdminCookieContext.Current.UserName),
                     () => ServiceContext.Current.CreateService<IMenuService>().GetMenusByLoginName(AdminCookieContext.Current.UserName));
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

        public List<Basic_Menu> this[string key,int parntId]
        {
            get
            {
                return CacheContext.Get(string.Format(CacheKey.Menu, key,parntId),
                     () => Menus.Where(r => r.MenuType == key&&r.MenuParentId==parntId).ToList());
            }
        } 
    }
}