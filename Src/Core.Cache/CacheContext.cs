using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace Core.Cache
{
    public class CacheContext
    {
        
        public static object Get(string key)
        {
            var cacheConfig = CacheConfigContext.GetCurrentWrapCacheConfigItem(key);
            return cacheConfig.CacheProvider.Get(key);    
        }


        public static void Set(string key, object value)
        {
            var cacheConfig = CacheConfigContext.GetCurrentWrapCacheConfigItem(key);
            cacheConfig.CacheProvider.Set(key,value);
        }

        public static void Remove(string key)
        {
            var cacheConfig = CacheConfigContext.GetCurrentWrapCacheConfigItem(key);
            cacheConfig.CacheProvider.Remove(key);
        }

        public static void Clear(string keyRegex = ".*", string moduleRegex = ".*")
        {
            if (!Regex.IsMatch(CacheConfigContext.ModuleName, moduleRegex, RegexOptions.IgnoreCase))
            {
                return;//如果模块不匹配？
            }
            foreach (var cacheProvider in CacheConfigContext.CacheProviders.Values)
            {
                cacheProvider.Clear(keyRegex);
            }
        }

        public static T Get<T>(string key, Func<T> getRealData)
        {
            var getDataFromCache = new Func<T>(() =>
            {
                var data = default(T);
                var cacheData = Get(key);
                if (cacheData == null)
                {
                    data = getRealData();
                    if (data != null)
                        Set(key, data);
                }
                else
                {
                    data = (T) cacheData;
                }
                return data;
            });
            return GetItem<T>(key, getDataFromCache);

        }
        public static T Get<T,F>(string key, F id, Func<F,T> getRealData)
        {
            key = string.Format("{0}_{1}",key,id);
            var getDataFromCache = new Func<T>(() =>
            {
                var data = default(T);
                var cacheData = Get(key);
                if (cacheData == null)
                {
                    data = getRealData(id);
                    if (data != null)
                        Set(key, data);
                }
                else
                {
                    data = (T)cacheData;
                }
                return data;
            });
            return GetItem<T>(key,getDataFromCache);

        }
        public static T Get<T>(string key, int id, Func<int, T> getRealData)
        {
            return Get<T,int>(key, id, getRealData);
        }

        public static T Get<T>(string key, string id, Func<string, T> getRealData)
        {
            return Get<T, string>(key, id, getRealData);
        }


        //？？？？？？？？？？？？？？？？？？？？、
        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //id=>getRealData();修改委托的签名
        public static T Get<T>(string key, string branchKey, Func<T> getRealData)
        {
            return Get<T,string>(key, branchKey,  id=>getRealData());
        }
        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>


        #region 以下几个方法从HttpContext.Items缓存页面数据，适合页面生命周期，页面载入后就被移除，而非HttpContext.Cache在整个应用程序都有效

        public static T GetItem<T>(string name, Func<T> getRealData)
        {
            if (HttpContext.Current == null)
            {
                return getRealData();
            }

            var httpContextItems = HttpContext.Current.Items;
            if (httpContextItems.Contains(name))
            {
                return (T)httpContextItems[name];
            }
            var data = getRealData();
            if (data != null)
            {
                httpContextItems[name] = data;

            }
            return data;
        }

        public static F GetItem<F>() where F : new()
        {
            return GetItem<F>(typeof(F).ToString(), () => new F());
        }

        public static F GetItem<F>(Func<F> getRealData)
        {
            return GetItem<F>(typeof(F).ToString(), getRealData);
        } 
        #endregion
    }
}