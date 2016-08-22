using System;
using System.Web;
using System.Web.Caching;

namespace Framework.Utility
{
    public class Caching
    {

        public static object Get(string key)
        {
            return HttpRuntime.Cache.Get(key);
        }

        public static void Remove(string key)
        {
            if (HttpRuntime.Cache[key] != null)
                HttpRuntime.Cache.Remove(key);
        }

        public static void Set(string key, object value, int min, bool isAbsoluteExpire, CacheItemRemovedCallback callBack)
        {
            if (isAbsoluteExpire)
            {
                HttpRuntime.Cache.Insert(key, value, null, DateTime.Now.AddMinutes(min), Cache.NoSlidingExpiration, CacheItemPriority.Normal, callBack);
            }
            else
            {
                HttpRuntime.Cache.Insert(key, value, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(20), CacheItemPriority.Normal, callBack);

            }

        }

        public static void Set(string key, object value,int min)
        {
            HttpRuntime.Cache.Insert(key, value, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(min));
        }

        public static void Set(string key, object value)
        {
            Set(key,value,null);
        }

        public static void Set(string name, object value, CacheDependency cacheDependency)
        {
            HttpRuntime.Cache.Insert(name, value, cacheDependency, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(60));
        }

    }
}
