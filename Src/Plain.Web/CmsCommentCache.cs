using Core.Cache;
using Core.Service;
using Plain.BLL.Article;
using Plain.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace Plain.Web
{
    public class CmsCommentCache
    {
        public List<Basic_Article> Articles
        {
            get
            {
                return CacheContext.Get("ArticleList",
                     () => ServiceContext.Current.CreateService<IArticleService>().GetArticles());
            }
        }

        public static CmsArticleCache Current
        {
            get
            {
                return CacheContext.GetItem<CmsArticleCache>();
            }
        }
        public List<Basic_Article> this[string key]
        {
            get
            {
                return CacheContext.Get(key,
                     () => Articles.Where(r => r.Category == key).ToList());
            }
        }

    }
}