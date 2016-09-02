using Core.Cache;
using Framework.Utility;

namespace Framework.Web
{
    public class AdminCookieContext:CookieContext
    {
        public static AdminCookieContext Current
        {
            get
            {
                return CacheContext.GetItem<AdminCookieContext>();
            }
        }

        public override string KeyPrefix
        {
            get
            {
                return Fetch.ServerDomain + "_AdminContext_";
            }
        }
    }
}