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

        public AdminMenuCache MenuItems
        {
            get { return AdminMenuCache.Current; }
        }
        public CmsArticleCache ArticleItems
        {
            get { return CmsArticleCache.Current; }
        }



    }
}