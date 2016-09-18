namespace Plain.Web
{
    public class CmsCommentCache
    {
        public List<basic_Comm> Articles
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