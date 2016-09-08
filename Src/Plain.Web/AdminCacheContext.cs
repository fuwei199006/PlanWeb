using System.Collections.Generic;
using Core.Cache;
using Core.Service;
using Plain.BLL.Article;
using Plain.BLL.MenuService;
using Plain.Model.Models;

namespace Plain.Web
{
    public class AdminCacheContext
    {
        public static AdminCacheContext Current
        {
            get
            {
                return CacheContext.GetItem<AdminCacheContext>();
            }
        }

        public virtual List<Basic_Menu> NavMenus
        {
            get
            {
               return CacheContext.Get("m_Nav",
                    () => ServiceContext.Current.CreateService<MenuService>().GetMenusByType("m_Nav"));
            }
        }
        public virtual List<Basic_Article> HotArticle
        {
            get
            {
                return CacheContext.Get("HotArticle",
                     () => ServiceContext.Current.CreateService<ArticleService>().GetArticlesByCategory("HotArticle"));
            }
        }
    }
}