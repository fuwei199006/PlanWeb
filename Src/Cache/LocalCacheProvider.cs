using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using Framework.Utility;

namespace Core.Cache
{
    public class LocalCacheProvider:ICacheProvider
    {
        public virtual object Get(string key)
        {
            return Caching.Get(key);
        }

        public virtual void Set(string key, object value)
        {
             Caching.Set(key,value);
        }

        public virtual void Remove(string key)
        {
             Caching.Remove(key);
        }

        public virtual void Clear(string keyRegex)
        {
            var keys = new List<string>();
            var enumerator = HttpRuntime.Cache.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                var key = enumerator.Key.ToString();
                if (Regex.IsMatch(key,keyRegex,RegexOptions.IgnoreCase))
                {
                    keys.Add(key);
                }
            }

            foreach (var key in keys)
            {
                Caching.Remove(key);
            }

        }

        public virtual void Set(string key, object value, int min)
        {
             Caching.Set(key,value,min);
        }
         
        public virtual void Set(string key, object value, int minutes, bool isAbsoluteExpiration, Action<string, object, string> onRemove)
        {
           
            
            Caching.Set(key, value, minutes, isAbsoluteExpiration, (k, v, reason) =>
            {
                onRemove?.Invoke(k, v, reason.ToString());
            });
        }

        
    }
}