using Core.Cache;


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


        public AdminWebSettingCache AdminWebSetting
        {
            get { return AdminWebSettingCache.Current; }
        }

        public AdminMainDataContext AdminMainDataContext
        {
            get { return  AdminMainDataContext.Current;}
        }

    }
}