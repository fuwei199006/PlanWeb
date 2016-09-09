using System.Collections.Generic;
using System.Linq;
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
                    () => ServiceContext.Current.CreateService<IMenuService>().GetMenusByType("m_Nav"));
            }
        }
        public   List<Basic_Article>  Articles
        {
            get
            {
                return CacheContext.Get("ArticleList",
                     () => ServiceContext.Current.CreateService<IArticleService>().GetArticles());
            }
        }
        public virtual List<Basic_Article> HotArticles
        {
            get
            {
                return CacheContext.Get("HotArticle",
                     () => Articles.Where(r=>r.Category== "HotArticle").ToList());
            }
        }

        public virtual List<Basic_Article> TopArticles
        {
            get
            {
                return CacheContext.Get("TopArticle",
                     () => Articles.Where(r => r.Category == "TopArticle").ToList());
            }
        }
    }
}